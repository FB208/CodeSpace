using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Windows.Forms;
using Common.Standard;
using FBCodeProduce.Tools;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FBCodeProduce.Forms.Settings
{
    public partial class f_dbConnection : f_base
    {
        public f_dbConnection()
        {
            InitializeComponent();
        }
        string BindServerName(JToken json) {
            
            //读取链接名称并赋值给下拉框
            List<string> serverNames = json["DbServer"].Children().Select(m => m.Value<string>("ServerName")).ToList();
            cb_ServerName.DataSource = serverNames;
            //取出选中项
            string selected = json["DbServer"].Children().FirstOrDefault(m => m.Value<bool>("IsUse") == true).Value<string>("ServerName");

            //设置默认选中
            cb_ServerName.SelectedIndex = cb_ServerName.Items.IndexOf(selected);
            return selected;
        }
        private void f_dbConnection_Load(object sender, EventArgs e)
        {
            JToken json = NewtonjsonHelper.ReadFile(Global.USER_SETTING_JSON_PATH);
            
            string selected = BindServerName(json);

            //加载配置项
            JToken selectedItem = json["DbServer"].Children().FirstOrDefault(m => m.Value<bool>("IsUse") == true);
            tb_ServerType.Text = selectedItem.Value<string>("ServerType");
            tb_ConnectionString.Text = selectedItem.Value<string>("ConnectionString"); 
        }
        /// <summary>
        /// 保存修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void btn_Save_Click(object sender, EventArgs e)
        {
            string serverName = cb_ServerName.Text;
            string serverType = tb_ServerType.Text;
            string connectionString = tb_ConnectionString.Text;
            JToken json = NewtonjsonHelper.ReadFile(Global.USER_SETTING_JSON_PATH);
            bool isEdit = json["DbServer"].Children().Any(m => m.Value<string>("ServerName") == serverName);
            #region 设置所有链接选中状态为false
            var servers = json["DbServer"];
            for (int i = 0; i < servers.Count(); i++)
            {
                servers[i]["IsUse"] = false;
            }
            #endregion

            if (isEdit)
            {
                JToken edit = json["DbServer"].FirstOrDefault(m => m.Value<string>("ServerName") == serverName);
                edit["ServerName"] = serverName;
                edit["ServerType"] = serverType;
                edit["ConnectionString"] = connectionString;
                edit["IsUse"] = true;
            }
            else
            {
                JObject newServer = new JObject();
                newServer.Add(new JProperty("ServerName", serverName));
                newServer.Add(new JProperty("ServerType", serverType));
                newServer.Add(new JProperty("ConnectionString", connectionString));
                newServer.Add(new JProperty("IsUse", true));
                json["DbServer"].Last.AddAfterSelf(newServer);
            }
            NewtonjsonHelper.WriteFile(Global.USER_SETTING_JSON_PATH, json as JObject);
            MessageBox.Show("保存成功");
            BindServerName(json);
            //base.btn_Save_Click(sender,e);
        }

        private void Cb_ServerName_SelectedIndexChanged(object sender, EventArgs e)
        {

            string selectedText = cb_ServerName.SelectedValue.ToString();
            JToken json = NewtonjsonHelper.ReadFile(Global.USER_SETTING_JSON_PATH);
            //加载配置项
            JToken selectedItem = json["DbServer"].Children().FirstOrDefault(m => m.Value<string>("ServerName") == selectedText);
            tb_ServerType.Text = selectedItem.Value<string>("ServerType");
            tb_ConnectionString.Text = selectedItem.Value<string>("ConnectionString");
        }

    }

    
}
