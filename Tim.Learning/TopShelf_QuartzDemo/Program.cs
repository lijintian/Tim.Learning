using log4net.Config;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace TopShelf_QuartzDemo
{
    class Program
    {
        //Why Use ToShelf?
        //对Windows服务的封装，使开发人员更关注于业务逻辑
        static void Main(string[] args)
        {
            log4net.Config.XmlConfigurator.ConfigureAndWatch(new FileInfo(AppDomain.CurrentDomain.BaseDirectory + "log4net.config"));

            //var logCfg = new FileInfo(AppDomain.CurrentDomain.BaseDirectory + "log4net.config");
            //XmlConfigurator.ConfigureAndWatch(logCfg);

            HostFactory.Run(x =>
            {
                x.Service<QuartzServiceRunner>();

                x.RunAsLocalSystem();
                x.StartAutomatically();
                x.SetDescription("Topshelf服务Description");
                x.SetDisplayName("Topshelf服务DisplayName");
                x.SetServiceName("Topshelf服务ServiceName");
            });
        }
    }
}
