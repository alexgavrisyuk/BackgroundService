using System;
using System.Net.Http;
using System.Threading.Tasks;
using BackgroundService.Scheduler.FuelApiResponseModels;
using BackgroundService.Scheduler.Helpers;
using BackgroundService.Scheduler.Interfaces;
using Newtonsoft.Json;

namespace BackgroundService.Scheduler.Services
{
    public class FuelApiHttpClient : IFuelApiHttpClient
    {
        public async Task<FuelApiResponseModel> ReadPriceAsync()
        {
            var client = new HttpClient();
            var url = Constants.LoadPriceUrl;

            var response = await client.GetAsync(url);
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine($"Error response from {url} : {response.ReasonPhrase}");
            }

            var stringResponse = await response.Content.ReadAsStringAsync();
            var fuelApiResponse = JsonConvert.DeserializeObject<FuelApiResponseModel>(stringResponse);
            return fuelApiResponse;
        }
    }
}
