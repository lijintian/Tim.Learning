using OOD.Pipeline;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOD
{
    class Program
    {
        static void Main(string[] args)
        {
            TestPipeline();
            Console.ReadKey();
        }

        static void TestPipeline()
        {
            string s = "1123wsa346yt4543s2156ac";
            StandardPipeLine pipeLine = new StandardPipeLine();
            BasicValve basicValve = new BasicValve();
            FirstValve firstValve = new FirstValve();
            SecondValve secondValve = new SecondValve();
            pipeLine.SetBasic(basicValve);
            pipeLine.AddValve(firstValve);
            pipeLine.AddValve(secondValve);
            pipeLine.GetFirst().Invoke(s);
        }
    }
}
