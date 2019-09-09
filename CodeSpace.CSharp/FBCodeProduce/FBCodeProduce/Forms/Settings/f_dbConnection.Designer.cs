namespace FBCodeProduce.Forms.Settings
{
    partial class f_dbConnection
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
            this.lbl_ServerType = new System.Windows.Forms.Label();
            this.tb_ServerType = new System.Windows.Forms.TextBox();
            this.lbl_ConnectionString = new System.Windows.Forms.Label();
            this.tb_ConnectionString = new System.Windows.Forms.TextBox();
            this.lbl_ServerName = new System.Windows.Forms.Label();
            this.cb_ServerName = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btn_Save
            // 

            // 
            // lbl_ServerType
            // 
            this.lbl_ServerType.AutoSize = true;
            this.lbl_ServerType.Location = new System.Drawing.Point(14, 72);
            this.lbl_ServerType.Name = "lbl_ServerType";
            this.lbl_ServerType.Size = new System.Drawing.Size(65, 12);
            this.lbl_ServerType.TabIndex = 0;
            this.lbl_ServerType.Text = "数据库类型";
            // 
            // tb_ServerType
            // 
            this.tb_ServerType.Location = new System.Drawing.Point(85, 69);
            this.tb_ServerType.Name = "tb_ServerType";
            this.tb_ServerType.Size = new System.Drawing.Size(253, 21);
            this.tb_ServerType.TabIndex = 1;
            this.tb_ServerType.Text = "Microsoft SQL Server";
            // 
            // lbl_ConnectionString
            // 
            this.lbl_ConnectionString.AutoSize = true;
            this.lbl_ConnectionString.Location = new System.Drawing.Point(14, 126);
            this.lbl_ConnectionString.Name = "lbl_ConnectionString";
            this.lbl_ConnectionString.Size = new System.Drawing.Size(65, 12);
            this.lbl_ConnectionString.TabIndex = 2;
            this.lbl_ConnectionString.Text = "链接字符串";
            // 
            // tb_ConnectionString
            // 
            this.tb_ConnectionString.Location = new System.Drawing.Point(85, 123);
            this.tb_ConnectionString.Multiline = true;
            this.tb_ConnectionString.Name = "tb_ConnectionString";
            this.tb_ConnectionString.Size = new System.Drawing.Size(253, 115);
            this.tb_ConnectionString.TabIndex = 3;
            // 
            // lbl_ServerName
            // 
            this.lbl_ServerName.AutoSize = true;
            this.lbl_ServerName.Location = new System.Drawing.Point(14, 24);
            this.lbl_ServerName.Name = "lbl_ServerName";
            this.lbl_ServerName.Size = new System.Drawing.Size(53, 12);
            this.lbl_ServerName.TabIndex = 4;
            this.lbl_ServerName.Text = "链接名称";
            // 
            // cb_ServerName
            // 
            this.cb_ServerName.FormattingEnabled = true;
            this.cb_ServerName.Location = new System.Drawing.Point(85, 21);
            this.cb_ServerName.Name = "cb_ServerName";
            this.cb_ServerName.Size = new System.Drawing.Size(253, 20);
            this.cb_ServerName.TabIndex = 5;
            this.cb_ServerName.SelectedIndexChanged += new System.EventHandler(this.Cb_ServerName_SelectedIndexChanged);
            // 
            // f_dbConnection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 440);
            this.Controls.Add(this.cb_ServerName);
            this.Controls.Add(this.lbl_ServerName);
            this.Controls.Add(this.tb_ConnectionString);
            this.Controls.Add(this.lbl_ConnectionString);
            this.Controls.Add(this.tb_ServerType);
            this.Controls.Add(this.lbl_ServerType);
            this.Name = "f_dbConnection";
            this.Text = "f_dbConnection";
            this.Load += new System.EventHandler(this.f_dbConnection_Load);
            this.Controls.SetChildIndex(this.lbl_ServerType, 0);
            this.Controls.SetChildIndex(this.tb_ServerType, 0);
            this.Controls.SetChildIndex(this.lbl_ConnectionString, 0);
            this.Controls.SetChildIndex(this.tb_ConnectionString, 0);
            this.Controls.SetChildIndex(this.btn_Save, 0);
            this.Controls.SetChildIndex(this.lbl_ServerName, 0);
            this.Controls.SetChildIndex(this.cb_ServerName, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_ServerType;
        private System.Windows.Forms.TextBox tb_ServerType;
        private System.Windows.Forms.Label lbl_ConnectionString;
        private System.Windows.Forms.TextBox tb_ConnectionString;
        private System.Windows.Forms.Label lbl_ServerName;
        private System.Windows.Forms.ComboBox cb_ServerName;
    }
}