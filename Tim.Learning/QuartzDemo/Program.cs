using log4net;
using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace QuartzDemo
{
    class Program
    {
        static void Main(string[] args)
        {

            // construct a scheduler factory
            ISchedulerFactory schedFact = new StdSchedulerFactory();

            // get a scheduler
            IScheduler sched = schedFact.GetScheduler();
            sched.Start();

            // define the job and tie it to our HelloJob class
            IJobDetail job = JobBuilder.Create<HelloJob>()
                .WithIdentity("myJob", "group1")
                .UsingJobData("jobSays","Hello Word!")//Add data to JobDataMap
                .UsingJobData("myFloatValue",3.141f)
                .Build();

            // Trigger the job to run now, and then every 40 seconds
            ITrigger trigger = TriggerBuilder.Create()
              .WithIdentity("myTrigger", "group1")
              .StartNow()
              .WithSimpleSchedule(x => x
                  .WithIntervalInSeconds(10)
                  .RepeatForever())
              .Build();

            sched.ScheduleJob(job, trigger);
        }
    }

    public class HelloJob : IJob
    {
        void IJob.Execute(IJobExecutionContext context)
        {
            JobKey key = context.JobDetail.Key;

            //JobDataMap dataMap = context.JobDetail.JobDataMap;

            JobDataMap dataMap = context.MergedJobDataMap;

            string jobSays = dataMap.GetString("jobSays");

            float myFloatValue = dataMap.GetFloat("myFloatValue");

            IList<DateTimeOffset> state = (IList<DateTimeOffset>)dataMap["myStateData"];

            state.Add(DateTimeOffset.UtcNow);

            Console.Error.WriteLine("Instance " + key + " of DumbJob says: " + jobSays + ", and val is: " + myFloatValue);

            ILog log = log4net.LogManager.GetLogger("TestLogger.TestInherit");
 
            log.Info("Job执行");
           
        }
    }
}
