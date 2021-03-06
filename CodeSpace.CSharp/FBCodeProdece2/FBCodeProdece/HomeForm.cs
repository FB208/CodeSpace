﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FBCodeProduce
{
    public partial class HomeForm : Form
    {
        public HomeForm()
        {
            InitializeComponent();
        }

        private void ShuJuKuBiDui_Click(object sender, EventArgs e)
        {
            ShowPanel("DbCompareForm");
        }

        /// <summary>
        /// panel填充内容
        /// </summary>
        /// <param name="linkName"></param>
        private void ShowPanel(string linkName)
        {
            this.Cursor = Cursors.WaitCursor;
            string name = $"FBCodeProduce.Forms.{linkName}"; //类的名字
            var path = AssemblyName.GetAssemblyName("FBCodeProduce.exe");
            Form fm = (Form)Assembly.Load(path).CreateInstance(name);
            if (fm != null)
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

        private void mSSqlServerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowPanel("EntityMSSqlServerForm");
        }


        private void entityToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ShowPanel("EntityMySqlForm");
        }
    }
}
