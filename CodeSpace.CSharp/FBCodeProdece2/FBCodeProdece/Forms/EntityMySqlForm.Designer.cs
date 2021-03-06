﻿namespace FBCodeProduce.Forms
{
    partial class EntityMySqlForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btn_BLL = new System.Windows.Forms.Button();
            this.btn_dal = new System.Windows.Forms.Button();
            this.btn_forfolder = new System.Windows.Forms.Button();
            this.btn_model = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btn_entity = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btn_mockJson = new System.Windows.Forms.Button();
            this.btn_table = new System.Windows.Forms.Button();
            this.tb_namespace = new System.Windows.Forms.TextBox();
            this.cb_tables = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_result = new System.Windows.Forms.TextBox();
            this.cb_dbs = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_projectPath = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(10, 70);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1162, 142);
            this.tabControl1.TabIndex = 13;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btn_BLL);
            this.tabPage1.Controls.Add(this.btn_dal);
            this.tabPage1.Controls.Add(this.btn_forfolder);
            this.tabPage1.Controls.Add(this.btn_model);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1154, 116);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "C#";
            // 
            // btn_BLL
            // 
            this.btn_BLL.Location = new System.Drawing.Point(168, 6);
            this.btn_BLL.Name = "btn_BLL";
            this.btn_BLL.Size = new System.Drawing.Size(75, 23);
            this.btn_BLL.TabIndex = 3;
            this.btn_BLL.Text = "BLL";
            this.btn_BLL.UseVisualStyleBackColor = true;
            this.btn_BLL.Click += new System.EventHandler(this.btn_BLL_Click);
            // 
            // btn_dal
            // 
            this.btn_dal.Location = new System.Drawing.Point(87, 6);
            this.btn_dal.Name = "btn_dal";
            this.btn_dal.Size = new System.Drawing.Size(75, 23);
            this.btn_dal.TabIndex = 2;
            this.btn_dal.Text = "DAL";
            this.btn_dal.UseVisualStyleBackColor = true;
            this.btn_dal.Click += new System.EventHandler(this.btn_dal_Click);
            // 
            // btn_forfolder
            // 
            this.btn_forfolder.Location = new System.Drawing.Point(6, 35);
            this.btn_forfolder.Name = "btn_forfolder";
            this.btn_forfolder.Size = new System.Drawing.Size(75, 23);
            this.btn_forfolder.TabIndex = 1;
            this.btn_forfolder.Text = "批量导出";
            this.btn_forfolder.UseVisualStyleBackColor = true;
            this.btn_forfolder.Click += new System.EventHandler(this.btn_forfolder_Click);
            // 
            // btn_model
            // 
            this.btn_model.Location = new System.Drawing.Point(6, 6);
            this.btn_model.Name = "btn_model";
            this.btn_model.Size = new System.Drawing.Size(75, 23);
            this.btn_model.TabIndex = 0;
            this.btn_model.Text = "Model";
            this.btn_model.UseVisualStyleBackColor = true;
            this.btn_model.Click += new System.EventHandler(this.btn_model_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btn_entity);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1154, 116);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "JAVA";
            // 
            // btn_entity
            // 
            this.btn_entity.Location = new System.Drawing.Point(6, 6);
            this.btn_entity.Name = "btn_entity";
            this.btn_entity.Size = new System.Drawing.Size(75, 23);
            this.btn_entity.TabIndex = 0;
            this.btn_entity.Text = "Entity";
            this.btn_entity.UseVisualStyleBackColor = true;
            this.btn_entity.Click += new System.EventHandler(this.btn_entity_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage3.Controls.Add(this.btn_mockJson);
            this.tabPage3.Controls.Add(this.btn_table);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1154, 116);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "VUE";
            // 
            // btn_mockJson
            // 
            this.btn_mockJson.Location = new System.Drawing.Point(87, 6);
            this.btn_mockJson.Name = "btn_mockJson";
            this.btn_mockJson.Size = new System.Drawing.Size(75, 23);
            this.btn_mockJson.TabIndex = 1;
            this.btn_mockJson.Text = "MockJson";
            this.btn_mockJson.UseVisualStyleBackColor = true;
            this.btn_mockJson.Click += new System.EventHandler(this.btn_mockJson_Click);
            // 
            // btn_table
            // 
            this.btn_table.Location = new System.Drawing.Point(6, 6);
            this.btn_table.Name = "btn_table";
            this.btn_table.Size = new System.Drawing.Size(75, 23);
            this.btn_table.TabIndex = 0;
            this.btn_table.Text = "Table";
            this.btn_table.UseVisualStyleBackColor = true;
            this.btn_table.Click += new System.EventHandler(this.btn_table_Click);
            // 
            // tb_namespace
            // 
            this.tb_namespace.Location = new System.Drawing.Point(76, 38);
            this.tb_namespace.Name = "tb_namespace";
            this.tb_namespace.Size = new System.Drawing.Size(131, 21);
            this.tb_namespace.TabIndex = 14;
            // 
            // cb_tables
            // 
            this.cb_tables.FormattingEnabled = true;
            this.cb_tables.Location = new System.Drawing.Point(236, 12);
            this.cb_tables.Name = "cb_tables";
            this.cb_tables.Size = new System.Drawing.Size(146, 20);
            this.cb_tables.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(213, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 11;
            this.label2.Text = "表：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 9;
            this.label1.Text = "数据库：";
            // 
            // tb_result
            // 
            this.tb_result.Location = new System.Drawing.Point(10, 218);
            this.tb_result.Multiline = true;
            this.tb_result.Name = "tb_result";
            this.tb_result.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tb_result.Size = new System.Drawing.Size(1158, 502);
            this.tb_result.TabIndex = 15;
            // 
            // cb_dbs
            // 
            this.cb_dbs.FormattingEnabled = true;
            this.cb_dbs.Location = new System.Drawing.Point(61, 12);
            this.cb_dbs.Name = "cb_dbs";
            this.cb_dbs.Size = new System.Drawing.Size(146, 20);
            this.cb_dbs.TabIndex = 16;
            this.cb_dbs.SelectedIndexChanged += new System.EventHandler(this.cb_dbs_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 17;
            this.label3.Text = "命名空间：";
            // 
            // tb_projectPath
            // 
            this.tb_projectPath.Location = new System.Drawing.Point(281, 38);
            this.tb_projectPath.Name = "tb_projectPath";
            this.tb_projectPath.Size = new System.Drawing.Size(131, 21);
            this.tb_projectPath.TabIndex = 18;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(213, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 19;
            this.label4.Text = "导出路径：";
            // 
            // EntityMySqlForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 732);
            this.Controls.Add(this.tb_projectPath);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tb_namespace);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cb_dbs);
            this.Controls.Add(this.tb_result);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.cb_tables);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "EntityMySqlForm";
            this.Text = "EntityMySqlForm";
            this.Load += new System.EventHandler(this.EntityMySqlForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btn_model;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ComboBox cb_tables;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_namespace;
        private System.Windows.Forms.TextBox tb_result;
        private System.Windows.Forms.ComboBox cb_dbs;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_forfolder;
        private System.Windows.Forms.Button btn_dal;
        private System.Windows.Forms.Button btn_BLL;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button btn_table;
        private System.Windows.Forms.Button btn_mockJson;
        private System.Windows.Forms.Button btn_entity;
        private System.Windows.Forms.TextBox tb_projectPath;
        private System.Windows.Forms.Label label4;
    }
}