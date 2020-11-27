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
            result.Append($"namespace {tb_namespace.Text.Trim()}.Model\r\n");
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
        private string CreateDAL(string dbName,string tableName)
        {
            DataTable dt = MySqlDbHelper.GetTableColums(dbName, tableName);
            bool isView = false;
            #region 获取主键行
            //暂不适应多主键
            DataRow priRow = null;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["KEY"] + "" == "PRI")
                {
                    priRow = dt.Rows[i];
                    break;
                }
            }
            if (priRow == null)
            {
                isView = true;
                //return "";
            }
            #endregion

            StringBuilder result = new StringBuilder();
            #region 必要引用
            result.Append("using System; \r\n");
            result.Append("using System.Text; \r\n");
            result.Append("using System.Data; \r\n");
            result.Append("using System.Collections.Generic; \r\n");
            result.Append("using MySql.Data.MySqlClient; \r\n");
            result.Append("using Microsoft.Extensions.DependencyInjection; \r\n");
            result.Append("using DLL.Basic; \r\n");
            result.Append("using DLL.Model; \r\n");
            result.Append("using Common.IOCHelper; \r\n");
            #endregion




            result.Append($"namespace {tb_namespace.Text.Trim()}.DAL\r\n");
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
            if (!isView)
            {
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
            }
            
            #endregion
            #region update
            StringBuilder updateWhereStr = new StringBuilder();
            if (!isView)
            {
                result.Append(" ".repeat(4) + $"/// <summary> \r\n");
                result.Append(" ".repeat(4) + $"/// 修改数据 \r\n");
                result.Append(" ".repeat(4) + $"/// </summary> \r\n");
                result.Append(" ".repeat(4) + $"public bool Update({tableName} model) \r\n");
                result.Append(" ".repeat(4) + $"{{ \r\n");
                result.Append(" ".repeat(8) + $"StringBuilder updateStr = new StringBuilder(); \r\n");
                result.Append(" ".repeat(8) + $"List<MySqlParameter> paramList = new List<MySqlParameter>(); \r\n");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["KEY"] + "" == "PRI")
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
                result.Append(" ".repeat(8) + $"sqlStr.Append(\" WHERE {updateWhereStr.ToString().Substring(0, updateWhereStr.Length - 3)} \"); \r\n");
                result.Append(" ".repeat(8) + $"int count = mysql.ExecuteSql(sqlStr.ToString(), paramList.ToArray()); \r\n");
                result.Append(" ".repeat(8) + $"return count > 0; \r\n");
                result.Append(" ".repeat(4) + $"}} \r\n");
            }

            #endregion
            #region delete
            if (!isView)
            {
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
            }


            #endregion
            #region GetModel
            if (!isView)
            {
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
            }
            
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

            return result.ToString();
        }
        private string CreateBLL(string dbName, string tableName)
        {
            DataTable dt = MySqlDbHelper.GetTableColums(dbName, tableName);
            bool isView = false;
            #region 获取主键行
            //暂不适应多主键
            DataRow priRow = null;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["KEY"] + "" == "PRI")
                {
                    priRow = dt.Rows[i];
                    break;
                }
            }
            if (priRow == null)
            {
                isView = true;
                //  return "";
            }
            #endregion

            StringBuilder result = new StringBuilder();
            #region 必要引用
            result.Append(" using System.Data; \r\n");
            result.Append(" using System.Collections.Generic; \r\n");
            result.Append(" using MySql.Data.MySqlClient; \r\n");
            result.Append(" using Microsoft.Extensions.DependencyInjection; \r\n");
            result.Append(" using DLL.Basic; \r\n");
            result.Append(" using DLL.Model; \r\n");
            result.Append(" using DLL.DAL; \r\n");
            result.Append(" using Common.DataHelper; \r\n");
            result.Append(" using Common.IOCHelper; \r\n");

            #endregion
            result.Append($"namespace {tb_namespace.Text.Trim()}.BLL\r\n");
            result.Append($"{{ \r\n");
            result.Append($"[UseDI(ServiceLifetime.Scoped, typeof({tableName}BLL))] \r\n");
            result.Append(" ".repeat(4) + $"public class {tableName}BLL:BasicBLL\r\n");
            result.Append(" ".repeat(4) + $"{{ \r\n");
            result.Append(" ".repeat(4) + $"private {tableName}DAL dal;\r\n");
            result.Append(" ".repeat(4) + $"public {tableName}BLL({tableName}DAL _dal) \r\n");
            result.Append(" ".repeat(4) + $"{{ \r\n");
            result.Append(" ".repeat(8) + $"dal=_dal; \r\n");
            result.Append(" ".repeat(4) + $"}} \r\n");

            #region insert
            if (!isView)
            {
                result.Append(" ".repeat(4) + $" /// <summary> \r\n");
                result.Append(" ".repeat(4) + $" /// 插入一条记录 \r\n");
                result.Append(" ".repeat(4) + $" /// </summary> \r\n");
                result.Append(" ".repeat(4) + $" /// <param name=\"model\"></param> \r\n");
                result.Append(" ".repeat(4) + $" /// <returns></returns> \r\n");
                result.Append(" ".repeat(4) + $" public bool Insert({tableName} model) \r\n");
                result.Append(" ".repeat(4) + $" {{ \r\n");
                result.Append(" ".repeat(4) + $" return dal.Insert(model); \r\n");
                result.Append(" ".repeat(4) + $" }} \r\n");

            }
            #endregion
            #region update
            if (!isView)
            {
                result.Append(" ".repeat(4) + $" /// <summary> \r\n");
                result.Append(" ".repeat(4) + $" /// 修改记录 \r\n");
                result.Append(" ".repeat(4) + $" /// </summary> \r\n");
                result.Append(" ".repeat(4) + $" /// <param name=\"model\"></param> \r\n");
                result.Append(" ".repeat(4) + $" /// <returns></returns> \r\n");
                result.Append(" ".repeat(4) + $" public bool Update({tableName} model) \r\n");
                result.Append(" ".repeat(4) + $" {{ \r\n");
                result.Append(" ".repeat(4) + $" return dal.Update(model); \r\n");
                result.Append(" ".repeat(4) + $" }} \r\n");
            }
            #endregion
            #region delete
            if (!isView)
            {
                result.Append(" ".repeat(4) + $" /// <summary> \r\n");
                result.Append(" ".repeat(4) + $" /// 删除记录 \r\n");
                result.Append(" ".repeat(4) + $" /// </summary> \r\n");
                result.Append(" ".repeat(4) + $" /// <param name=\"model\"></param> \r\n");
                result.Append(" ".repeat(4) + $" /// <returns></returns> \r\n");
                result.Append(" ".repeat(4) + $" public bool Delete({GetTypeString(priRow)} {priRow["列名"]}) \r\n");
                result.Append(" ".repeat(4) + $" {{ \r\n");
                result.Append(" ".repeat(4) + $" return dal.Delete({priRow["列名"]}); \r\n");
                result.Append(" ".repeat(4) + $" }} \r\n");
            }
            #endregion
            #region GetModel
            if (!isView)
            {
                result.Append(" ".repeat(4) + $" /// <summary> \r\n");
                result.Append(" ".repeat(4) + $" /// 根据唯一标识获取实体数据 \r\n");
                result.Append(" ".repeat(4) + $" /// </summary> \r\n");
                result.Append(" ".repeat(4) + $" public {tableName} GetModel({GetTypeString(priRow)} {priRow["列名"]}) \r\n");
                result.Append(" ".repeat(4) + $" {{ \r\n");
                result.Append(" ".repeat(4) + $" return dal.GetModel({priRow["列名"]}).ToDataEntity<{tableName}>(); \r\n");
                result.Append(" ".repeat(4) + $" }} \r\n");
            }
            #endregion
            #region GetList
            result.Append(" ".repeat(4) + $" /// <summary> \r\n");
            result.Append(" ".repeat(4) + $" /// 根据条件查询 \r\n");
            result.Append(" ".repeat(4) + $" /// </summary> \r\n");
            result.Append(" ".repeat(4) + $" /// <param name=\"whereStr\"></param> \r\n");
            result.Append(" ".repeat(4) + $" /// <param name=\"orderStr\"></param> \r\n");
            result.Append(" ".repeat(4) + $" /// <param name=\"param\"></param> \r\n");
            result.Append(" ".repeat(4) + $" /// <returns></returns> \r\n");
            result.Append(" ".repeat(4) + $" public List<{tableName}> GetList(string whereStr, string orderStr, MySqlParameter[] param=null) \r\n");
            result.Append(" ".repeat(4) + $" {{ \r\n");
            result.Append(" ".repeat(8) + $" DataTable dt = dal.GetList(whereStr, orderStr, param); \r\n");
            result.Append(" ".repeat(8) + $" List<{tableName}> list = new List<{tableName}>(); \r\n");
            result.Append(" ".repeat(8) + $" if (dt.Rows.Count > 0) \r\n");
            result.Append(" ".repeat(8) + $" {{ \r\n");
            result.Append(" ".repeat(12) + $" list = dt.ToDataList<{tableName}>(); \r\n");
            result.Append(" ".repeat(8) + $" }} \r\n");
            result.Append(" ".repeat(8) + $" return list; \r\n");
            result.Append(" ".repeat(4) + $" }} \r\n");
            result.Append(" ".repeat(4) + $" /// <summary> \r\n");
            result.Append(" ".repeat(4) + $" /// 根据条件查询 \r\n");
            result.Append(" ".repeat(4) + $" /// </summary> \r\n");
            result.Append(" ".repeat(4) + $" /// <param name=\"whereStr\"></param> \r\n");
            result.Append(" ".repeat(4) + $" /// <param name=\"orderStr\"></param> \r\n");
            result.Append(" ".repeat(4) + $" /// <param name=\"model\"></param> \r\n");
            result.Append(" ".repeat(4) + $" /// <returns></returns> \r\n");
            result.Append(" ".repeat(4) + $" public List<{tableName}> GetList(string whereStr, string orderStr, {tableName} model) \r\n");
            result.Append(" ".repeat(4) + $" {{ \r\n");
            result.Append(" ".repeat(8) + $" DataTable dt = dal.GetList(whereStr, orderStr, this.ModelToParams(whereStr,model)); \r\n");
            result.Append(" ".repeat(8) + $" List<{tableName}> list = new List<{tableName}>(); \r\n");
            result.Append(" ".repeat(8) + $" if (dt.Rows.Count > 0) \r\n");
            result.Append(" ".repeat(8) + $" {{ \r\n");
            result.Append(" ".repeat(12) + $" list = dt.ToDataList<{tableName}>(); \r\n");
            result.Append(" ".repeat(8) + $" }} \r\n");
            result.Append(" ".repeat(8) + $" return list; \r\n");
            result.Append(" ".repeat(4) + $" }} \r\n");


            #endregion
            #region GetListByPage
            result.Append(" ".repeat(4) + $" /// <summary> \r\n");
            result.Append(" ".repeat(4) + $" ///  分页获取数据 \r\n");
            result.Append(" ".repeat(4) + $" /// </summary> \r\n");
            result.Append(" ".repeat(4) + $" /// <param name=\"pageSize\"></param> \r\n");
            result.Append(" ".repeat(4) + $" /// <param name=\"pageIndex\">从1开始</param> \r\n");
            result.Append(" ".repeat(4) + $" /// <param name=\"whereStr\"></param> \r\n");
            result.Append(" ".repeat(4) + $" /// <param name=\"orderStr\"></param> \r\n");
            result.Append(" ".repeat(4) + $" /// <param name=\"param\"></param> \r\n");
            result.Append(" ".repeat(4) + $" /// <param name=\"total\"></param> \r\n");
            result.Append(" ".repeat(4) + $" /// <returns></returns> \r\n");
            result.Append(" ".repeat(4) + $" public List<{tableName}> GetListByPage(int pageSize, int pageIndex, string whereStr, string orderStr, MySqlParameter[] param, out int total) \r\n");
            result.Append(" ".repeat(4) + $" {{ \r\n");
            result.Append(" ".repeat(8) + $" DataTable dt = dal.GetListByPage(pageSize, pageIndex - 1, whereStr, orderStr, param, out total); \r\n");
            result.Append(" ".repeat(8) + $" List<{tableName}> list = new List<{tableName}>(); \r\n");
            result.Append(" ".repeat(8) + $" if (dt.Rows.Count > 0) \r\n");
            result.Append(" ".repeat(8) + $" {{ \r\n");
            result.Append(" ".repeat(12) + $" list = dt.ToDataList<{tableName}>(); \r\n");
            result.Append(" ".repeat(8) + $" }} \r\n");
            result.Append(" ".repeat(8) + $" return list; \r\n");
            result.Append(" ".repeat(4) + $" }} \r\n");
            result.Append(" ".repeat(4) + $" /// <summary> \r\n");
            result.Append(" ".repeat(4) + $" ///  分页获取数据 \r\n");
            result.Append(" ".repeat(4) + $" /// </summary> \r\n");
            result.Append(" ".repeat(4) + $" /// <param name=\"pageSize\"></param> \r\n");
            result.Append(" ".repeat(4) + $" /// <param name=\"pageIndex\">从1开始</param> \r\n");
            result.Append(" ".repeat(4) + $" /// <param name=\"whereStr\"></param> \r\n");
            result.Append(" ".repeat(4) + $" /// <param name=\"orderStr\"></param> \r\n");
            result.Append(" ".repeat(4) + $" /// <param name=\"model\"></param> \r\n");
            result.Append(" ".repeat(4) + $" /// <param name=\"total\"></param> \r\n");
            result.Append(" ".repeat(4) + $" /// <returns></returns> \r\n");
            result.Append(" ".repeat(4) + $" public List<{tableName}> GetListByPage(int pageSize, int pageIndex, string whereStr, string orderStr, {tableName} model, out int total) \r\n");
            result.Append(" ".repeat(4) + $" {{ \r\n");
            result.Append(" ".repeat(8) + $" DataTable dt = dal.GetListByPage(pageSize, pageIndex - 1, whereStr, orderStr, this.ModelToParams(whereStr, model), out total); \r\n");
            result.Append(" ".repeat(8) + $" List<{tableName}> list = new List<{tableName}>(); \r\n");
            result.Append(" ".repeat(8) + $" if (dt.Rows.Count > 0) \r\n");
            result.Append(" ".repeat(8) + $" {{ \r\n");
            result.Append(" ".repeat(12) + $" list = dt.ToDataList<{tableName}>(); \r\n");
            result.Append(" ".repeat(8) + $" }} \r\n");
            result.Append(" ".repeat(8) + $" return list; \r\n");
            result.Append(" ".repeat(4) + $" }} \r\n");

            #endregion
            result.Append($"}} \r\n");
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
            string typeString = ss.Values(dr["数据类型"] + "").FirstOrDefault()+"";

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

            DataTable tables = MySqlDbHelper.GetTables(dbName);

            FileHelper.CreateDirectory($"{folderPath}\\Model");
            FileHelper.CreateDirectory($"{folderPath}\\DAL");
            FileHelper.CreateDirectory($"{folderPath}\\BLL");
            for (int i = 0; i < tables.Rows.Count; i++)
            {
                string tableName = tables.Rows[i]["TABLE_NAME"].ToString();
                string filePath = $"{folderPath}\\Model\\{tableName}.cs";
                string filePath_DAL = $"{folderPath}\\DAL\\{tableName}DAL.cs";
                string filePath_BLL = $"{folderPath}\\BLL\\{tableName}BLL.cs";
                //FileHelper.Create(filePath);
                FileHelper.OpenWrite(filePath, CreateModel(dbName, tableName));
                FileHelper.OpenWrite(filePath_DAL, CreateDAL(dbName, tableName));
                FileHelper.OpenWrite(filePath_BLL, CreateBLL(dbName, tableName));
            }
            

            tb_result.Text+="批量导出成功";
        }

        private void btn_dal_Click(object sender, EventArgs e)
        {
            string dbName = cb_dbs.SelectedValue.ToString();
            string tableName = cb_tables.SelectedValue.ToString();
            tb_result.Text = CreateDAL(dbName, tableName);
        }

        private void btn_BLL_Click(object sender, EventArgs e)
        {
            string dbName = cb_dbs.SelectedValue.ToString();
            string tableName = cb_tables.SelectedValue.ToString();

            tb_result.Text = CreateBLL(dbName, tableName)
;        }
        #region vue
        private void btn_table_Click(object sender, EventArgs e)
        {
            string dbName = cb_dbs.SelectedValue.ToString();
            string tableName = cb_tables.SelectedValue.ToString();
            DataTable dt = MySqlDbHelper.GetTableColums(dbName, tableName);
            StringBuilder result = new StringBuilder();
            result.Append($"<el-table :data=\"{tableName}List\" stripe border fit> \r\n");
            result.Append(" ".repeat(4) + $"<el-table-column type=\"index\" label=\"序号\"></el-table-column> \r\n");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                //var ss = appSetting["DataTypeComtrast"].Children()["Mysql"];
                string typeString = GetTypeString(dt.Rows[i]);
                string label = string.IsNullOrWhiteSpace(dt.Rows[i]["注释"] + "") ? (dt.Rows[i]["注释"]+"").Split('|')[0] : dt.Rows[i]["列名"]+"";
                result.Append(" ".repeat(4) + $"<el-table-column prop=\"{dt.Rows[i]["列名"]}\" label=\"{label}\" ></el-table-column>\r\n");
            }
            result.Append(" ".repeat(4) + $"<el-table-column label=\"操作\" align=\"center\" width=\"300\"> \r\n");
            result.Append(" ".repeat(8) + $"<template> \r\n");
            result.Append(" ".repeat(12) + $"<el-button size=\"mini\" type=\"primary\">查看</el-button> \r\n");
            result.Append(" ".repeat(12) + $"<el-button size=\"mini\" type=\"success\">修改</el-button> \r\n");
            result.Append(" ".repeat(12) + $"<el-button size=\"mini\" type=\"danger\" >删除</el-button> \r\n");
            result.Append(" ".repeat(8) + $"</template> \r\n");
            result.Append(" ".repeat(4) + $"</el-table-column> \r\n");
            result.Append($"</el-table> \r\n");
            tb_result.Text = result.ToString();
        }
        private void btn_mockJson_Click(object sender, EventArgs e)
        {
            string dbName = cb_dbs.SelectedValue.ToString();
            string tableName = cb_tables.SelectedValue.ToString();
            DataTable dt = MySqlDbHelper.GetTableColums(dbName, tableName);
            StringBuilder result = new StringBuilder();
            
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                //var ss = appSetting["DataTypeComtrast"].Children()["Mysql"];
                string typeString = GetTypeString(dt.Rows[i]);
                string mockValue = "";
                switch (typeString)
                {
                    case "string":
                        mockValue = "@string";break;
                    case "int?":
                        mockValue = "@integer"; break;
                    case "DateTime?":
                        mockValue = "@date"; break;
                    default:
                        break;
                }
                result.Append($"{dt.Rows[i]["列名"]}: '{mockValue}', \r\n");
            }
            
            tb_result.Text = result.ToString();
        }

        #endregion


        #region JAVA
        /// <summary>
        /// 生成实体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_entity_Click(object sender, EventArgs e)
        {

        }
        #endregion

    }
}
