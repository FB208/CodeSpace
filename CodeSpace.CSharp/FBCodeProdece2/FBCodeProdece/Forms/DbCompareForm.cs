
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
    public partial class DbCompareForm : Form
    {
        public DbCompareForm()
        {
            InitializeComponent();
            InitData();
        }
        public void InitData()
        {
            JToken json = NewtonjsonHelper.ReadFile(Global.USER_SETTING_PATH);
            //读取链接名称并赋值给下拉框
            List<string> serverNames1 = json["DbServer"].Children().Select(m => m.Value<string>("ServerName")).ToList();
            List<string> serverNames2 = json["DbServer"].Children().Select(m => m.Value<string>("ServerName")).ToList();
            cb_db1.DataSource = serverNames1;
            cb_db2.DataSource = serverNames2;
        }
        /// <summary>
        /// 链接数据库1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_connectDb1_Click(object sender, EventArgs e)
        {
            string databaseName = cb_db1.SelectedValue.ToString();
            DataTable dt = DbHelper.GetDataBase();
            List<string> dblist = dt.ToList().Select(m => m["Name"] + "").ToList();
            cb_tables1.DataSource = dblist;
        }

        private void btn_connectDb2_Click(object sender, EventArgs e)
        {
            string databaseName = cb_db2.SelectedValue.ToString();
            DataTable dt = DbHelper.GetDataBase();
            List<string> dblist = dt.ToList().Select(m => m["Name"] + "").ToList();
            cb_tables2.DataSource = dblist;
        }
        /// <summary>
        /// 对比两个数据库的结构
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_JieGou_Click(object sender, EventArgs e)
        {
            DataTable dt_database1 = DbHelper.GetTables(cb_tables1.SelectedValue.ToString());
            DataTable dt_database2 = DbHelper.GetTables(cb_tables2.SelectedValue.ToString());
            List<string> tablenameList1 = dt_database1.ToList().Select(m => m["name"] + "").ToList();
            List<string> tablenameList2 = dt_database2.ToList().Select(m => m["name"] + "").ToList();
            //新增了表
            //List<string> insertList = tablenameList2.Where(m => tablenameList1.Contains(m)).ToList();
            //foreach (var item in tablenameList2)
            //{
            //    if (!tablenameList1.Any(m=>m==item))
            //    {
            //        insertList.Add(item);
            //    }
            //}
            //删除了表
            //List<string> deleteList = tablenameList1.Where(m => tablenameList2.Contains(m)).ToList();
            //foreach (var item in tablenameList1)
            //{
            //    foreach (var item2 in tablenameList2)
            //    {
            //        if (item!=item2)
            //        {
            //            deleteList.Add(item);
            //        }

            //    }
            //}
            //表结构对比
        }
    }
}
