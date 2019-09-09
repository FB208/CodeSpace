namespace FBCodeProduce
{
    partial class SettingForm
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
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("数据库链接字符串");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("连接管理", new System.Windows.Forms.TreeNode[] {
            treeNode5});
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("编辑INI");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("配置文件", new System.Windows.Forms.TreeNode[] {
            treeNode7});
            this.tw_menu = new System.Windows.Forms.TreeView();
            this.panel_father = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // tw_menu
            // 
            this.tw_menu.Location = new System.Drawing.Point(12, 10);
            this.tw_menu.Name = "tw_menu";
            treeNode5.Name = "dbConnection";
            treeNode5.Text = "数据库链接字符串";
            treeNode6.Name = "connection";
            treeNode6.Text = "连接管理";
            treeNode7.Name = "editIni";
            treeNode7.Text = "编辑INI";
            treeNode8.Name = "ini";
            treeNode8.Text = "配置文件";
            this.tw_menu.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode6,
            treeNode8});
            this.tw_menu.Size = new System.Drawing.Size(200, 440);
            this.tw_menu.TabIndex = 0;
            this.tw_menu.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tw_menu_NodeMouseClick);
            // 
            // panel_father
            // 
            this.panel_father.Location = new System.Drawing.Point(222, 10);
            this.panel_father.Name = "panel_father";
            this.panel_father.Size = new System.Drawing.Size(350, 440);
            this.panel_father.TabIndex = 1;
            // 
            // SettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 462);
            this.Controls.Add(this.panel_father);
            this.Controls.Add(this.tw_menu);
            this.Name = "SettingForm";
            this.Text = "SettingForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView tw_menu;
        private System.Windows.Forms.Panel panel_father;

    }
}