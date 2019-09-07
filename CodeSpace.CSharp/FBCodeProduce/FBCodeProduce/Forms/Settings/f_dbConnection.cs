using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FBCodeProduce.Tools;

namespace FBCodeProduce.Forms.Settings
{
    public partial class f_dbConnection : f_base
    {
        public f_dbConnection()
        {
            InitializeComponent();
        }

        private void f_dbConnection_Load(object sender, EventArgs e)
        {
            //加载配置项
            tb_ServerType.Text = IniHelper.GetValue("链接字符串", "ServerType");
            tb_ConnectionString.Text = IniHelper.GetValue("链接字符串", "ConnectionString");
        }

        protected override void btn_Save_Click(object sender, EventArgs e)
        {
            MessageBox.Show("子窗口");
            base.btn_Save_Click(sender,e);
        }

        
    }

    
}
