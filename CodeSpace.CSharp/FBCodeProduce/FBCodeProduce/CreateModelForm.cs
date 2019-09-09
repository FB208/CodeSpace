using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DBUtility;
using DLL.DBUtility;
using FBCodeProduce.Tools;

namespace FBCodeProduce
{
    public partial class CreateModelForm : Form
    {
        public CreateModelForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 初始化页面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateModelForm_Load(object sender, EventArgs e)
        {
            try
            {
                ConnectDataBaseAndBind();
            }
            catch (Exception)
            {

                MessageBox.Show("默认数据库连接失败，请手动指定");
            }
            
        }

        /// <summary>
        /// 生成模型
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_CreateModel_Click(object sender, EventArgs e)
        {
            string tablename = cb_Tables.SelectedValue.ToString();
            DataTable dt = DatabaseHelper.GetTableColums(tablename);
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string typeString = IniHelper.GetValue("数据库类型对照", dt.Rows[i]["Type"] + "");
                result.Append("///<summary>\r\n");
                result.Append("///" + dt.Rows[i]["Remark"] + "\r\n");
                result.Append("///</summary>\r\n");
                result.Append("public " + typeString + " " + dt.Rows[i]["ColumnName"] + " { get; set; }\r\n");

            }
            tb_Result.Text = result.ToString();

        }

        /// <summary>
        /// 链接数据库并获取数据表
        /// </summary>
        private void ConnectDataBaseAndBind()
        {
            string databaseName = tb_DatabaseName.Text;
            DataTable dt = DatabaseHelper.GetTables(databaseName);
            cb_Tables.DataSource = dt;
            cb_Tables.ValueMember = "name";
            cb_Tables.DisplayMember = "name";

        }

        /// <summary>
        /// 链接数据库并获取数据表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_connect_Click(object sender, EventArgs e)
        {
            ConnectDataBaseAndBind();
        }
        /// <summary>
        /// 插入模型代码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Insert_Click(object sender, EventArgs e)
        {
            string tablename = cb_Tables.SelectedValue.ToString();
            
            string colums = "(";
            string values = "VALUES (";
            DataTable dt = DatabaseHelper.GetTableColums(tablename);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                colums += "["+dt.Rows[i]["ColumnName"] + "],";
                values += "'\"+model."+dt.Rows[i]["ColumnName"]+"+\"',";
            }
            colums = colums.TrimEnd(',') + ")";
            values = values.TrimEnd(',') + ")";
            StringBuilder result = new StringBuilder();
            result.Append("sql.Append(\" INSERT INTO " + tablename + " \");\r\n");
            result.Append("sql.Append(\" " + colums + " \");\r\n");
            result.Append("sql.Append(\" " + values + " \");\r\n");
            tb_Result.Text = result.ToString();
        }

        private void Ctrl_A(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\x1')
            {
                ((TextBox)sender).SelectAll();
                e.Handled = true;
            }
        }
        /// <summary>
        /// 更新模型代码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Update_Click(object sender, EventArgs e)
        {
            string tablename = cb_Tables.SelectedValue.ToString();
            DataTable dt = DatabaseHelper.GetTableColums(tablename);
            
            StringBuilder result = new StringBuilder();
            result.Append("sql.Append(\" UPDATE "+tablename+" SET \");\r\n");
            string primaryKey = "";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                result.Append("sql.Append(\" [" + dt.Rows[i]["ColumnName"] + "]='\"+model." + dt.Rows[i]["ColumnName"] + "+\" ', \");\r\n");
                //最后一行没逗号
                if (i==dt.Rows.Count-1)
                {
                    result.Append("sql.Append(\" [" + dt.Rows[i]["ColumnName"] + "]='\"+model." + dt.Rows[i]["ColumnName"] + "+\" ' \");\r\n");
                }
                //保存主键
                if (dt.Rows[i]["IsPK"].ToString()=="1")
                {
                    primaryKey = dt.Rows[i]["ColumnName"] + "";
                }
            }

            result.Append("sql.Append(\" WHERE " + primaryKey + " = '\" + model." + primaryKey + " + \"' \");");

     
            tb_Result.Text = result.ToString();
        }
        /// <summary>
        /// 控件赋值给模型
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ControlToModel_Click(object sender, EventArgs e)
        {
            
        }

        private void Btn_ModelToControl_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 数据字典
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_OpenDictionary_Click(object sender, EventArgs e)
        {
            DataDictionary form = new DataDictionary();
            form.DataBaseName = tb_DatabaseName.Text;
            form.Show();
        }
        /// <summary>
        /// 利用SqlParameter插入数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_InsertParameter_Click(object sender, EventArgs e)
        {
            string tablename = cb_Tables.SelectedValue.ToString();

            string colums = "(";
            string values = "VALUES (";
            string par = "SqlParameter[] par = {\r\n";
            string parVal = "";
            DataTable dt = DatabaseHelper.GetTableColums(tablename);
            DataTable dt_TableDate = DbHelper.Query("select Top 1 * from " + tablename).Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                colums += "[" + dt.Rows[i]["ColumnName"] + "],";
                values += "@" + dt.Rows[i]["ColumnName"] + ",";
                par += string.Format("\r\n new SqlParameter(\"@{0}\",{1}),//{2}", dt.Rows[i]["ColumnName"], DBTypeHelper.GetDbType(dt_TableDate.Columns[dt.Rows[i]["ColumnName"] + ""].DataType),i);
                parVal += string.Format("par_StarFlowDetail[{0}].Value = dt_MainReq_StarFlowDetail.Rows[i][\"{1}\"];\r\n", i, dt.Rows[i]["ColumnName"]);
            } 
            colums = colums.TrimEnd(',') + ")";
            values = values.TrimEnd(',') + ")";
            par = par.TrimEnd(',') + "\r\n};";
            StringBuilder result = new StringBuilder();
            result.Append("sql.Append(\" INSERT INTO " + tablename + " \");\r\n");
            result.Append("sql.Append(\" " + colums + " \");\r\n");
            result.Append("sql.Append(\" " + values + " \");\r\n");
            result.Append("\r\n\r\n\r\n");
            result.Append(par);
            result.Append("\r\n\r\n\r\n");
            result.Append(parVal);
            tb_Result.Text = result.ToString();
        }
    }
}
