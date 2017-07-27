using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace How_JIT_Run_Your_Code
{
    public class Program
    {
        static void Main(string[] args)
        {
            var a = 0.0001;
            Console.WriteLine(a.ToString("F"));

            Console.ReadKey();

        }
    }

    class Foo
    {
        public void Test()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Test");
            }
        }
    }
}
