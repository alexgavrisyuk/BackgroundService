using System;
using System.Configuration;
using Autofac;
using BackgroundService.Infrastructure;
using BackgroundService.Scheduler.Helpers;
using BackgroundService.Scheduler.Jobs;
using Quartz;

namespace BackgroundService.App
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var container = AutofacDiContainer.ConfigureContainer().Build();

                var context = container.Resolve<SeriesDbContext>();
                context.Database.CreateIfNotExists();

                var scheduler = container.Resolve<IScheduler>();

                var jobName = ConfigurationManager.AppSettings["JobName"];
                var jobGroup = ConfigurationManager.AppSettings["JobGroup"];

                IJobDetail job = JobBuilder.Create<LoadPriceJob>()
                    .WithIdentity(jobName, jobGroup)
                    .Build();

                var triggerName = ConfigurationManager.AppSettings["TriggerName"];
                var triggerGroup = ConfigurationManager.AppSettings["TriggerGroup"];
                if (!int.TryParse(ConfigurationManager.AppSettings["DaysIntervalLoadPrice"], out int daysInterval))
                {
                    daysInterval = Constants.DefaultDaysIntervalLoadPrice;
                }

                ITrigger trigger = TriggerBuilder.Create()
                    .WithIdentity(triggerName, triggerGroup)
                    .StartNow()
                    .WithSimpleSchedule(x => x
                        .WithInterval(TimeSpan.FromDays(daysInterval))
                        .RepeatForever())
                    .Build();

                scheduler.ScheduleJob(job, trigger);

                scheduler.Start();
            }
            catch (SchedulerException se)
            {
                Console.WriteLine(se);
            }

            Console.WriteLine("Press any key to close the application");
            Console.ReadKey();
        }
    }
}
