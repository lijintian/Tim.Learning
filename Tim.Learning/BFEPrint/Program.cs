using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace BFEPrint
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WindowHeight = Console.LargestWindowHeight;
            Console.WindowWidth = Console.LargestWindowWidth;
            Console.WindowLeft = 0;
            Console.WindowTop = 0;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.CursorSize = 10;
            
            Console.WriteLine("Ready！(按回车开始)");
            
            var keys = Console.ReadLine();

            using (System.IO.FileStream file = new System.IO.FileStream("print.txt", System.IO.FileMode.OpenOrCreate))
            {

                var sr = new StreamReader(file);

                while (true)
                {
                    var str = sr.ReadLine();

                    if (str==null|| str.Trim() == "END")
                    {
                        break;
                    }

                    if ( str.Trim().Contains("LongStop"))
                    {
                        var stopSecondStrs = str.Trim().Split(':');

                        decimal stopSecond = 0.2M;
                        if (stopSecondStrs.Length > 1)
                        {
                            stopSecond = Convert.ToDecimal(str.Split(':')[1]);
                        }
                      

                        Thread.Sleep(Convert.ToInt32(stopSecond*1000));

                        continue;
                    }

                    foreach (var a in str)
                    {
                        Thread.Sleep(1);
                        Console.Write(a);
                    }
                    Console.Write("\n");
                }

                while (true)
                {
                    Thread.Sleep(1000);
                    Console.Write("-");//
                }


                
              

            }

        }

        
    }
}
