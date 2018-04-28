using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace Log4NetDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            for (var i = 0; i < 100; i++)
            {
                ILog log = log4net.LogManager.GetLogger("TestLogger.TestInherit");

                log.Error("错误", new Exception("发生了一个异常"));//错误
                log.Fatal("严重错误", new Exception("发生了一个致命错误"));//严重错误
                log.Info("信息"); //记录一般信息
                log.Debug("调试信息");//记录调试信息
                log.Warn("警告");//记录警告信息

                Console.WriteLine("日志记录完毕。");
            }
            

            Console.Read();
        }
    }
}
