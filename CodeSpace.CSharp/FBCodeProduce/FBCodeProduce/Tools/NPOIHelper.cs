using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
//using System.Net.Http;
//using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using NPOI.POIFS.FileSystem;
using NPOI.SS.Converter;
using NPOI.SS.Util;

namespace FBCodeProduce.Tools
{
    public class NPOIHelper
    {
        /// <summary>
        /// 下拉框字典，会将key对应一整列的单元格替换成value的下拉框
        /// </summary>
        public Dictionary<string, string[]> dropDownLists;
        /// <summary>
        /// 表头对照字典，会将与key对应的表头替换成value
        /// ！注意：如果headDictionary!=null，则应把所有导出字段都包含在headDictionary中，即使不变更的表头也要设置value=key，否则不会导出该列表头
        /// </summary>
        public Dictionary<string, string> headDictionary;
        /// <summary>
        /// 默认行高 单位:px
        /// </summary>
        public short defaultRowHeight { get; set; }
        /// <summary>
        /// 每一列的列宽 单位:不知道，默认宽好像是10
        /// </summary>
        public int[] columnWidth { get; set; }

        public ICellStyle cellStyle;
        public NPOIHelper()
        {
            SheetNames = new List<string>();
            //LoadFile(_filePath);
        }
        private IWorkbook _workbook;
        private string _filePath;

        public List<string> SheetNames { get; set; }
        public HSSFWorkbook ExportToExcelInOneSheet2<T>(List<T> list, string fileName)
        {
            if (SheetNames.Count==0)
            {
                SheetNames.Add("CN");
            }
            HSSFWorkbook workbook = new HSSFWorkbook();
            HSSFSheet sheet = (HSSFSheet)workbook.CreateSheet(SheetNames.FirstOrDefault());

            if (list.Count > 0)
            {
                //填充表头
                Type t = list.FirstOrDefault().GetType();
                System.Reflection.PropertyInfo[] ps = t.GetProperties();

                HSSFRow dataRow = (HSSFRow)sheet.CreateRow(0);
                int headIndex = 0;
                foreach (System.Reflection.PropertyInfo p in ps)
                {
                    dataRow.CreateCell(headIndex).SetCellValue(p.Name);
                    headIndex++;
                }

                int rowIndex = 1;
                foreach (var item in list)
                {
                    dataRow = (HSSFRow)sheet.CreateRow(rowIndex);

                    int colIndex = 0;
                    foreach (System.Reflection.PropertyInfo p in ps)
                    {
                        try
                        {
                            dataRow.CreateCell(colIndex).SetCellValue(p.GetValue(item, null) + "");
                        }
                        catch
                        {

                        }
                        colIndex++;
                    }
                    rowIndex++;
                }
                for (int i = 1; i < list.Count; i += 4)
                {
                    sheet.AddMergedRegion(new CellRangeAddress(i, i + 3, 0, 0));
                }
            }

            return workbook;
            //保存
            //SaveAndResponseFile(workbook, "数据关系视图");
            //workbook.Dispose();
        }



        #region Excel信息

        /// <summary>
        /// 获取Excel信息
        /// </summary>
        /// <param name="filePath"></param>
        public List<string> LoadFile(string filePath)
        {
            var prevCulture = Thread.CurrentThread.CurrentCulture;
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            var stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Start();
            _filePath = filePath;
            SheetNames = new List<string>();
            using (var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                _workbook = WorkbookFactory.Create(fs);
            }

            stopwatch.Stop();
            Console.WriteLine("ReadFile:" + stopwatch.ElapsedMilliseconds / 1000 + "s");

            return GetSheetNames();
        }

        public List<string> LoadFile(Stream stream)
        {
            var prevCulture = Thread.CurrentThread.CurrentCulture;
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            var stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Start();
            SheetNames = new List<string>();
            _workbook = WorkbookFactory.Create(stream);
            return GetSheetNames();
        }


        public string ExcelToHtml()
        {
            if (_workbook == null)
            {
                return null;
            }


            MemoryStream ms = new MemoryStream();

            ExcelToHtmlConverter converter = new ExcelToHtmlConverter();
            converter.OutputColumnHeaders = false;
            converter.OutputHiddenColumns = false;
            converter.OutputHiddenRows = false;
            converter.OutputLeadingSpacesAsNonBreaking = true;
            converter.OutputRowNumbers = false;
            converter.UseDivsToSpan = true;

            converter.ProcessWorkbook(_workbook);
            converter.Document.Save(ms);

            return Encoding.UTF8.GetString(ms.GetBuffer());

        }

        /// <summary>
        /// 获取SHeet名称
        /// </summary>
        /// <returns></returns>
        private List<string> GetSheetNames()
        {
            var count = _workbook.NumberOfSheets;
            for (int i = 0; i < count; i++)
            {
                SheetNames.Add(_workbook.GetSheetName(i));
            }
            return SheetNames;
        }

        #endregion


        #region 获取数据源

        /// <summary>
        /// 获取所有数据，所有sheet的数据转化为datatable。
        /// </summary>
        /// <param name="isFirstRowCoumn">是否将第一行作为列标题</param>
        /// <returns></returns>
        public DataSet GetAllTables(bool isFirstRowCoumn)
        {
            var stopTime = new System.Diagnostics.Stopwatch();
            stopTime.Start();
            var ds = new DataSet();

            foreach (var sheetName in SheetNames)
            {
                ds.Tables.Add(ExcelToDataTable(sheetName, isFirstRowCoumn));
            }
            stopTime.Stop();
            Console.WriteLine("GetData:" + stopTime.ElapsedMilliseconds / 1000 + "S");
            return ds;
        }

        /// <summary>
        /// 获取第<paramref name="idx"/>的sheet的数据
        /// </summary>
        /// <param name="idx">Excel文件的第几个sheet表</param>
        /// <param name="isFirstRowCoumn">是否将第一行作为列标题</param>
        /// <returns></returns>
        public DataTable GetTable(int idx, bool isFirstRowCoumn)
        {
            if (idx >= SheetNames.Count || idx < 0)
                throw new Exception("Do not Get This Sheet");
            return ExcelToDataTable(SheetNames[idx], isFirstRowCoumn);
        }

        /// <summary>
        /// 获取sheet名称为<paramref name="sheetName"/>的数据
        /// </summary>
        /// <param name="sheetName">Sheet名称</param>
        /// <param name="isFirstRowColumn">是否将第一行作为列标题</param>
        /// <returns></returns>
        public DataTable GetTable(string sheetName, bool isFirstRowColumn)
        {
            return ExcelToDataTable(sheetName, isFirstRowColumn);
        }

        #endregion

        #region 方法

        /// <summary>
        /// 将excel中的数据导入到DataTable中
        /// </summary>
        /// <param name="sheetName">excel工作薄sheet的名称</param>
        /// <param name="isFirstRowColumn">第一行是否是DataTable的列名</param>
        /// <returns>返回的DataTable</returns>
        public DataTable ExcelToDataTable(string sheetName, bool isFirstRowColumn)
        {
            ISheet sheet = null;
            var data = new DataTable();
            data.TableName = sheetName;
            int startRow = 0;
            try
            {
                sheet = sheetName != null ? _workbook.GetSheet(sheetName) : _workbook.GetSheetAt(0);
                if (sheet != null)
                {
                    var firstRow = sheet.GetRow(0);
                    if (firstRow == null)
                        return data;
                    int cellCount = firstRow.LastCellNum; //一行最后一个cell的编号 即总的列数
                    startRow = isFirstRowColumn ? sheet.FirstRowNum + 1 : sheet.FirstRowNum;

                    for (int i = firstRow.FirstCellNum; i < cellCount; ++i)
                    {
                        //.StringCellValue;
                        var column = new DataColumn(Convert.ToChar(((int)'A') + i).ToString());
                        if (isFirstRowColumn)
                        {
                            var columnName = firstRow.GetCell(i).StringCellValue;
                            column = new DataColumn(columnName);
                        }
                        data.Columns.Add(column);
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
                                dataRow[j] = row.GetCell(j, MissingCellPolicy.RETURN_NULL_AND_BLANK).ToString();
                        }
                        data.Rows.Add(dataRow);
                    }
                }
                else throw new Exception("Don not have This Sheet");

                return data;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
                return null;
            }
        }

        #endregion


        #region 导出

        public HSSFWorkbook ExportToExcelInOneSheet<T>(List<T> list)
        {
            if (SheetNames.Count == 0)
            {
                SheetNames.Add("CN");
            }
            HSSFWorkbook workbook = new HSSFWorkbook();
            HSSFSheet sheet = (HSSFSheet)workbook.CreateSheet(SheetNames.FirstOrDefault());
           
            if (defaultRowHeight > 0)
            {
                sheet.DefaultRowHeight = Convert.ToInt16(defaultRowHeight * 20);
            }
            if (columnWidth!=null&&columnWidth.Length > 0)
            {
                for (int i = 0; i < columnWidth.Length; i++)
                {
                    sheet.SetColumnWidth(i, columnWidth[i] * 256);
                }
            }
            
            if (list.Count > 0)
            {
                //填充表头
                Type t = list.FirstOrDefault().GetType();
                System.Reflection.PropertyInfo[] ps = t.GetProperties();
                HSSFRow dataRow = (HSSFRow)sheet.CreateRow(0);
                
                //dataRow.Height = 30 * 20;
                ICellStyle notesStyle = workbook.CreateCellStyle();
                if (cellStyle!=null)
                {
                    notesStyle.CloneStyleFrom(cellStyle);
                }
                
                notesStyle.WrapText = true;//设置换行这个要先设置

                int headIndex = 0;
                //表头命名字典不为空，替换中文表头
                if (headDictionary != null && headDictionary.Count > 0)
                {

                    foreach (var dict in headDictionary)
                    {
                        sheet.SetDefaultColumnStyle(headIndex, notesStyle);
                        var cell = dataRow.CreateCell(headIndex);
                        cell.SetCellValue(dict.Value);
                        ICellStyle style = workbook.CreateCellStyle();
                        style.CloneStyleFrom(notesStyle);
                        style.FillBackgroundColor = NPOI.HSSF.Util.HSSFColor.LightBlue.Index;
                        //style.FillPattern = FillPattern.SolidForeground;
                        cell.CellStyle = style;
                        #region 222

                        var dropDownList = dropDownLists.FirstOrDefault(m => m.Key == dict.Key);
                        if (!string.IsNullOrWhiteSpace(dropDownList.Key))
                        {
                       
                       
                        System.Reflection.PropertyInfo p = ps.FirstOrDefault(m => m.Name == dropDownList.Key);
                        //创建新标签，并插入下拉框数据集
                        ISheet dSheet = workbook.CreateSheet(p.Name);

                        dSheet.CreateRow(0).CreateCell(0).SetCellValue(p.Name + "(请勿修改)");
                        //var dropdownlist = dropDownLists.First(m => m.Key == p.Name).Value;
                        for (var i = 0; i < dropDownList.Value.Length; i++)
                        {
                            dSheet.CreateRow(i + 1).CreateCell(0).SetCellValue(dropDownList.Value[i].ToString()+"");
                        }
                        //将下拉框数据集映射到主表中的单元格
                        IName range = workbook.CreateName();
                        range.RefersToFormula = string.Format("{0}!$A$2:$A${1}", p.Name+"", (dropDownList.Value.Length+1).ToString());
                        range.NameName = p.Name;
                        //CellRangeAddressList(首行，尾行，首列，尾列)
                        CellRangeAddressList regions = new CellRangeAddressList(1, 65535, headIndex, headIndex);
                        DVConstraint constraint = DVConstraint.CreateFormulaListConstraint(range.NameName);
                        HSSFDataValidation dataValidate = new HSSFDataValidation(regions, constraint);
                        sheet.AddValidationData(dataValidate);

                        }


                        #endregion
                        headIndex++;
                    }
                }
                else
                {
                    foreach (System.Reflection.PropertyInfo p in ps)
                    {
                        sheet.SetDefaultColumnStyle(headIndex, notesStyle);
                        dataRow.CreateCell(headIndex).SetCellValue(p.Name);

                        
                        headIndex++;
                    }
                }
                #region 待优化的重复代码
                //如果下拉框字典不为空，执行插入下拉框的方法
                if (dropDownLists != null)
                {

                    //foreach (var dropDownList in dropDownLists)
                    //{
                        //System.Reflection.PropertyInfo p = ps.FirstOrDefault(m => m.Name == dropDownList.Key);
                        ////创建新标签，并插入下拉框数据集
                        //ISheet dSheet = workbook.CreateSheet(p.Name);

                        //dSheet.CreateRow(0).CreateCell(0).SetCellValue(p.Name + "(请勿修改)");
                        ////var dropdownlist = dropDownLists.First(m => m.Key == p.Name).Value;
                        //for (var i = 0; i < dropDownList.Value.Length; i++)
                        //{
                        //    dSheet.CreateRow(i + 1).CreateCell(0).SetCellValue(dropDownList.Value[i]);
                        //}
                        ////将下拉框数据集映射到主表中的单元格
                        //IName range = workbook.CreateName();
                        //range.RefersToFormula = string.Format("{0}!$A$2:$A${1}", p.Name, (dropDownList.Value.Length).ToString());
                        //range.NameName = "N" + Guid.NewGuid().ToString("N");
                        ////CellRangeAddressList(首行，尾行，首列，尾列)
                        //CellRangeAddressList regions = new CellRangeAddressList(1, 65535, headIndex, headIndex);
                        //DVConstraint constraint = DVConstraint.CreateFormulaListConstraint(range.NameName);
                        //HSSFDataValidation dataValidate = new HSSFDataValidation(regions, constraint);
                        //sheet.AddValidationData(dataValidate);

                    //}
                }
                #endregion

                int rowIndex = 1;

                foreach (var item in list)
                {
                    dataRow = (HSSFRow)sheet.CreateRow(rowIndex);
                    int colIndex = 0;
                    //根据字典中有的key导出数据
                    if (headDictionary != null && headDictionary.Count > 0)
                    {
                        foreach (var dict in headDictionary)
                        {
                            var cell = dataRow.CreateCell(colIndex);
                            cell.SetCellValue((ps.First(m => m.Name == dict.Key).GetValue(item, null) + "").Replace(@"\n", Environment.NewLine));
                            //ICellStyle style = workbook.CreateCellStyle();
                            //style.CloneStyleFrom(cellStyle);
                            //cell.CellStyle = style;
                            colIndex++;
                        }

                    }
                    else
                    {

                        foreach (System.Reflection.PropertyInfo p in ps)
                        {

                            try
                            {
                                var cell = dataRow.CreateCell(colIndex);
                                cell.SetCellValue((p.GetValue(item, null) + "").Replace(@"\n", Environment.NewLine));
                                //ICellStyle style = workbook.CreateCellStyle();
                                //style.CloneStyleFrom(cellStyle);
                                //cell.CellStyle = style;
                                //dataRow.CreateCell(colIndex).SetCellValue();
                            }
                            catch
                            {

                            }
                        }

                        colIndex++;
                    }


                    rowIndex++;
                }
            }

            return workbook;
            //保存
            //SaveAndResponseFile(workbook, "数据关系视图");
            //workbook.Dispose();
        }
        #region 旧方法-根据headDictionary导出数据
        /*
         public HSSFWorkbook ExportToExcelInOneSheet<T>(List<T> list, string fileName, Dictionary<string, string> headDictionary)
        {
            HSSFWorkbook workbook = new HSSFWorkbook();
            HSSFSheet sheet = (HSSFSheet)workbook.CreateSheet("CN");

            if (list.Count > 0)
            {
                //填充表头
                Type t = list.FirstOrDefault().GetType();
                System.Reflection.PropertyInfo[] ps = t.GetProperties();

                HSSFRow dataRow = (HSSFRow)sheet.CreateRow(0);
                int headIndex = 0;
                foreach (System.Reflection.PropertyInfo p in ps)
                {
                    var dict = headDictionary.Where(m => m.Key == p.Name);
                    if (dict.Any())
                    {
                        string headName = dict.First().Value;
                        dataRow.CreateCell(headIndex).SetCellValue(headName);
                        headIndex++;
                    }

                }

                int rowIndex = 1;
                foreach (var item in list)
                {
                    dataRow = (HSSFRow)sheet.CreateRow(rowIndex);

                    int colIndex = 0;
                    foreach (System.Reflection.PropertyInfo p in ps)
                    {
                        var dict = headDictionary.Where(m => m.Key == p.Name);
                        if (dict.Any())
                        {
                            try
                            {
                                dataRow.CreateCell(colIndex).SetCellValue(p.GetValue(item, null) + "");
                            }
                            catch
                            {

                            }
                            colIndex++;
                        }

                    }
                    rowIndex++;
                }
            }
            return workbook;
            //保存
            //SaveAndResponseFile(workbook, "数据关系视图");
            //workbook.Dispose();
        }
         */
        #endregion

        /// <summary>
        /// 向客户端输出文件。
        /// </summary>
        /// <param name="table">数据表。</param>
        /// <param name="headerText">头部文本。</param>
        /// <param name="sheetName"></param>
        /// <param name="columnName">数据列名称。</param>
        /// <param name="columnTitle">表标题。</param>
        /// <param name="fileName">文件名称。</param>
        public static void ResponseWrite(HSSFWorkbook hssfworkbook, string fileName)
        {
            //HttpContext context = HttpContext.Current;
            //context.Response.ContentType = "application/vnd.ms-excel";
            //context.Response.AddHeader("Content-Disposition", string.Format("attachment;filename={0}", HttpUtility.UrlEncode(fileName, Encoding.UTF8)));
            //context.Response.Clear();
            //context.Response.BinaryWrite(WriteToStream(hssfworkbook).GetBuffer());
            //context.Response.End();
        }

        //public static HttpResponseMessage HttpWrite(HSSFWorkbook hssfworkbook, string fileName)
        //{
        //    var result = new HttpResponseMessage(HttpStatusCode.OK);

        //    var stream = WriteToStream(hssfworkbook) as Stream;
        //    result.Content = new StreamContent(stream);
        //    result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/vnd.ms-excel");

        //    result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
        //    {
        //        FileName = fileName
        //    };

        //    return result;

        //}

        public static void SaveWrite(HSSFWorkbook hssfworkbook, string folderPath, string fileName)
        {

            //创建文件夹
            if (!Directory.Exists(folderPath))
            {
                //创建
                Directory.CreateDirectory(folderPath);
            }
            System.IO.File.WriteAllBytes(folderPath + @"\" + fileName, WriteToStream(hssfworkbook).GetBuffer());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hssfworkbook"></param>
        /// <returns></returns>
        private static MemoryStream WriteToStream(HSSFWorkbook hssfworkbook)
        {
            //Write the stream data of workbook to the root directory
            MemoryStream file = new MemoryStream();
            hssfworkbook.Write(file);
            return file;
        }
        #endregion
    }
}
