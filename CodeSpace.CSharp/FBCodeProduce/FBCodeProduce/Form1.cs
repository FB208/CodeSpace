using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FBCodeProduce
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void O_StringBuilderForm_Click(object sender, EventArgs e)
        {
            StringBuilderForm form=new StringBuilderForm();
            form.Show();
            //this.Hide();
        }

        private void btn_Model_Click(object sender, EventArgs e)
        {
            CreateModelForm form = new CreateModelForm();
            form.Show();
        }

        private void DbSearch_Click(object sender, EventArgs e)
        {
            DbSearchForm form = new DbSearchForm();
            form.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btn_Setting_Click(object sender, EventArgs e)
        {
            SettingForm form = new SettingForm();
            form.Show();
        }


    }
}
