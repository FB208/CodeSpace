using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DBUtility;

namespace FBCodeProduce
{
    public partial class DbSearchForm : Form
    {
        Models.DbSearchModel sModel;
        public DbSearchForm()
        {
            sModel = new Models.DbSearchModel();
            InitializeComponent();
        }

        private void DbSearchForm_Load(object sender, EventArgs e)
        {
            
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            try
            {
                string text = tb_SearchTxt.Text;//=oldValue
                string newValue = tb_NewValue.Text;
                string result = "";
                string selectStr = "";
                string updateStr = "";
                sModel.IsLike = cb_IsLike.Checked;
                DataTable dt_Tables = DbHelper.Query(" SELECT Name FROM SysObjects Where XType='U' ORDER BY Name").Tables[0];
                for (int i = 0; i < dt_Tables.Rows.Count; i++)
                {
                    string tableName = dt_Tables.Rows[i]["Name"] + "";
                    DataTable dt_cols = DbHelper.Query(" sp_help [" + tableName + "]").Tables[1];
                    for (int j = 0; j < dt_cols.Rows.Count; j++)
                    {
                        if (dt_cols.Rows[j]["Type"].ToString() == "nvarchar" || dt_cols.Rows[j]["Type"].ToString() == "varchar")
                        {

                            string colName = dt_cols.Rows[j]["Column_name"] + "";
                            string searchSql = GetSearchSelectSqlString(tableName, colName, text);



                            DataTable dt_SearchResults = DbHelper.Query(searchSql).Tables[0];
                            if (dt_SearchResults != null && dt_SearchResults.Rows.Count > 0)
                            {
                                result += "【" + tableName + "|" + colName + "】" + " \r\n";
                                selectStr += PushSelectSqlString(tableName, colName, text);
                                updateStr += PushUpdateSqlString(tableName, colName, text, newValue);
                            }
                        }
                    }
                }
                tb_SearchResult.Text = result;
                AppDomain.CurrentDomain.SetData("DbSearchForm_Result", result);
                AppDomain.CurrentDomain.SetData("DbSearchForm_Select", selectStr);
                AppDomain.CurrentDomain.SetData("DbSearchForm_Update", updateStr);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }
        private void btn_select_Click(object sender, EventArgs e)
        {
            
            tb_SearchResult.Text = AppDomain.CurrentDomain.GetData("DbSearchForm_Select")?.ToString();
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            tb_SearchResult.Text = AppDomain.CurrentDomain.GetData("DbSearchForm_Update")?.ToString();
        }

        private void btn_Result_Click(object sender, EventArgs e)
        {
            tb_SearchResult.Text = AppDomain.CurrentDomain.GetData("DbSearchForm_Result")?.ToString();
        }


        #region 私有方法
        private string GetSearchSelectSqlString(string tableName, string colName, string searchValue)
        {
            string returnStr = "";
            if (sModel.IsLike)
            {
                returnStr = $" SELECT * FROM [{tableName}] WHERE [{colName}] LIKE '%{searchValue}%' ";
            }
            else
            {
                returnStr = $" SELECT * FROM [{tableName}] WHERE [{colName}] = '{searchValue}' ";
            }
            return returnStr;
        }
        private string PushUpdateSqlString(string tableName, string colName, string searchValue, string newValue)
        {
            string returnStr = "";
            if (sModel.IsLike)
            {
                returnStr = $"UPDATE {tableName} SET {colName}='{newValue}' WHERE {colName} like '%{searchValue}%'  \r\n";
            }
            else
            {
                returnStr = $"UPDATE {tableName} SET {colName}='{newValue}' WHERE {colName} = '{searchValue}'  \r\n";
            }
            return returnStr;
        }
        private string PushSelectSqlString(string tableName, string colName, string searchValue)
        {
            string returnStr = "";
            if (sModel.IsLike)
            {
                returnStr = $" SELECT {colName},* FROM {tableName} WHERE {colName} like '%{searchValue}%' \r\n";
            }
            else
            {
                returnStr = $" SELECT {colName},* FROM {tableName} WHERE {colName} = '{searchValue}' \r\n";
            }
            return returnStr;
        }
        #endregion



    }
}
