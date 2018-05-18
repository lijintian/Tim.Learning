using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecursionDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //A(1)=1 A(2)=1
            //A(i)=A(i - 1) + A(i - 2)
            //i=?

            Console.Write(A(5));
            Console.ReadKey();
        }


        static int A(int i)
        {
            if (i == 1 || i == 2)
            {
                return 1;
            }
            else
            {
                return A(i - 1) + A(i - 2);
            }
        }
    }
}
