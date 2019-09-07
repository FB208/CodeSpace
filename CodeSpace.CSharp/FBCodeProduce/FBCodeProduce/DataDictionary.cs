using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DBUtility;
using DLL.DBUtility;
using FBCodeProduce.Tools;
using NPOI.HSSF.UserModel;
using NPOI.HSSF.Util;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace FBCodeProduce
{
    public partial class DataDictionary : Form
    {
        //行高
        short height = 200 * 2;
        public string DataBaseName = "";
        public DataDictionary()
        {
            InitializeComponent();
        }

        private void btn_Open_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.ShowDialog();
            this.tb_Path.Text = file.FileName;
        }

        ICellStyle SetFontStyle(IWorkbook wk,out IFont font)
        {
            #region 设置字体
            font = wk.CreateFont();//创建字体样式  
            font.FontHeight = 12 * 20;//设置字体大小
            font.FontName = "宋体";
            ICellStyle style = wk.CreateCellStyle();//创建单元格样式  
            style.SetFont(font);//设置单元格样式中的字体样式  
            return style;

            #endregion
        }

        void SetTitle(ISheet sheet, ICellStyle style,string tableName)
        {
            #region 标题
            HSSFRow dataRow_TableName = (HSSFRow)sheet.CreateRow(0);
            dataRow_TableName.Height = height;
            var dataRow_TableName_Cell = dataRow_TableName.CreateCell(0);
            dataRow_TableName_Cell.CellStyle = style;
            dataRow_TableName_Cell.SetCellValue("中文表名：");
            HSSFRow dataRow_TableNameEng = (HSSFRow)sheet.CreateRow(1);
            dataRow_TableNameEng.Height = height;
            var dataRow_TableNameEng_Cell = dataRow_TableNameEng.CreateCell(0);
            dataRow_TableNameEng_Cell.CellStyle = style;
            dataRow_TableNameEng_Cell.SetCellValue("英文表名：" + tableName);
            #endregion
        }

        void SetTableHead(IWorkbook wk,ISheet sheet,IFont font)
        {
            #region 表头
            //string[] heads = new string[] { "列名", "自增", "主键", "类型", "长度", "备注" };
            string[] heads = new string[] { "英文名", "中文名", "类型", "主键", "是否为空", "默认值", "备注" };
            int[] cellWidth = new int[] { 18, 22, 10, 5, 10, 10, 20 };
            #region 设置列宽

            for (int w = 0; w < cellWidth.Length; w++)
            {
                sheet.SetColumnWidth(w, cellWidth[w] * 256);
            }
            #endregion

            HSSFRow dataRow_1 = (HSSFRow)sheet.CreateRow(2);
            dataRow_1.Height = height;
            for (int h = 0; h < heads.Length; h++)
            {
                var cell = dataRow_1.CreateCell(h);
                cell.SetCellValue(heads[h]);
                #region 表头样式
                ICellStyle style_head = wk.CreateCellStyle();
                style_head.SetFont(font);//设置单元格样式中的字体样式  
                style_head.FillForegroundColor = 42;
                style_head.FillPattern = FillPattern.SolidForeground;
                style_head.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;
                style_head.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;
                style_head.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;
                style_head.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;
                #endregion
                cell.CellStyle = style_head;//为单元格设置显示样式  
            }
            #endregion
        }

        private void btn_Create_Click(object sender, EventArgs e)
        {
            
            DataTable dt_TableNames = DbHelper
                .Query("USE " + DataBaseName + "; SELECT * FROM SYSOBJECTS WHERE TYPE='U' ORDER BY name").Tables[0];
            IWorkbook wk = new HSSFWorkbook();
            //字体
            IFont font;
            ICellStyle style = SetFontStyle(wk,out font);

            for (int i = 0; i < dt_TableNames.Rows.Count; i++)
            {
                ISheet sheet = wk.CreateSheet(dt_TableNames.Rows[i]["name"] + "");

                //标题
                SetTitle(sheet, style, dt_TableNames.Rows[i]["name"] + "");
                //表头
                SetTableHead(wk, sheet, font);
                #region 主体
                ICellStyle style_body = wk.CreateCellStyle();
                style_body.CloneStyleFrom(style);
                style_body.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;
                style_body.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;
                style_body.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;
                style_body.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;
                DataTable dt_column = DatabaseHelper.GetTableColums(dt_TableNames.Rows[i]["name"] + "");
                string[] bodys = new string[] { "ColumnName", "Remark", "Type", "IsIdentity","","","" };
                for (int j = 0; j < dt_column.Rows.Count; j++)
                {
                    HSSFRow dataRow = (HSSFRow)sheet.CreateRow(j + 3);
                    //行高
                    dataRow.Height = height;
                    for (int b = 0; b < bodys.Length; b++)
                    {
                        var cell = dataRow.CreateCell(b);
                        cell.CellStyle = style_body;//为单元格设置显示样式  
                        //判断列名不为空
                        if (!string.IsNullOrWhiteSpace(bodys[b] + ""))
                        {
                            cell.SetCellValue((dt_column.Rows[j][bodys[b]] + "").Replace(@"\n", Environment.NewLine)); 
                        }
                    }
                }
                #endregion
            }
            #region 表格导出
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            wk.Write(ms);
            

            // 把 Stream 转换成 byte[]
            byte[] bytes = ms.GetBuffer();// new byte[ms.Length];
            //ms.Read(bytes, 0, bytes.Length);
            //// 设置当前流的位置为流的开始
            //ms.Seek(0, SeekOrigin.Begin);

            // 把 byte[] 写入文件
            //filePath = "C:\\Users\\Yang\\Desktop\\测试文件\\新建 Microsoft Office Excel 工作表222.xlsx";
            FileStream fileStream = new FileStream(DateTime.Now.ToString("yyyyMMddHHmmss")+".xls", FileMode.OpenOrCreate);
            BinaryWriter bw = new BinaryWriter(fileStream);
            bw.Write(bytes);
            bw.Close();
            fileStream.Close();
           
            #endregion

            MessageBox.Show("导出成功");
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            using (FileStream fsRead = System.IO.File.OpenRead(tb_Path.Text))
            {
                IWorkbook wk = null;
                string strConn;
                StringBuilder cLog = new StringBuilder();//变更日志
                //获取后缀名
                string extension = tb_Path.Text.Substring(tb_Path.Text.LastIndexOf("."), (tb_Path.Text.Length - tb_Path.Text.LastIndexOf("."))).ToLower();
                //判断是否是excel文件
                if (extension == ".xlsx" || extension == ".xls")
                {
                    #region 判断excel的版本
		 

                    if (extension == ".xlsx")
                    {
                        wk = new XSSFWorkbook(fsRead);
                        //strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filepath + ";Extended Properties=Excel 12.0;";
                    }
                    else
                    {
                        wk = new HSSFWorkbook(fsRead);
                        //strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filepath + ";Extended Properties=Excel 8.0;";
                    }
                    #endregion

                    //using (OleDbConnection conn = new OleDbConnection(strConn))
                    //{
                    //    DataTable sheetNames = conn.GetOleDbSchemaTable(System)
                    //}
                    int sheetCount = wk.NumberOfSheets;
                    List<string> sheetNameList = new List<string>();
                    //循环sheet 保存名称到一个集合
                    for (int i = 0; i < sheetCount; i++)
                    {
                        
                        string sheetName = wk.GetSheetName(i);
                        sheetNameList.Add(sheetName);
                        //判断sheet是否隐藏，隐藏则不作处理
                        if (wk.IsSheetHidden(i))
                        {
                            continue;
                        }
                        if (sheetName == "keywords")
                        {
                            continue;
                        }
                        //循环sheet内的列和数据库做比较
                        ISheet sheet = wk.GetSheetAt(i);
                        
                        int rowsCount = sheet.LastRowNum+1;
                        DataTable tableColumns = DatabaseHelper.GetTableColums(sheetName);
                        List<DataRow> drs = tableColumns.ToList();
                        List<string> tableColNames = drs.Select(m => m["ColumnName"] + "").ToList();
                        List<string> excelColNames = new List<string>();
                        for (int j = 3; j < rowsCount; j++)
                        {
                            IRow row = sheet.GetRow(j);
                            ICell cell = row.GetCell(0);
                            if (cell==null)
                            {
                                continue;
                            }
                            excelColNames.Add(cell.StringCellValue);
                            if (tableColNames.All(m => m != cell.StringCellValue))
                            {
                                //excel表中有数据表中没有该字段 表示删除
                                ICellStyle delStyle = wk.CreateCellStyle();
                                delStyle.FillForegroundColor = NPOI.HSSF.Util.HSSFColor.LightOrange.Index;
                                delStyle.FillPattern = FillPattern.SolidForeground;
                                //row.RowStyle = delStyle;
                                for (int k = 0; k < 7; k++)
                                {
                                    row.GetCell(k).CellStyle = delStyle;
                                }
                                cLog.Append(string.Format("表{0}删除了字段{1}\n", sheetName, cell.StringCellValue));
                            }
                        }
                        //数据表中有 excel中没有 表示新增
                        List<string> addList = tableColNames.Except(excelColNames).ToList();
                        #region 取单元格样式

                        IRow IDRow = sheet.GetRow(3);
                        ICell IDCell = IDRow.GetCell(0);
                        ICellStyle IDStyle = IDCell.CellStyle;
                        #endregion
                        for (int j = 0; j < addList.Count; j++)
                        {
                            DataRow[] addRow = tableColumns.Select(" ColumnName = '" + addList[j] + "' ");
                            IRow newRow = sheet.CreateRow(rowsCount+j);
                            ICell newCell_ColName = newRow.CreateCell(0);
                            newCell_ColName.CellStyle = IDStyle;
                            newCell_ColName.SetCellValue(addRow[0]["ColumnName"] + "");
                            //
                            ICell newCell_CNName = newRow.CreateCell(1);
                            newCell_CNName.CellStyle = IDStyle;
                            //
                            ICell newCell_Type = newRow.CreateCell(2);
                            newCell_Type.CellStyle = IDStyle;
                            newCell_Type.SetCellValue(addRow[0]["Type"] + "");
                            //
                            ICell newCell_PrimaryKey = newRow.CreateCell(3);
                            newCell_PrimaryKey.CellStyle = IDStyle;
                            newCell_PrimaryKey.SetCellValue(addRow[0]["IsPK"] + "");
                            //
                            ICell newCell_IsNull = newRow.CreateCell(4);
                            newCell_IsNull.CellStyle = IDStyle;
                            newCell_IsNull.SetCellValue(addRow[0]["CanBeNull"] + "");
                            //
                            ICell newCell_Default = newRow.CreateCell(5);
                            newCell_Default.CellStyle = IDStyle;
                            newCell_Default.SetCellValue(addRow[0]["DefaultValue"] + "");
                            //
                            ICell newCell_Remark = newRow.CreateCell(6);
                            newCell_Remark.CellStyle = IDStyle;
                            newCell_Remark.SetCellValue(addRow[0]["Remark"] + "");
                            cLog.Append(string.Format("表{0}新增了字段{1}\n", sheetName, addList[j]));
                        }
                        

                    }
                    

                    //最后对比名称集合和数据表名称集合 在后面新建sheet
                    DataTable tableNames = DatabaseHelper.GetTables("NewReport");
                    List<string> dbTableNameList = tableNames.ToList().Select(m => m["name"]+"").ToList();
                    List<string> newTableList = dbTableNameList.Except(sheetNameList).ToList();
                    //字体
                    IFont font;
                    ICellStyle style = SetFontStyle(wk, out font);
                    for (int i = 0; i < newTableList.Count; i++)
                    {
                        ISheet sheet = wk.CreateSheet(newTableList[i]);
                        //标题
                        SetTitle(sheet, style, newTableList[i]);
                        //表头
                        SetTableHead(wk, sheet, font);
                        #region 主体
                        ICellStyle style_body = wk.CreateCellStyle();
                        style_body.CloneStyleFrom(style);
                        style_body.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;
                        style_body.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;
                        style_body.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;
                        style_body.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;
                        DataTable dt_column = DatabaseHelper.GetTableColums(newTableList[i]);
                        string[] bodys = new string[] { "ColumnName", "Remark", "Type", "IsIdentity", "", "", "" };
                        for (int j = 0; j < dt_column.Rows.Count; j++)
                        {
                            HSSFRow dataRow = (HSSFRow)sheet.CreateRow(j + 3);
                            //行高
                            dataRow.Height = height;
                            for (int b = 0; b < bodys.Length; b++)
                            {
                                var cell = dataRow.CreateCell(b);
                                cell.CellStyle = style_body;//为单元格设置显示样式  
                                //判断列名不为空
                                if (!string.IsNullOrWhiteSpace(bodys[b] + ""))
                                {
                                    cell.SetCellValue((dt_column.Rows[j][bodys[b]] + "").Replace(@"\n", Environment.NewLine));
                                }
                            }
                        }
                        #endregion
                        cLog.Append(string.Format("新建表{0}\n", newTableList[i]));
                    }

                    #region 表格导出
                    System.IO.MemoryStream ms = new System.IO.MemoryStream();
                    wk.Write(ms);


                    // 把 Stream 转换成 byte[]
                    byte[] bytes = ms.GetBuffer();// new byte[ms.Length];
                    FileStream fileStream = new FileStream(DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls", FileMode.OpenOrCreate);
                    BinaryWriter bw = new BinaryWriter(fileStream);
                    bw.Write(bytes);
                    bw.Close();
                    fileStream.Close();

                    #endregion
                    //记录变更的内容 保存到txt
                    tb_CLog.Text = cLog.ToString();
                }
            }
        }
    }
}
