using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOD.Pipeline
{
    public class SecondValve : AbstractValve
    {
        public override void Invoke(string s)
        {
            string org = s;
            Console.WriteLine($"Second valve invoked! Will replace 5 with 6");
            s = s.Replace('5', '6');
            Console.WriteLine($"Second valved handled: {org} => {s}");

            GetNext()?.Invoke(s);//将数据传递到下一个阀门
        }
    }
}
