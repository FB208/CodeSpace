﻿namespace FBCodeProduce
{
    partial class HomeForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.WenJian = new System.Windows.Forms.ToolStripMenuItem();
            this.设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GongNeng = new System.Windows.Forms.ToolStripMenuItem();
            this.ShuJuKuBiDui = new System.Windows.Forms.ToolStripMenuItem();
            this.数据库ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.生成实体ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mSSqlServerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mySqlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.entityToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.panel_father = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.WenJian,
            this.GongNeng});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1184, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // WenJian
            // 
            this.WenJian.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.设置ToolStripMenuItem});
            this.WenJian.Name = "WenJian";
            this.WenJian.Size = new System.Drawing.Size(44, 21);
            this.WenJian.Text = "文件";
            // 
            // 设置ToolStripMenuItem
            // 
            this.设置ToolStripMenuItem.Name = "设置ToolStripMenuItem";
            this.设置ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.设置ToolStripMenuItem.Text = "设置";
            // 
            // GongNeng
            // 
            this.GongNeng.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ShuJuKuBiDui,
            this.数据库ToolStripMenuItem});
            this.GongNeng.Name = "GongNeng";
            this.GongNeng.Size = new System.Drawing.Size(44, 21);
            this.GongNeng.Text = "功能";
            // 
            // ShuJuKuBiDui
            // 
            this.ShuJuKuBiDui.Name = "ShuJuKuBiDui";
            this.ShuJuKuBiDui.Size = new System.Drawing.Size(136, 22);
            this.ShuJuKuBiDui.Text = "数据库比对";
            this.ShuJuKuBiDui.Click += new System.EventHandler(this.ShuJuKuBiDui_Click);
            // 
            // 数据库ToolStripMenuItem
            // 
            this.数据库ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.生成实体ToolStripMenuItem,
            this.mySqlToolStripMenuItem});
            this.数据库ToolStripMenuItem.Name = "数据库ToolStripMenuItem";
            this.数据库ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.数据库ToolStripMenuItem.Text = "数据库";
            // 
            // 生成实体ToolStripMenuItem
            // 
            this.生成实体ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mSSqlServerToolStripMenuItem});
            this.生成实体ToolStripMenuItem.Name = "生成实体ToolStripMenuItem";
            this.生成实体ToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.生成实体ToolStripMenuItem.Text = "SqlServer";
            // 
            // mSSqlServerToolStripMenuItem
            // 
            this.mSSqlServerToolStripMenuItem.Name = "mSSqlServerToolStripMenuItem";
            this.mSSqlServerToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.mSSqlServerToolStripMenuItem.Text = "生成实体";
            this.mSSqlServerToolStripMenuItem.Click += new System.EventHandler(this.mSSqlServerToolStripMenuItem_Click);
            // 
            // mySqlToolStripMenuItem
            // 
            this.mySqlToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.entityToolStripMenuItem1});
            this.mySqlToolStripMenuItem.Name = "mySqlToolStripMenuItem";
            this.mySqlToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.mySqlToolStripMenuItem.Text = "MySql";
            // 
            // entityToolStripMenuItem1
            // 
            this.entityToolStripMenuItem1.Name = "entityToolStripMenuItem1";
            this.entityToolStripMenuItem1.Size = new System.Drawing.Size(124, 22);
            this.entityToolStripMenuItem1.Text = "生成实体";
            this.entityToolStripMenuItem1.Click += new System.EventHandler(this.entityToolStripMenuItem1_Click);
            // 
            // panel_father
            // 
            this.panel_father.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_father.Location = new System.Drawing.Point(0, 28);
            this.panel_father.Name = "panel_father";
            this.panel_father.Size = new System.Drawing.Size(1184, 735);
            this.panel_father.TabIndex = 1;
            // 
            // HomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 761);
            this.Controls.Add(this.panel_father);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "HomeForm";
            this.Text = "HomeForm";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem WenJian;
        private System.Windows.Forms.ToolStripMenuItem 设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem GongNeng;
        private System.Windows.Forms.ToolStripMenuItem ShuJuKuBiDui;
        private System.Windows.Forms.Panel panel_father;
        private System.Windows.Forms.ToolStripMenuItem 数据库ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 生成实体ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mSSqlServerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mySqlToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem entityToolStripMenuItem1;
    }
}