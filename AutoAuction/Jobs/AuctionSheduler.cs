using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Quartz;
using Quartz.Impl;

namespace AutoAuction.Jobs
{
    public class AuctionSheduler
    {
        public static void Start()
        {

            IScheduler scheduler = StdSchedulerFactory.GetDefaultScheduler();
            scheduler.Start();
            IJobDetail job = JobBuilder.Create<AuctionChecker>().Build();

            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity("trigger", "groupForCheck")
                .WithSchedule(CronScheduleBuilder.DailyAtHourAndMinute(00, 00))
                .Build();
            scheduler.ScheduleJob(job, trigger);
        }
    }    
}