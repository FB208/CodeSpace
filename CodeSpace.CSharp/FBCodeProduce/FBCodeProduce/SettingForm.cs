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
            string name = e.Node.Name.ToString();
            ShowPanel(name);
       

        }

        private void ShowPanel(string linkName)
        {
            this.Cursor = Cursors.WaitCursor;
            string name= $"FBCodeProduce.Forms.Settings.f_{linkName}"; //类的名字
            var path = AssemblyName.GetAssemblyName("FBCodeProduce.exe");
            Form fm = (Form)Assembly.Load(path).CreateInstance(name);
            if (fm!=null)
            {
                panel_father.Controls.Clear();
                
                fm.MdiParent = this.ParentForm;
                fm.Dock = DockStyle.Fill;
                fm.TopLevel = false;
                panel_father.Controls.Add(fm);
                fm.Show();
            }
            this.Cursor = Cursors.Default;
        }


    }
}
