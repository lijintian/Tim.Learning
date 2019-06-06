using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //LamdaSearch();
            //HashSearch();

            #region 在共享文件夹上传下载文件
            /*UploadFileToIntranet upfi = new UploadFileToIntranet();
            upfi.UploadECCInvoice_Intranet("");*/
            #endregion

            #region 在FTP服务器上传下载文件

            //下载文件
            var ftpHelper = new FTPHelper("10.0.1.10","FtpUser","123qwe", "10.0.1.10");
            ftpHelper.DownloadFile(@"F:\Download\Ftp", @"\Csharp", @"c3.doc");

            //上传文件
            ftpHelper.UploadFile();

            #endregion

            //Console.WriteLine(money.GetDecimalValue());
            //Console.WriteLine(money.GetDecimalValueInShowPrecision());
            Console.ReadKey();
        }

       
        static void LamdaSearch()
        {
            #region 构建list1，元素有1w个以上
            List<T1> list1 = new List<T1>();
            for (var i = 0; i < 10000; i++)
            {
                list1.Add(new T1());
            }
            #endregion

            #region 构建list2，元素有1w个以上
            List<T2> list2 = new List<T2>();
            for (var i = 0; i < 10000; i++)
            {
                list2.Add(new T2());
            }
            #endregion

            Stopwatch watch = new Stopwatch();

            watch.Start();
            foreach (var item in list1)
            {
                list2.Find(x => x.Field == item.Field);
            }
            watch.Stop();

            Console.WriteLine(string.Format("总耗时：{0}微秒", watch.ElapsedMilliseconds));

            Console.ReadKey();
        }

        static void HashSearch()
        {

            #region 构建list1，元素有1w个以上
            List<T1> list1 = new List<T1>();
            for (var i = 0; i < 10000; i++)
            {
                list1.Add(new T1());
            }
            #endregion

            #region 构建list2，元素有1w个以上
            List<T2> list2 = new List<T2>();
            for (var i = 0; i < 10000; i++)
            {
                list2.Add(new T2());
            }
            #endregion

            #region 构建Dictionary
            var dicT1 = new Dictionary<string, T2>();
            foreach (var item in list2)
            {
                dicT1.Add(item.Field, item);
            }
            
            #endregion

            Stopwatch watch = new Stopwatch();

            watch.Start();
            foreach (var item in list1)
            {
                if (dicT1.ContainsKey(item.Field))
                {
                    var t2= dicT1[item.Field];
                }

            }
            watch.Stop();

            Console.WriteLine(string.Format("总耗时：{0}微秒", watch.ElapsedMilliseconds));

            Console.ReadKey();
        }


        class T1
        {
            public T1()
            {
                this.Field = Guid.NewGuid().ToString();

                this.FieldLocal = "\\u751c\\u751c\\u5708 \\u751c\\u751c\\u5708";

                var listStr = new List<string>();
                listStr.Add("\\u751c\\u751c\\u5708 \\u751c\\u751c\\u5708");
                listStr.Add("\\u751c\\u751c\\u5708 \\u751c\\u751c\\u5708");
                listStr.Add("\\u751c\\u751c\\u5708 \\u751c\\u751c\\u5708");


                var listStr1 = new List<string>();
                listStr1.Add("\\u751c\\u751c\\u5708 \\u751c\\u751c\\u5708");
                listStr1.Add("\\u751c\\u751c\\u5708 \\u751c\\u751c\\u5708");
                listStr1.Add("\\u751c\\u751c\\u5708 \\u751c\\u751c\\u5708");

                var listStr2 = new List<string>();
                listStr2.Add("\\u751c\\u751c\\u5708 \\u751c\\u751c\\u5708");
                listStr2.Add("\\u751c\\u751c\\u5708 \\u751c\\u751c\\u5708");
                listStr2.Add("\\u751c\\u751c\\u5708 \\u751c\\u751c\\u5708");

                this.FeildLocals = listStr;

                this.ReferenceTypeField = new T2() {
                    FieldLocal = "\\u751c\\u751c\\u5708 \\u751c\\u751c\\u5708"
                };

                var listRf = new List<T2>();
                listRf.Add(
                    new T2()
                    {
                        FieldLocal = "\\u751c\\u751c\\u5708 \\u751c\\u751c\\u5708",
                        FeildLocals = listStr1
                    }
                    );

                listRf.Add(
                    new T2()
                    {
                        FieldLocal = "\\u751c\\u751c\\u5708 \\u751c\\u751c\\u5708",
                        FeildLocals = listStr2
                    }
                    );

                this.ReferenceTypeFields = listRf;
            }

           
            public List<String> FeildLocals { get; set; }

            public string Field { get;set; }

         
            public string FieldLocal { get; set; }

          
            public T2 ReferenceTypeField { get; set; }

            [UnicodeField]
            public List<T2> ReferenceTypeFields { get; set; }
        }

        class T2
        {
            public T2()
            {
                this.Field = Guid.NewGuid().ToString();
            }

            public string Field { get;private set; }

           
            public string FieldLocal { get; set; }

            [UnicodeField]
            public List<String> FeildLocals { get; set; }
        }
    }
}
