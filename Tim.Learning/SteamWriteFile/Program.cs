using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamWriteFile
{
    class Program
    {
        static void Main(string[] args)
        {
            using (System.IO.FileStream file = new System.IO.FileStream("D:\\Timer.txt", System.IO.FileMode.OpenOrCreate))
            {
                var dateNow = DateTime.Now.ToString()+Environment.NewLine;

                var bytes = System.Text.Encoding.UTF8.GetBytes(dateNow);

                file.Position = file.Length;
                file.Write(bytes, 0, bytes.Length);

            }
        }
    }
}
