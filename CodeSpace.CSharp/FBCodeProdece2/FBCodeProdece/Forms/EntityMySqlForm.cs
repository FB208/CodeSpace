using FBCodeProduce.Forms.basic;
using FBCodeProduce.Helpers;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var ss = appSetting["DataTypeComtrast"].Children()["Mysql"];
                string typeString = ss.Values(dt.Rows[i]["数据类型"] + "").FirstOrDefault().ToString();
                result.Append("///<summary>\r\n");
                result.Append("///" + dt.Rows[i]["注释"] + "\r\n");
                result.Append("///</summary>\r\n");
                result.Append("public " + typeString + " " + dt.Rows[i]["列名"] + " { get; set; }\r\n");

            }
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
        private void BindDatabases()
        {
            DataTable dt = MySqlDbHelper.GetDataBases();
            cb_dbs.DataSource = dt;
            cb_dbs.ValueMember = "Database";
            cb_dbs.DisplayMember = "Database";
        }
        private void BindTables()
        {
            DataTable dt = MySqlDbHelper.GetTables(cb_dbs.SelectedValue.ToString());
            cb_tables.DataSource = dt;
            cb_tables.ValueMember = "TABLE_NAME";
            cb_tables.DisplayMember = "TABLE_NAME";
        }
        #endregion
    }
}
