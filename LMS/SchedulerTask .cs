using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace QuartzSchduling.Models.Schedule
{
    public class SchedulerTask
    {
        private static readonly string ScheduleCronExpression = "0 * * ? * *";
        //Every Second : * * * ? * *
        //Every Minute : 0 * * ? * *
        //Every Day noon 12 pm : 0 0 12 * * ?
        public static async System.Threading.Tasks.Task StartAsync()
        {
            try
            {
                var scheduler = await StdSchedulerFactory.GetDefaultScheduler();
                if (!scheduler.IsStarted)
                {
                    await scheduler.Start();
                }
                var job1 = JobBuilder.Create<Task1>().WithIdentity("ExecuteTaskServiceCallJob1", "group1").Build();
                var trigger1 = TriggerBuilder.Create().WithIdentity("ExecuteTaskServiceCallTrigger1", "group1").WithCronSchedule(ScheduleCronExpression).Build();
                await scheduler.ScheduleJob(job1, trigger1);
                
            }
            catch (Exception ex) { }
        }
    }
}
