using Autofac;
using Autofac.Extras.Quartz;
using BackgroundService.Infrastructure;
using BackgroundService.Infrastructure.Interfaces;
using BackgroundService.Infrastructure.Repo;
using BackgroundService.Scheduler.Interfaces;
using BackgroundService.Scheduler.Jobs;
using BackgroundService.Scheduler.Services;

namespace BackgroundService.App
{
    public static class AutofacDiContainer
    {
        public static ContainerBuilder ConfigureContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterModule(new QuartzAutofacFactoryModule());

            builder.RegisterModule(new QuartzAutofacJobsModule(typeof(LoadPriceJob).Assembly));

            builder.RegisterType<SeriesDbContext>().AsSelf().SingleInstance();

            builder.RegisterType<FuelApiHttpClient>().As<IFuelApiHttpClient>().SingleInstance();

            builder.RegisterType<SeriesRepository>().As<ISeriesRepository>();

            builder.RegisterType<SeriesEntryRepository>().As<ISeriesEntryRepository>();

            return builder;
        }
    }
}
