using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOD.Pipeline
{
    /// <summary>
    ///（基础阀门）尾阀门
    /// </summary>
    public class BasicValve : AbstractValve
    {
        public override void Invoke(string s)
        {
            string org = s;
            Console.WriteLine($"Basic valve invoked! Will replace a with b");
            s = s.Replace('a', 'b');
            Console.WriteLine($"Basic valved handled: {org} => {s}");
        }
    }
}
