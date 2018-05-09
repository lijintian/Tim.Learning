using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace TopShelf_QuartzDemo
{
    public class QuartzServiceRunner:ServiceControl,ServiceSuspend
    {
        private readonly IScheduler scheduler;

        public QuartzServiceRunner()
        {
            this.scheduler= StdSchedulerFactory.GetDefaultScheduler();
        }

        bool ServiceControl.Start(HostControl hostControl)
        {
            scheduler.Start();
            return true;
        }

        bool ServiceControl.Stop(HostControl hostControl)
        {
            scheduler.Shutdown(false);
            return true;
        }


        bool ServiceSuspend.Continue(HostControl hostControl)
        {
            scheduler.ResumeAll();
            return true;
        }

        bool ServiceSuspend.Pause(HostControl hostControl)
        {
            scheduler.PauseAll();
            return true;
        }

        //public void Start()
        //{
        //    //从配置文件中读取任务启动时间
        //    string cronExpr = ConfigurationManager.AppSettings["cronExpr"];
        //    IJobDetail job = JobBuilder.Create<TestJob>().WithIdentity("job1", "group1").Build();
        //    //创建任务运行的触发器
        //    ITrigger trigger = TriggerBuilder.Create().WithIdentity("triggger1", "group1").WithSchedule(CronScheduleBuilder.CronSchedule(new CronExpression(cronExpr))).Build();
        //    //启动任务
        //    scheduler.ScheduleJob(job, trigger);
        //    scheduler.Start();
        //    scheduler.Start();
        //}

        //public void Stop()
        //{
        //    scheduler.Clear();
        //}

        //public bool Continue(HostControl hostControl)
        //{
        //    scheduler.ResumeAll();
        //    return true;
        //}

        //public bool Pause(HostControl hostControl)
        //{
        //    scheduler.PauseAll();
        //    return true;
        //}

      
    }
}
