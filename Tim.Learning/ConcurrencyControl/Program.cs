using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcurrencyControl
{
    class Program
    {
        static void Main(string[] args)
        {
            using (GlobalLocker.Enter("key", 300))
            {
                //do sth
            }
        }
    }
}
