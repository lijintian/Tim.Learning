using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace MillionDataExportToExcel
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        static void Main()
        {
            var heads = new[] { "T1", "T2","T3","T4","T5","T6","T7","T8","T9","T10" };

            List<string[]> contents = new List<string[]>();

            for (var i = 0; i < 300000; i++)
            {
                contents.Add(new string[] {
                    "Content1-"+i,
                    "Content2-"+i,
                    "Content3-"+i,
                    "Content4-"+i,
                    "Content5-"+i,
                    "Content6-"+i,
                    "Content7-"+i,
                    "Content8-"+i,
                    "Content9-"+i,
                    "Content10-"+i
                });
            }

            var excelHelper = new ExcelHelper();

            //用NPOI导出xls：需要创建很多NPOI的对象，内存和性能都有压力，但是能定制各种格式
            //excelHelper.CreateExcelFileAndInport(heads, contents, "Shee1");

            var multiContents = new List<List<string[]>>();
            multiContents.Add(contents);

            var multiHeads = new List<string[]>();
            multiHeads.Add(heads);

            //直接用steam写csv：以流读写文件，性能极佳，但是不能定制一些特殊excel格式，如颜色，字体，公式等
            excelHelper.ExportCSVContent(multiContents,multiHeads);

            //var excelContents =new  ExcelHelper().GetContents(heads, contents);
        }

    }
}
