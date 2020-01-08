using Quartz;
using Quartz.Impl;
using ExampleTopshelfQuartzSerilog.src;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleTopshelfQuartzSerilog
{
    class ScheduleService
    {
        private readonly IScheduler scheduler;
        public ScheduleService()
        {
            scheduler = StdSchedulerFactory.GetDefaultScheduler();
        }
        public void Start()
        {
            scheduler.Start();

            ScheduleJobs();
        }
        public void ScheduleJobs()
        {
            IJobDetail job = JobBuilder.Create<HelloJob>()
                .WithIdentity("job1", "group1")
                .Build();

            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity("trigger1", "group1")
                .StartNow()
                .WithSimpleSchedule(x => x
                    .WithIntervalInSeconds(3)
                    .RepeatForever())
                .Build();
            scheduler.ScheduleJob(job, trigger);
        }
        public void Stop()
        {
            scheduler.Shutdown();
        }
    }
}
