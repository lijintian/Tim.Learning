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
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new Service1()
            };
            ServiceBase.Run(ServicesToRun);
        }

        public static void WpsExcel(Type type, DataTable grid, List<int> rowsStr, List<int> colsStr)
        {
            dynamic _app = Activator.CreateInstance(type);  //根据类型创建App实例
            dynamic _workbook;  //声明一个文件
            _workbook = _app.Workbooks.Add(Type.Missing); //创建一个Excel
               WpsApiEx.ApplicationEventsEx appEvenEx 

            ET.Worksheet objSheet; //声明Excel中的页
            objSheet = _workbook.ActiveSheet;  //创建一个Excel
            ET.Range range;
            try
            {
                range = objSheet.get_Range("A1", Missing.Value);
                object[,] saRet = new object[rowsStr.Count, colsStr.Count];  //声明一个二维数组
                for (int iRow = 0; iRow < rowsStr.Count; iRow++)  //把sourceGrid中的数据组合成二维数组
                {
                    int row = rowsStr[iRow];
                    for (int iCol = 0; iCol < colsStr.Count; iCol++)
                    {
                        int col = colsStr[iCol];
                        saRet[iRow, iCol] = grid[row, col].Value;
                    }
                }
                range.set_Value(ET.ETRangeValueDataType.etRangeValueDefault, saRet);  //把组成的二维数组直接导入range
                _app.Visible = true;
                _app.UserControl = true;
            }
            catch (Exception theException)
            {
                String errorMessage;
                errorMessage = "Error: ";
                errorMessage = String.Concat(errorMessage, theException.Message);
                errorMessage = String.Concat(errorMessage, " Line: ");
                errorMessage = String.Concat(errorMessage, theException.Source);
                MessageBox.Show(errorMessage, "Error");
            }
        }
    }
}
