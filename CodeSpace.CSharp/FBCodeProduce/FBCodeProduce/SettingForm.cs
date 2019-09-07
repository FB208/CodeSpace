using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using FBCodeProduce.Forms.Settings;

namespace FBCodeProduce
{
    public partial class SettingForm : Form
    {
        public SettingForm()
        {
            InitializeComponent();
        }

        private void tw_menu_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            string name = e.Node.Text.ToString();
            ShowPanel("panel_"+name);
       

        }

        private void ShowPanel(string panelName)
        {
            panel_father.Controls.Clear();
            this.Cursor = Cursors.WaitCursor;

            //string name=strName; //类的名字
            Form fm = (Form) Assembly.Load("FBCodeProduce.exe").CreateInstance("f_dbConnection");
            fm.MdiParent=this.ParentForm;
            fm.Show();
            fm.Dock=DockStyle.Fill;
            this.Cursor = Cursors.Default;
            f_dbConnection child = new f_dbConnection();
            child.TopLevel = false;
            panel_father.Controls.Add(child);
            child.Show();
        }


    }
}
