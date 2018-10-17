using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Thread_ThreadPool_Task
{
    /// <summary>
    /// 本demo一方面的目的在于研究Thread、ThreadPool、Task的区别
    /// 另一方面在于研究线程死亡是否会释放资源的情况
    /// </summary>
    class Program
    {

        private static Thread billMatchThread { get; set; }

        static void Main(string[] args)
        {
            //在线程内while
            billMatchThread = new Thread(BillMatch);

            billMatchThread.Start();


            //task
            while (true)
            {
                Console.WriteLine("输入任意键启动新线程,q退出");
                var keyInfo = Console.ReadKey();

                if (keyInfo.KeyChar == 'q')
                {
                    break;
                }
                CancellationTokenSource cts = new CancellationTokenSource();
                Task<int> t = new Task<int>(() => DoTask(cts.Token), cts.Token);
                t.Start();
                t.ContinueWith(TaskEnded);

                Console.WriteLine("线程启动，输入任意键结束");
                Console.ReadKey();
                cts.Cancel();
              
            }
        }


        static void BillMatch()
        {
            while (true)
            {//线程里一直While，线程一直存活着导致资源无法释放；如果是把While放在外面，线程死亡应该能会送资源
             //两个demo 
             //1、在线程内while
             //2、线程外While，每次做任务新建一个线程，任务做完回收线程
             //3、执行完成后查看内存情况

                #region 构建Dictionary对象
                var dicTest = new Dictionary<string, List<TestObject>>();

                for (var i = 0; i < 20000; i++)
                {
                    var listTestObject = new List<TestObject>();


                    //var randomCount = new Random().Next(1, 10);

                    var randomCount = 10;

                    for (var j = 0; j < randomCount; j++)
                    {
                        listTestObject.Add(new TestObject());
                    }

                    dicTest.Add(i.ToString(), listTestObject);
                }
                #endregion

                #region 将对象引用设为Null 强行GC
                dicTest = null;
                GC.Collect();
                GC.WaitForPendingFinalizers();
                #endregion

                Thread.Sleep(1000);

            }
        }


        static void TaskEnded(Task<int> task)
        {
            Console.WriteLine("任务完成，完成时候的状态为：");
            Console.WriteLine("IsCanceled={0}\tIsCompleted={1}\tIsFaulted={2}", task.IsCanceled, task.IsCompleted, task.IsFaulted);
            Console.WriteLine("任务的返回值为：{0}", task.Result);

            GC.Collect();
            GC.WaitForPendingFinalizers();
            Console.WriteLine("强行GC");
        }

        static int DoTask(CancellationToken ct)
        {
            Console.WriteLine("任务开始……");

            //Hashtable dicTest = new Hashtable();

            var dicTest = new Dictionary<string, List<TestObject>>();

            for (var i = 0; i < 20000; i++)
            {
                var listTestObject = new List<TestObject>();


                //var randomCount = new Random().Next(1, 10);

                var randomCount = 10;

                for (var j = 0; j < randomCount; j++)
                {
                    listTestObject.Add(new TestObject());
                }

                dicTest.Add(i.ToString(), listTestObject);
            }

            int result = 0;
            while (!ct.IsCancellationRequested)
            {
                result++;
                Thread.Sleep(1000);
            }
            return result;
        }
    }

    public class TestObject
    {
        public TestObject()
        {
            this.Field1 = Guid.NewGuid().ToString();
            this.Field2 = Guid.NewGuid().ToString();
            this.Field3 = Guid.NewGuid().ToString();
        }

        public string Field1 { get; private set; }

        public string Field2 { get; private set; }

        public string Field3 { get; private set; }
    }
}
