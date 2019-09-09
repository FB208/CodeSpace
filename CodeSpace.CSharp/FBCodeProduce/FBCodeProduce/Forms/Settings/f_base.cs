using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FBCodeProduce.Forms.Settings
{
    public partial class f_base : Form
    {
        public f_base()
        {
            InitializeComponent();
        }

        protected virtual void btn_Save_Click(object sender, EventArgs e)
        {
            MessageBox.Show("保存成功");
        }

    }
}
