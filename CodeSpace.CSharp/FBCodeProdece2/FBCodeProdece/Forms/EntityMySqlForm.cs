using FBCodeProduce.Forms.basic;
using FBCodeProduce.Helpers;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FBCodeProduce.Forms
{
    public partial class EntityMySqlForm : BaseForm
    {
        
        public EntityMySqlForm()
        {
            InitializeComponent();
            
        }

        private void EntityMySqlForm_Load(object sender, EventArgs e)
        {
            BindDatabases();
        }
        /// <summary>
        /// 生成模型
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_model_Click(object sender, EventArgs e)
        {
            
            string dbName = cb_dbs.SelectedValue.ToString();
            string tableName = cb_tables.SelectedValue.ToString();
            DataTable dt = MySqlDbHelper.GetTableColums(dbName,tableName);
            StringBuilder result = new StringBuilder();
            result.Append($"namespace {tb_namespace.Text.Trim()}\r\n");
            result.Append($"{{ \r\n");
            result.Append(" ".repeat(4)+$"public class {tableName}\r\n");
            result.Append(" ".repeat(4) + $"{{ \r\n");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var ss = appSetting["DataTypeComtrast"].Children()["Mysql"];
                string typeString = ss.Values(dt.Rows[i]["数据类型"] + "").FirstOrDefault().ToString();

                result.Append(" ".repeat(8)+"///<summary>\r\n");
                result.Append(" ".repeat(8)+"///" + dt.Rows[i]["注释"] + "\r\n");
                result.Append(" ".repeat(8)+"///</summary>\r\n");
                result.Append(" ".repeat(8)+"public " + typeString + " " + dt.Rows[i]["列名"] + " { get; set; }\r\n");
                result.Append(" ".repeat(8) + "\r\n");

            }
            result.Append(" ".repeat(4)+$"}} \r\n");
            result.Append($"}} \r\n");
            tb_result.Text = result.ToString();
        }
        /// <summary>
        /// 变更数据库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cb_dbs_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindTables();
        }

        #region 公共方法
        /// <summary>
        /// 绑定数据库下拉框
        /// </summary>
        private void BindDatabases()
        {
            DataTable dt = MySqlDbHelper.GetDataBases();
            cb_dbs.DataSource = dt;
            cb_dbs.ValueMember = "Database";
            cb_dbs.DisplayMember = "Database";
        }
        /// <summary>
        /// 绑定数据表下拉框
        /// </summary>
        private void BindTables()
        {
            DataTable dt = MySqlDbHelper.GetTables(cb_dbs.SelectedValue.ToString());
            cb_tables.DataSource = dt;
            cb_tables.ValueMember = "TABLE_NAME";
            cb_tables.DisplayMember = "TABLE_NAME";
        }
        private string CreateModel(string dbName,string tableName)
        {
            DataTable dt = MySqlDbHelper.GetTableColums(dbName, tableName);
            StringBuilder result = new StringBuilder();
            result.Append($"using System; \r\n");
            result.Append($"namespace {tb_namespace.Text.Trim()}\r\n");
            result.Append($"{{ \r\n");
            result.Append(" ".repeat(4) + $"public class {tableName}\r\n");
            result.Append(" ".repeat(4) + $"{{ \r\n");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                //var ss = appSetting["DataTypeComtrast"].Children()["Mysql"];
                string typeString = GetTypeString(dt.Rows[i]);

                result.Append(" ".repeat(8) + "///<summary>\r\n");
                result.Append(" ".repeat(8) + "///" + dt.Rows[i]["注释"] + "\r\n");
                result.Append(" ".repeat(8) + "///</summary>\r\n");
                result.Append(" ".repeat(8) + "public " + typeString + " " + dt.Rows[i]["列名"] + " { get; set; }\r\n");
                result.Append(" ".repeat(8) + "\r\n");

            }
            result.Append(" ".repeat(4) + $"}} \r\n");
            result.Append($"}} \r\n");
            return result.ToString();
        }

        private string SplitCols(DataTable dt)
        {
            StringBuilder res = new StringBuilder();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                res.Append($"{dt.Rows[i]["列名"]},");
            }
            return res.ToString().TrimEnd(',');
        }
        private string SplitValues(DataTable dt)
        {
            StringBuilder res = new StringBuilder();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                res.Append($"@{dt.Rows[i]["列名"]},");
            }
            return res.ToString().TrimEnd(',');
        }

        private string SplitParams(DataTable dt)
        {
            StringBuilder res = new StringBuilder();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                res.Append(" ".repeat(12) + $"new MySqlParameter(\"@{dt.Rows[i]["列名"]}\",model.{dt.Rows[i]["列名"]}),\r\n");
            }
            return res.ToString().TrimEnd(',');
        }
        /// <summary>
        /// 传入列，获取对应.net的类型
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        private string GetTypeString(DataRow dr)
        {
            var ss = appSetting["DataTypeComtrast"].Children()["Mysql"];
            string typeString = ss.Values(dr["数据类型"] + "").FirstOrDefault().ToString();

            //判断是否可空
            string[] addNullArray = new string[] { "int", "DateTime" };
            if (addNullArray.Contains(typeString)&&dr["是否为空"] + ""=="YES")
            {
                typeString += "?";
            }

            return typeString;
        }
        #endregion

        /// <summary>
        /// 批量导出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_forfolder_Click(object sender, EventArgs e)
        {
            string dbName = cb_dbs.SelectedValue.ToString();
            string folderPath = Application.StartupPath+"\\pl";
            FileHelper.ClearFolder(folderPath);//清空文件夹

            FileHelper.CreateDirectory($"{folderPath}\\Model");
            DataTable tables = MySqlDbHelper.GetTables(dbName);
            for (int i = 0; i < tables.Rows.Count; i++)
            {
                string tableName = tables.Rows[i]["TABLE_NAME"].ToString();
                string filePath = $"{folderPath}\\Model\\{tableName}.cs";
                //FileHelper.Create(filePath);
                FileHelper.OpenWrite(filePath, CreateModel(dbName, tableName));
            }
            tb_result.Text+="批量导出成功";
        }

        private void btn_dal_Click(object sender, EventArgs e)
        {
            string dbName = cb_dbs.SelectedValue.ToString();
            string tableName = cb_tables.SelectedValue.ToString();
            DataTable dt = MySqlDbHelper.GetTableColums(dbName, tableName);
            #region 获取主键行
            //暂不适应多主键
            DataRow priRow=null;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["KEY"] + "" == "PRI")
                {
                    priRow = dt.Rows[i];
                    break;
                }
            }
            if (priRow==null)
            {
                return;
            }
            #endregion
            
            StringBuilder result = new StringBuilder();
            result.Append($"namespace {tb_namespace.Text.Trim()}\r\n");
            result.Append($"{{ \r\n");
            result.Append($"[UseDI(ServiceLifetime.Scoped, typeof({tableName}DAL))] \r\n");
            result.Append(" ".repeat(4) + $"public class {tableName}DAL:BasicDAL\r\n");
            result.Append(" ".repeat(4) + $"{{ \r\n");
            result.Append(" ".repeat(4) + $"public Common.DataHelper.MySqlHelper mysql;\r\n");
            result.Append(" ".repeat(4) + $"public {tableName}DAL(Common.DataHelper.MySqlHelper _mysql) \r\n");
            result.Append(" ".repeat(4) + $"{{ \r\n");
            result.Append(" ".repeat(8) + $"mysql=_mysql; \r\n");
            result.Append(" ".repeat(4) + $"}} \r\n");

            #region insert
            result.Append(" ".repeat(4) + $"/// <summary> \r\n");
            result.Append(" ".repeat(4) + $"/// 插入数据 \r\n");
            result.Append(" ".repeat(4) + $"/// </summary> \r\n");
            result.Append(" ".repeat(4) + $"public bool Insert({tableName} model) \r\n");
            result.Append(" ".repeat(4) + $"{{ \r\n");
            result.Append(" ".repeat(8) + $"StringBuilder sqlStr = new StringBuilder(); \r\n");
            result.Append(" ".repeat(8) + $"sqlStr.Append(\" INSERT INTO {tableName} \"); \r\n");
            result.Append(" ".repeat(8) + $"sqlStr.Append(\" ({SplitCols(dt)}) \"); \r\n");
            result.Append(" ".repeat(8) + $"sqlStr.Append(\" VALUES({SplitValues(dt)}) \");  \r\n");
            result.Append(" ".repeat(8) + $"MySqlParameter[] param = new MySqlParameter[] {{ \r\n");
            result.Append(" ".repeat(8) + $"{SplitParams(dt)}  \r\n");
            result.Append(" ".repeat(8) + $"}};\r\n");
            result.Append(" ".repeat(8) + $"int count = mysql.ExecuteSql(sqlStr.ToString(), param); \r\n");
            result.Append(" ".repeat(8) + $"return count>0;\r\n");
            result.Append(" ".repeat(4) + $"}} \r\n");
            #endregion
            #region update
            StringBuilder updateWhereStr = new StringBuilder();
            result.Append(" ".repeat(4) + $"/// <summary> \r\n");
            result.Append(" ".repeat(4) + $"/// 修改数据 \r\n");
            result.Append(" ".repeat(4) + $"/// </summary> \r\n");
            result.Append(" ".repeat(4) + $"public bool Update({tableName} model) \r\n");
            result.Append(" ".repeat(4) + $"{{ \r\n");
            result.Append(" ".repeat(8) + $"StringBuilder updateStr = new StringBuilder(); \r\n");
            result.Append(" ".repeat(8) + $"List<MySqlParameter> paramList = new List<MySqlParameter>(); \r\n");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["KEY"]+""=="PRI")
                {
                    updateWhereStr.Append($" {dt.Rows[i]["列名"]} = @{dt.Rows[i]["列名"]} and");
                    result.Append($"paramList.Add(new MySqlParameter(\"@{dt.Rows[i]["列名"]}\", model.{dt.Rows[i]["列名"]}));");
                }
                else
                {
                    result.Append(" ".repeat(8) + $"if (model.{dt.Rows[i]["列名"]} != null){{updateStr.Append(\" {dt.Rows[i]["列名"]}=@{dt.Rows[i]["列名"]},\");paramList.Add(new MySqlParameter(\"@{dt.Rows[i]["列名"]}\", model.{dt.Rows[i]["列名"]})); }} \r\n");
                }
            }
            result.Append(" ".repeat(8) + $"StringBuilder sqlStr = new StringBuilder(); \r\n");
            result.Append(" ".repeat(8) + $"sqlStr.Append(\" UPDATE {tableName} \"); \r\n");
            result.Append(" ".repeat(8) + $"sqlStr.Append(\" SET  \"); \r\n");
            result.Append(" ".repeat(8) + $"sqlStr.Append(updateStr.ToString().TrimEnd(',')); \r\n");
            result.Append(" ".repeat(8) + $"sqlStr.Append(\" WHERE {updateWhereStr.ToString().Substring(0, updateWhereStr.Length-3)} \"); \r\n");
            result.Append(" ".repeat(8) + $"int count = mysql.ExecuteSql(sqlStr.ToString(), paramList.ToArray()); \r\n");
            result.Append(" ".repeat(8) + $"return count > 0; \r\n");
            result.Append(" ".repeat(4) + $"}} \r\n");
            #endregion
            #region delete
            result.Append(" ".repeat(4) + $"/// <summary> \r\n");
            result.Append(" ".repeat(4) + $"/// 删除单条数据 \r\n");
            result.Append(" ".repeat(4) + $"/// </summary> \r\n");
            result.Append(" ".repeat(4) + $"public bool Delete({GetTypeString(priRow)} {priRow["列名"]}) \r\n");
            result.Append(" ".repeat(4) + $"{{ \r\n");
            result.Append(" ".repeat(8) + $"StringBuilder sqlStr = new StringBuilder(); \r\n");
            result.Append(" ".repeat(8) + $"sqlStr.Append(\" DELETE FROM {tableName} \"); \r\n");
            result.Append(" ".repeat(8) + $"sqlStr.Append(\" WHERE {priRow["列名"]} = @{priRow["列名"]} \"); \r\n");
            result.Append(" ".repeat(8) + $"MySqlParameter[] param = new MySqlParameter[] {{ \r\n");
            result.Append(" ".repeat(8) + $"    new MySqlParameter(\"@{priRow["列名"]}\",{priRow["列名"]})  \r\n");
            result.Append(" ".repeat(8) + $"}};\r\n");
            result.Append(" ".repeat(8) + $"int count = mysql.ExecuteSql(sqlStr.ToString(), param); \r\n");
            result.Append(" ".repeat(8) + $"return count>0;\r\n");
            result.Append(" ".repeat(4) + $"}} \r\n");
            #endregion
            #region GetModel
            result.Append(" ".repeat(4) + $"/// <summary> \r\n");
            result.Append(" ".repeat(4) + $"/// 根据主键获取单条数据 \r\n");
            result.Append(" ".repeat(4) + $"/// </summary> \r\n");
            result.Append(" ".repeat(4) + $"public DataTable GetModel({GetTypeString(priRow)} {priRow["列名"]}) \r\n");
            result.Append(" ".repeat(4) + $"{{ \r\n");
            result.Append(" ".repeat(8) + $"StringBuilder sqlStr = new StringBuilder(); \r\n");
            result.Append(" ".repeat(8) + $"sqlStr.Append(\" SELECT * FROM {tableName} \"); \r\n");
            result.Append(" ".repeat(8) + $"sqlStr.Append(\" WHERE {priRow["列名"]} = @{priRow["列名"]} \"); \r\n");
            result.Append(" ".repeat(8) + $"MySqlParameter[] param = new MySqlParameter[] {{ \r\n");
            result.Append(" ".repeat(8) + $"new MySqlParameter(\"@{priRow["列名"]}\",{priRow["列名"]})  \r\n");
            result.Append(" ".repeat(8) + $"}};\r\n");
            result.Append(" ".repeat(8) + $"DataTable dt = mysql.Query(sqlStr.ToString(), param).Tables[0]; \r\n");
            result.Append(" ".repeat(8) + $"return dt;\r\n");
            result.Append(" ".repeat(4) + $"}} \r\n");
            #endregion
            #region GetList
            result.Append(" ".repeat(4) + $"/// <summary> \r\n");
            result.Append(" ".repeat(4) + $"/// 根据条件查询 \r\n");
            result.Append(" ".repeat(4) + $"/// </summary> \r\n");
            result.Append(" ".repeat(4) + $"/// <param name=\"whereStr\"></param> \r\n");
            result.Append(" ".repeat(4) + $"/// <param name=\"orderStr\"></param> \r\n");
            result.Append(" ".repeat(4) + $"/// <param name=\"param\"></param> \r\n");
            result.Append(" ".repeat(4) + $"/// <returns></returns> \r\n");
            result.Append(" ".repeat(4) + $"public DataTable GetList(string whereStr, string orderStr, MySqlParameter[] param) \r\n");
            result.Append(" ".repeat(4) + $"{{ \r\n");
            result.Append(" ".repeat(8) + $"StringBuilder sqlStr = new StringBuilder(); \r\n");
            result.Append(" ".repeat(8) + $"sqlStr.Append(\" select * from {tableName}  \"); \r\n");
            result.Append(" ".repeat(8) + $"if (!string.IsNullOrWhiteSpace(whereStr)) \r\n");
            result.Append(" ".repeat(8) + $"{{ \r\n");
            result.Append(" ".repeat(8) + $"sqlStr.Append($\" where {{whereStr}} \"); \r\n");
            result.Append(" ".repeat(8) + $"}} \r\n");
            result.Append(" ".repeat(8) + $"if (!string.IsNullOrWhiteSpace(orderStr)) \r\n");
            result.Append(" ".repeat(8) + $"{{ \r\n");
            result.Append(" ".repeat(8) + $"sqlStr.Append($\" order by {{ orderStr}} \"); \r\n");
            result.Append(" ".repeat(8) + $"}} \r\n");
            result.Append(" ".repeat(8) + $"sqlStr.Append(\"; \"); \r\n");
            result.Append(" ".repeat(8) + $"DataTable dt = mysql.Query(sqlStr.ToString(), param).Tables[0]; \r\n");
            result.Append(" ".repeat(8) + $"return dt; \r\n");
            result.Append(" ".repeat(4) + $"}} \r\n");
            #endregion
            #region GetListByPage
            result.Append(" ".repeat(4) + $"/// <summary> \r\n");
            result.Append(" ".repeat(4) + $"/// 分页获取数据 \r\n");
            result.Append(" ".repeat(4) + $"/// </summary> \r\n");
            result.Append(" ".repeat(4) + $"/// <param name=\"pageSize\"></param> \r\n");
            result.Append(" ".repeat(4) + $"/// <param name=\"pageIndex\">从0开始</param> \r\n");
            result.Append(" ".repeat(4) + $"/// <param name=\"whereStr\"></param> \r\n");
            result.Append(" ".repeat(4) + $"/// <param name=\"param\"></param> \r\n");
            result.Append(" ".repeat(4) + $"/// <returns></returns> \r\n");
            result.Append(" ".repeat(4) + $"public DataTable GetListByPage(int pageSize, int pageIndex, string whereStr, string orderStr, MySqlParameter[] param, out int total) \r\n");
            result.Append(" ".repeat(4) + $"{{ \r\n");
            result.Append(" ".repeat(8) + $"StringBuilder sqlStr = new StringBuilder(); \r\n");
            result.Append(" ".repeat(8) + $"sqlStr.Append(\" SELECT SQL_CALC_FOUND_ROWS * FROM {tableName} \"); \r\n");
            result.Append(" ".repeat(8) + $"if (!string.IsNullOrWhiteSpace(whereStr)) \r\n");
            result.Append(" ".repeat(8) + $"{{ \r\n");
            result.Append(" ".repeat(8) + $"sqlStr.Append($\" where {{whereStr}} \"); \r\n");
            result.Append(" ".repeat(8) + $"}} \r\n");
            result.Append(" ".repeat(8) + $"if (!string.IsNullOrWhiteSpace(orderStr)) \r\n");
            result.Append(" ".repeat(8) + $"{{ \r\n");
            result.Append(" ".repeat(8) + $"sqlStr.Append($\" order by {{ orderStr}} \"); \r\n");
            result.Append(" ".repeat(8) + $"}} \r\n");
            result.Append(" ".repeat(8) + $"sqlStr.Append($\" LIMIT {{ pageSize* pageIndex}},{{ pageSize}}; \");  \r\n");
            result.Append(" ".repeat(8) + $"sqlStr.Append(\" SELECT FOUND_ROWS(); \"); \r\n");
            result.Append(" ".repeat(8) + $"DataSet ds = mysql.Query(sqlStr.ToString(), param);  \r\n");
            result.Append(" ".repeat(8) + $"DataTable dt = ds.Tables[0]; \r\n");
            result.Append(" ".repeat(8) + $"DataTable totalRowsDt = ds.Tables[1]; \r\n");
            result.Append(" ".repeat(8) + $"total = Convert.ToInt32(totalRowsDt.Rows[0][\"FOUND_ROWS()\"]); \r\n");
            result.Append(" ".repeat(8) + $"return dt; \r\n");
            result.Append(" ".repeat(4) + $"}} \r\n");
            #endregion
            result.Append($"}} \r\n");
            result.Append($"}} \r\n");
            tb_result.Text = result.ToString();
        }

       
    }
}
