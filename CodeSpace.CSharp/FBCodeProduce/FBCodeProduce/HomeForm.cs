﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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

        private void O_StringBuilderForm_Click(object sender, EventArgs e)
        {
            StringBuilderForm form = new StringBuilderForm();
            form.Show();
        }

        private void btn_codeProduce_Click(object sender, EventArgs e)
        {
            CreateModelForm form = new CreateModelForm();
            form.Show();
        }
    }
}
