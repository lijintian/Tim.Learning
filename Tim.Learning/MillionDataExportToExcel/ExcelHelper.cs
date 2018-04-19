
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using NPOI.XSSF.UserModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MillionDataExportToExcel
{
    public class ExcelHelper : IDisposable
    {
        private IWorkbook workbook = null;
        private FileStream fs = null;
        private bool disposed;

        public ExcelHelper()
        {
            disposed = false;
        }
        #region 导出excel
        /// <summary>
        /// 将DataTable数据导入到excel中
        /// </summary>
        /// <param name="fileName">文件名称</param>
        /// <param name="data">要导入的数据</param>
        /// <param name="isColumnWritten">DataTable的列名是否要导入</param>
        /// <param name="sheetName">要导入的excel的sheet的名称</param>
        /// <returns>导入数据行数(包含列名那一行)</returns>
        public void DataTableToExcel(string fileName, DataTable data, bool isColumnWritten, string sheetName)
        {
            int i = 0;
            int j = 0;
            int count = 0;
            ISheet sheet = null;
            string filePath = FileExtent.GetExcelExportPath;
            try
            {
                #region 判断Excel当前版本

                if (filePath.IndexOf(".xlsx") > 0) // 2007版本
                {
                    workbook = new XSSFWorkbook();
                }
                else if (filePath.IndexOf(".xls") > 0) // 2003版本
                {
                    workbook = new HSSFWorkbook();
                }
                else
                {
                    throw new AccessViolationException("不存在Excel后缀类型.");
                }

                #endregion

                using (fs = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                {
                    #region 创建Excel文件
                    if (workbook != null)
                    {
                        sheet = workbook.CreateSheet(sheetName);
                    }
                    else
                    {
                        return;
                    }
                    #endregion

                    #region 往Excel文件中写入 DataTable的列名

                    if (isColumnWritten == true)
                    {
                        IRow row = sheet.CreateRow(0);
                        for (j = 0; j < data.Columns.Count; ++j)
                        {
                            row.CreateCell(j).SetCellValue(data.Columns[j].ColumnName);
                        }
                        count = 1;
                    }
                    else
                    {
                        count = 0;
                    }

                    #endregion

                    #region 往Excel文件中写入数据

                    for (i = 0; i < data.Rows.Count; ++i)
                    {
                        IRow row = sheet.CreateRow(count);
                        for (j = 0; j < data.Columns.Count; ++j)
                        {
                            row.CreateCell(j).SetCellValue(data.Rows[i][j].ToString());
                        }
                        ++count;
                    }
                    workbook.Write(fs); //写入到excel
                    #endregion
                }
            }
            finally
            {
                //if (workbook != null)
                //{
                //    workbook.Close();
                //}
            }
            // 指定返回的是个不能被客户端读取的流，必须被下载 
            Export(filePath, "application/ms-excel", fileName);

        }
        /// <summary>
        /// 文件名编码
        /// </summary>
        /// <param name="filepath">路径</param>
        /// <param name="contentType">数据流类型</param>
        /// <param name="fileName">下载之后的文件名</param>
        public static bool Export(string filepath, string contentType, string fileName)
        {
            if (string.IsNullOrEmpty(filepath) || string.IsNullOrEmpty(contentType) || File.Exists(filepath) == false)
            {
                return false;
            }
            var file = new FileInfo(filepath);
            var response = CreateResponse(fileName, contentType);
            HttpUtility.UrlEncodeToBytes(fileName, Encoding.UTF8);
            // 添加头信息，指定文档大小，让浏览器能够显示下载进度 
            response.AddHeader("Content-Length", file.Length.ToString());
            // 指定返回的是个不能被客户端读取的流，必须被下载 
            response.ContentType = contentType + "; charset=UTF-8";
            // 把文档流发送到客户端 
            response.WriteFile(file.FullName);
            response.Flush();
            // 停止页面的执行 
            // response.End();
            return true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="contentType">数据流类型</param>
        /// <param name="fileName">下载之后的文件名</param>
        /// <returns></returns>
        private static HttpResponse CreateResponse(string fileName, string contentType)
        {
            string filename = fileName;
            var response = HttpContext.Current.Response;
            response.Clear();
            response.Charset = "GB2312";
            response.ContentEncoding = Encoding.UTF8;
            //在https协议下没有给缓存权限，故需要以下二行
            response.AddHeader("Pragma", "public");
            //response.AddHeader("Cache-Control", "max-age=30");
            response.AddHeader("Cache-Control", "public");
            // 添加头信息，为"文档下载/另存为"对话框指定默认文档名 
            var userAgent = HttpContext.Current.Request.UserAgent.ToLower();
            if (userAgent.IndexOf("msie") > -1)
            {
                filename = HttpUtility.UrlPathEncode(filename);
            }
            if (userAgent.IndexOf("firefox") > -1)
            {
                response.AddHeader("Content-Disposition", "attachment;filename=\"" + filename + "\"");
            }
            else
            {
                response.AddHeader("Content-Disposition", "attachment;filename=" + filename);
            }
            // 指定返回的是个不能被客户端读取的流，必须被下载 
            response.ContentType = contentType + "; charset=UTF-8";
            return response;
        }
        #endregion

        #region 读取excel
        /// <summary>
        /// 将excel中的数据导入到DataTable中
        /// </summary>
        /// <param name="sheetName">excel工作薄sheet的名称</param>
        /// <param name="isFirstRowColumn">第一行是否是DataTable的列名</param>
        /// <returns>返回的DataTable</returns>
        public DataTable ExcelToDataTable(string filePath, string sheetName, bool isFirstRowColumn)
        {
            ISheet sheet = null;
            DataTable data = new DataTable();
            int startRow = 0;
            using (fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                try
                {
                    if (filePath.IndexOf(".xlsx") > 0) // 2007版本
                    {
                        workbook = new XSSFWorkbook(fs);
                    }
                    else if (filePath.IndexOf(".xls") > 0) // 2003版本
                    {
                        workbook = new HSSFWorkbook(fs);
                    }
                    if (sheetName != null)
                    {
                        sheet = workbook.GetSheet(sheetName);
                        if (sheet == null) //如果没有找到指定的sheetName对应的sheet，则尝试获取第一个sheet
                        {
                            sheet = workbook.GetSheetAt(0);
                        }
                    }
                    else
                    {
                        sheet = workbook.GetSheetAt(0);
                    }
                    if (sheet != null)
                    {
                        IRow firstRow = sheet.GetRow(0);
                        int cellCount = firstRow.LastCellNum; //一行最后一个cell的编号 即总的列数

                        if (isFirstRowColumn)
                        {
                            for (int i = firstRow.FirstCellNum; i < cellCount; ++i)
                            {
                                ICell cell = firstRow.GetCell(i);
                                if (cell != null)
                                {
                                    string cellValue = ReadCell(cell, workbook);
                                    if (cellValue != null)
                                    {
                                        DataColumn column = new DataColumn(cellValue);
                                        data.Columns.Add(column);
                                    }
                                }
                            }
                            startRow = sheet.FirstRowNum + 1;
                        }
                        else
                        {
                            startRow = sheet.FirstRowNum;
                        }

                        //最后一列的标号
                        int rowCount = sheet.LastRowNum;
                        for (int i = startRow; i <= rowCount; ++i)
                        {
                            IRow row = sheet.GetRow(i);
                            if (row == null) continue; //没有数据的行默认是null　　　　　　　

                            DataRow dataRow = data.NewRow();
                            for (int j = row.FirstCellNum; j < cellCount; ++j)
                            {
                                if (row.GetCell(j) != null) //同理，没有数据的单元格都默认是null
                                    dataRow[j] = row.GetCell(j).ToString();
                            }
                            data.Rows.Add(dataRow);
                        }
                    }
                }
                finally
                {
                    //if (workbook != null)
                    //{
                    //    workbook.Close();
                    //}
                }
            }
            return data;
        }
        /// <summary>
        /// 将excel中的数据导入到DataTable中，针对不规则的 Excel列名
        /// </summary>
        /// <param name="sheetName">excel工作薄sheet的名称</param>
        /// <param name="isFirstRowColumn">第一行是否是DataTable的列名</param>
        /// <param name="cellLength">列数</param>
        /// <returns>返回的DataTable</returns>
        public DataTable ExcelToDataTableByCellLength(string filePath, string sheetName, bool isFirstRowColumn, int cellLength)
        {
            ISheet sheet = null;
            DataTable data = new DataTable();
            int startRow = 0;
            using (fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                try
                {
                    if (filePath.IndexOf(".xlsx") > 0) // 2007版本
                    {
                        workbook = new XSSFWorkbook(fs);
                    }
                    else if (filePath.IndexOf(".xls") > 0) // 2003版本
                    {
                        workbook = new HSSFWorkbook(fs);
                    }
                    if (sheetName != null)
                    {
                        sheet = workbook.GetSheet(sheetName);
                        if (sheet == null) //如果没有找到指定的sheetName对应的sheet，则尝试获取第一个sheet
                        {
                            sheet = workbook.GetSheetAt(0);
                        }
                    }
                    else
                    {
                        sheet = workbook.GetSheetAt(0);
                    }
                    if (sheet != null)
                    {
                        IRow firstRow = sheet.GetRow(0);
                        int cellCount = cellLength; //firstRow.LastCellNum一行最后一个cell的编号 即总的列数

                        if (isFirstRowColumn)
                        {
                            for (int i = firstRow.FirstCellNum; i < cellCount; ++i)
                            {
                                ICell cell = firstRow.GetCell(i);
                                if (cell != null)
                                {
                                    string cellValue = ReadCell(cell, workbook);
                                    if (cellValue != null)
                                    {
                                        DataColumn column = new DataColumn(cellValue);
                                        data.Columns.Add(column);
                                    }
                                    else
                                    {
                                        DataColumn column = new DataColumn("特殊的列" + i);
                                        data.Columns.Add(column);
                                    }
                                }
                                else
                                {
                                    DataColumn column = new DataColumn("特殊的列" + i);
                                    data.Columns.Add(column);
                                }
                            }
                            startRow = sheet.FirstRowNum + 1;
                        }
                        else
                        {
                            startRow = sheet.FirstRowNum;
                        }

                        //最后一列的标号
                        int rowCount = sheet.LastRowNum;
                        for (int i = startRow; i <= rowCount; ++i)
                        {
                            IRow row = sheet.GetRow(i);
                            if (row != null && row.Cells.Count > 0)
                            {
                                DataRow dataRow = data.NewRow();
                                for (int j = row.FirstCellNum; j < cellCount; ++j)
                                {
                                    if (row.GetCell(j) != null) //同理，没有数据的单元格都默认是null
                                    {
                                        dataRow[j] = row.GetCell(j).ToString();
                                    }
                                }
                                data.Rows.Add(dataRow);
                            }
                        }
                    }
                }
                finally
                {
                    //if (workbook != null)
                    //{
                    //    workbook.Close();
                    //}
                }
            }
            return data;
        }
        private string ReadCell(ICell cell, IWorkbook workbook)
        {
            string cellValue = string.Empty;
            //读取Excel格式，根据格式读取数据类型
            switch (cell.CellType)
            {
                case CellType.Blank: //空数据类型处理
                    break;
                case CellType.String: //字符串类型
                    cellValue = cell.StringCellValue;
                    break;
                case CellType.Numeric: //数字类型                                   
                    if (DateUtil.IsValidExcelDate(cell.NumericCellValue))
                    {
                        cellValue = cell.DateCellValue.ToString();
                    }
                    else
                    {
                        cellValue = cell.NumericCellValue.ToString();
                    }
                    break;
                case CellType.Formula:
                    HSSFFormulaEvaluator e = new HSSFFormulaEvaluator(workbook);
                    cellValue = e.Evaluate(cell).StringValue;
                    break;
                default:
                    break;
            }
            return cellValue;
        }
        #endregion

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    if (fs != null)
                        fs.Close();
                }

                fs = null;
                disposed = true;
            }
        }

        #region 创建一个Excel文件导入
        public byte[] CreateExcelFileAndInport(string[] heads, List<string[]> list, string sheetName)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                IWorkbook workbook = null;
                try
                {
                    var excleFile = File.Create(System.IO.Path.Combine(System.Environment.CurrentDirectory, DateTime.Now.ToString("yyyy-MM-dd_HH_mm_ss")+ "test.xlsx"));
                    excleFile.Position = 0;

                    workbook = new XSSFWorkbook();
                    IRow row;
                    ICell cell;
                    ISheet sheet = workbook.CreateSheet(sheetName);
                    row = sheet.CreateRow(0);
                    row.HeightInPoints = 20;
                    int cellLength = heads.Length;//列数
                    ICellStyle styleHead = workbook.CreateCellStyle();
                    IFont font = workbook.CreateFont();
                    font.Boldweight = (short)NPOI.SS.UserModel.FontBoldWeight.Bold;
                    styleHead.SetFont(font);
                    for (int i = 0; i < cellLength; i++)
                    {
                        cell = row.CreateCell(i);
                        cell.SetCellValue(heads[i]);
                        cell.CellStyle = styleHead;
                        sheet.SetColumnWidth(i, (heads[i].Length + 2) * 2 * 256);
                    }
     
          
                    for (int i = 0; i < list.Count; i++)
                    {
                      
                        row = sheet.CreateRow(i + 1);
                        for (int j = 0; j < cellLength; j++)
                        {
                            cell = row.CreateCell(j);
                            cell.SetCellValue(list[i][j]);
                        }
                    }
                    workbook.Write(excleFile);
           

                }
                finally
                {
                    GC.Collect();
                }
                //stream.Flush();
                return stream.ToArray();
            }
        }
        #endregion


        #region 以流的方式导出excel
        /// <summary>
        /// 导出byte的excel
        /// </summary>
        /// <param name="heads">列头</param>
        /// <param name="list">数据项</param>
        /// <param name="sheetName">sheetName</param>
        /// <returns></returns>
        public byte[] GetContents(string[] heads, List<string[]> list, string sheetName = "Sheet1")
        {
            XSSFWorkbook workbook = null;
            try
            {
                workbook = new XSSFWorkbook();
                WriteToExcel(heads, list, sheetName, workbook);
                using (MemoryStream stream = new MemoryStream())
                {
                    workbook.Write(stream);
                    return stream.ToArray();
                }
            }
            finally
            {
                if (workbook != null)
                {
                    workbook.Clear();
                }
                list = null;
                workbook = null;
            }
        }

        /// <summary>
        /// 导出具有多个sheet项的Excel
        /// </summary>
        /// <param name="sheetList"></param>
        /// <returns></returns>
        public byte[] GetContents(IEnumerable<ExportExcelDto> sheetList)
        {
            XSSFWorkbook workbook = null;
            try
            {
                workbook = new XSSFWorkbook();
                foreach (var item in sheetList)
                {
                    WriteToExcel(item.Heads, item.DataList, item.SheetName, workbook);
                }
                using (MemoryStream stream = new MemoryStream())
                {
                    workbook.Write(stream);
                    return stream.ToArray();
                }
            }
            finally
            {
                if (workbook != null)
                {
                    workbook.Clear();
                }
                sheetList = null;
                workbook = null;
            }
        }

        /// <summary>
        /// 写数据到Excel
        /// </summary>
        /// <param name="heads"></param>
        /// <param name="list"></param>
        /// <param name="sheetName"></param>
        /// <param name="workbook"></param>
        private static void WriteToExcel(string[] heads, List<string[]> list, string sheetName, XSSFWorkbook workbook)
        {
            IRow row;
            ICell cell;
            ISheet sheet = workbook.CreateSheet(sheetName);
            row = sheet.CreateRow(0);
            row.HeightInPoints = 20;
            int cellLength = heads.Length;//列数
            ICellStyle styleHead = workbook.CreateCellStyle();
            IFont font = workbook.CreateFont();
            font.Boldweight = (short)NPOI.SS.UserModel.FontBoldWeight.Bold;
            styleHead.SetFont(font);
            for (int i = 0; i < cellLength; i++)
            {
                cell = row.CreateCell(i);
                cell.SetCellValue(heads[i]);
                cell.CellStyle = styleHead;
                sheet.SetColumnWidth(i, (heads[i].Length + 2) * 2 * 256);
            }
            for (int i = 0; i < list.Count; i++)
            {
                row = sheet.CreateRow(i + 1);
                for (int j = 0; j < cellLength; j++)
                {
                    row.CreateCell(j).SetCellValue(list[i][j]);
                }
            }
            row = null;
            cell = null;
            sheet = null;
            list = null;
        }

        //sheet.DefaultColumnWidth = (50 * 256);
        // sh.AddMergedRegion(new NPOI.SS.Util.CellRangeAddress(0, 0, 0, 3));  //合并单元格
        //CellRangeAddress（）该方法的参数次序是：开始行号，结束行号，开始列号，结束列号。
        #endregion
        /// <summary>
        /// Zip压缩文件
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="zipFileName"></param>
        public void ZipFile(string filePath, string zipFileName, string fileName)
        {
            using (FileStream srcFile = File.OpenRead(filePath))
            {
                using (ICSharpCode.SharpZipLib.Zip.ZipOutputStream zipFile = new ICSharpCode.SharpZipLib.Zip.ZipOutputStream(File.Open(zipFileName, FileMode.Create)))
                {
                    byte[] fileData = new byte[srcFile.Length];
                    srcFile.Read(fileData, 0, (int)srcFile.Length);
                    ICSharpCode.SharpZipLib.Zip.ZipEntry entry = new ICSharpCode.SharpZipLib.Zip.ZipEntry(fileName);//新建实例
                    entry.DateTime = DateTime.Now;
                    entry.Size = srcFile.Length;
                    srcFile.Close();
                    zipFile.PutNextEntry(entry);
                    zipFile.Write(fileData, 0, fileData.Length);
                }
            }
        }

        public void CreateZip(string sourceFilePath, string destinationZipFilePath)
        {
            if (sourceFilePath[sourceFilePath.Length - 1] != System.IO.Path.DirectorySeparatorChar)
                sourceFilePath += System.IO.Path.DirectorySeparatorChar;
            ICSharpCode.SharpZipLib.Zip.ZipOutputStream zipStream = new ICSharpCode.SharpZipLib.Zip.ZipOutputStream(File.Create(destinationZipFilePath));
            zipStream.SetLevel(6);  // 压缩级别 0-9
            CreateZipFiles(sourceFilePath, zipStream);
            zipStream.Finish();
            zipStream.Close();
        }

        private void CreateZipFiles(string sourceFilePath, ICSharpCode.SharpZipLib.Zip.ZipOutputStream zipStream)
        {
            ICSharpCode.SharpZipLib.Checksums.Crc32 crc = new ICSharpCode.SharpZipLib.Checksums.Crc32();
            string[] filesArray = Directory.GetFileSystemEntries(sourceFilePath);

            foreach (string file in filesArray)
            {
                if (Directory.Exists(file))                     //如果当前是文件夹，递归
                {
                    CreateZipFiles(file, zipStream);
                }
                else                                            //如果是文件，开始压缩
                {
                    FileStream fileStream = File.OpenRead(file);
                    byte[] buffer = new byte[fileStream.Length];
                    fileStream.Read(buffer, 0, buffer.Length);
                    string tempFile = file.Substring(sourceFilePath.LastIndexOf("\\") + 1);
                    ICSharpCode.SharpZipLib.Zip.ZipEntry entry = new ICSharpCode.SharpZipLib.Zip.ZipEntry(tempFile);
                    entry.DateTime = DateTime.Now;
                    entry.Size = fileStream.Length;
                    fileStream.Close();
                    crc.Reset();
                    crc.Update(buffer);
                    entry.Crc = crc.Value;
                    zipStream.PutNextEntry(entry);
                    zipStream.Write(buffer, 0, buffer.Length);
                }
            }
        }


        public  void ExportCSVContent( List<List<string[]>> list, List<string[]> heads)
        {
            List<string> srcfiles = new List<string>();



            string simpleFileFolder = System.IO.Path.Combine(System.Environment.CurrentDirectory,"SimpleFile");

            string zipFileFolder = System.IO.Path.Combine(System.Environment.CurrentDirectory, "ZipFile");

            if (!Directory.Exists(simpleFileFolder))
            {
                Directory.CreateDirectory(simpleFileFolder);
            }

            if (!Directory.Exists(zipFileFolder))
            {
                Directory.CreateDirectory(zipFileFolder);
            }


            for (var i = 0; i < heads.Count(); i++)
            {
                string sheetName = string.Empty;

                string filePath = simpleFileFolder + string.Format("\\Test_{0}.csv",DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss"));
                using (StreamWriter write = new StreamWriter(filePath, false, System.Text.Encoding.Default))
                {
                    //写列头
                    write.WriteLine(string.Join(",", heads[i]));
                    if (list.Count > 0)
                    {
                        for (var j = 0; j < list[i].Count(); j++)
                        {
                            for (var k = 0; k < list[i][j].Count(); k++)
                            {
                                if (!string.IsNullOrEmpty(list[i][j][k]))
                                {
                                    list[i][j][k] = list[i][j][k].ToString().Replace(",", "，");
                                }
                            }

                            write.WriteLine(string.Join(",", list[i][j]));
                        }
                    }
                    write.Flush();
                    write.Close();
                }
                srcfiles.Add(filePath);
            }



            string gzipFilePath = zipFileFolder + string.Format("\\压缩文件_{0}.zip", Guid.NewGuid());
            //Zip压缩文件
            CreateZip(simpleFileFolder, gzipFilePath);
            //导出
            //ExportHelper.Export(gzipFilePath, "application/octet-stream", "账单明细.zip");
            //删除服务器失效的文件
            //DirectoryInfo di = new DirectoryInfo(simpleFileFolder);
            //di.Delete(true);
            //File.Delete(gzipFilePath);

        }

    }
}
