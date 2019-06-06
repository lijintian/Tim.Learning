using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOD.Pipeline
{
    public class FirstValve : AbstractValve
    {
        public override void Invoke(string s)
        {
            string org = s;
            Console.WriteLine($"First valve invoked! Will replace 1 with 2");
            s = s.Replace('1', '2');
            Console.WriteLine($"First valved handled: {org} => {s}");

            GetNext()?.Invoke(s);//将数据传递到下一个阀门
        }
    }
}
