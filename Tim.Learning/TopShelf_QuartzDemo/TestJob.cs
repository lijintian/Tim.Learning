
using log4net;
using Quartz;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TopShelf_QuartzDemo
{
    class TestJob : IJob
    {
        static TestJob()
        {

        }

        private static Object lck = new object();

        private readonly ILog _log = LogManager.GetLogger(typeof(TestJob));
        public void Execute(IJobExecutionContext context)
        {
            lock(lck)
            {
                _log.InfoFormat("Begin-" + Thread.CurrentThread.Name);
                _log.InfoFormat("TestJob Execute-" + Thread.CurrentThread.Name);
                Thread.CurrentThread.Join(5000);
                _log.InfoFormat("End-" + Thread.CurrentThread.Name);
            }
        }
    }
}
