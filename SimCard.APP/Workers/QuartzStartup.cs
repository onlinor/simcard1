using System;
using System.Collections.Specialized;

using Quartz;
using Quartz.Impl;


namespace SimCard.APP.Workers
{
    // Responsible for starting and gracefully stopping the scheduler.
    public class QuartzStartup
    {
        private IScheduler _scheduler; // after Start, and until shutdown completes, references the scheduler object

        // starts the scheduler, defines the jobs and the triggers
        public void Start()
        {
            if (_scheduler != null)
            {
                throw new InvalidOperationException("Already started.");
            }

            NameValueCollection properties = new NameValueCollection
            {
                { "quartz.serializer.type", "binary" }
            };

            // Grab the Scheduler instance from the Factory

            StdSchedulerFactory schedulerFactory = new StdSchedulerFactory(properties);
            _scheduler = schedulerFactory.GetScheduler().Result;
            _scheduler.Start().Wait();

            // define the job and tie it to our HelloJob class
            IJobDetail userEmailsJob = JobBuilder.Create<SendUserEmailsJob>()
                .WithIdentity("SendUserEmails", "group1")
                .Build();

            // Trigger the job to run now, and then repeat at midnight 12am everyday
            ITrigger userEmailsTrigger = TriggerBuilder.Create()
             .WithIdentity("trigger1", "group1")
                .WithSchedule(CronScheduleBuilder.CronSchedule("0 0 0 * * ?"))
                .Build();

            //.WithDailyTimeIntervalSchedule(
            //   x => x.WithIntervalInSeconds(30))

            // Tell quartz to schedule the job using our trigger
            _scheduler.ScheduleJob(userEmailsJob, userEmailsTrigger).Wait();
        }

        // initiates shutdown of the scheduler, and waits until jobs exit gracefully (within allotted timeout)
        public void Stop()
        {
            if (_scheduler == null)
            {
                return;
            }

            // give running jobs 30 sec (for example) to stop gracefully
            if (_scheduler.Shutdown(waitForJobsToComplete: true).Wait(30000))
            {
                _scheduler = null;
            }
            else
            {
                // jobs didn't exit in timely fashion - log a warning...
            }
        }
    }
}
