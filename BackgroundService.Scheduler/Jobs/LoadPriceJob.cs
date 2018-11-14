using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using BackgroundService.Domain.Entities;
using BackgroundService.Infrastructure.Interfaces;
using BackgroundService.Scheduler.Helpers;
using BackgroundService.Scheduler.Interfaces;
using Mapster;
using Quartz;

namespace BackgroundService.Scheduler.Jobs
{
    public class LoadPriceJob : IJob
    {
        private readonly ISeriesRepository _seriesRepository;
        private readonly ISeriesEntryRepository _seriesEntryRepository;
        private readonly IFuelApiHttpClient _fuelApiHttpClient;

        public LoadPriceJob(ISeriesRepository seriesRepository, ISeriesEntryRepository seriesEntryRepository, IFuelApiHttpClient fuelApiHttpClient)
        {
            _seriesRepository = seriesRepository;
            _seriesEntryRepository = seriesEntryRepository;
            _fuelApiHttpClient = fuelApiHttpClient;
        }

        public async void Execute(IJobExecutionContext context)
        {
            var fuelApiResponseModel = await _fuelApiHttpClient.ReadPriceAsync();
            if (fuelApiResponseModel != null)
            {
                foreach (var series in fuelApiResponseModel.Series)
                {
                    var existedSeries = _seriesRepository.Get().FirstOrDefault(item =>
                        item.Id.ToLower().Equals(series.SeriesId.ToLower()));

                    if (existedSeries == null)
                    {
                        existedSeries = series.Adapt<Series>();
                        existedSeries.Id = series.SeriesId;
                        await _seriesRepository.CreateAsync(existedSeries);
                    }
                    else
                    {
                        existedSeries.Update(series.Copyright, series.Description, series.End, series.F,
                            series.Geography, series.Iso3166, series.Name, series.Source, series.Start, series.Units,
                            series.UnitsShort, series.Updated);
                        await _seriesRepository.UpdateAsync(existedSeries);
                    }

                    if (!int.TryParse(ConfigurationManager.AppSettings["DaysCount"], out int daysToTake))
                    {
                        daysToTake = Constants.DefaultDaysCount;
                    }

                    var pastDateForFilter = DateTime.Now.AddDays(-daysToTake);

                    var seriesEntriesFromApi = series.Data
                        .Select(item => new SeriesEntry
                        {
                            Date = item[0].ToObject<string>(),
                            Price = item.ToArray()[1].ToObject<decimal>()
                        })
                        .Where(item =>
                            DateTime.ParseExact(item.Date, "yyyyMMdd", CultureInfo.InvariantCulture) >=
                            pastDateForFilter)
                        .OrderByDescending(item => item.Date)
                        .ToList();

                    var seriesEntriesFromFromDb = _seriesEntryRepository.Get()
                        .Where(item => item.SeriesId == existedSeries.Id);

                    var newSeriesEntries = seriesEntriesFromApi.Where(item =>
                        !seriesEntriesFromFromDb.Any(e => e.Date.Equals(item.Date)));

                    ICollection<Task<bool>> tasks = new List<Task<bool>>();

                    newSeriesEntries.ToList().ForEach(item =>
                    {
                        item.SeriesId = existedSeries.Id;

                        tasks.Add(_seriesEntryRepository.CreateAsync(item));
                    });

                    await Task.WhenAll(tasks);

                }
            }
        }
    }
}
