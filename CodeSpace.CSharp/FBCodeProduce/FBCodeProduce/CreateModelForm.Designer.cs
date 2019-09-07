namespace FBCodeProduce
{
    partial class CreateModelForm
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
            this.cb_Tables = new System.Windows.Forms.ComboBox();
            this.btn_CreateModel = new System.Windows.Forms.Button();
            this.tb_Result = new System.Windows.Forms.TextBox();
            this.tb_DatabaseName = new System.Windows.Forms.TextBox();
            this.btn_connect = new System.Windows.Forms.Button();
            this.btn_Insert = new System.Windows.Forms.Button();
            this.btn_Update = new System.Windows.Forms.Button();
            this.btn_ControlToModel = new System.Windows.Forms.Button();
            this.Btn_ModelToControl = new System.Windows.Forms.Button();
            this.btn_DataRowToModel = new System.Windows.Forms.Button();
            this.btn_OpenDictionary = new System.Windows.Forms.Button();
            this.btn_InsertParameter = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cb_Tables
            // 
            this.cb_Tables.FormattingEnabled = true;
            this.cb_Tables.Location = new System.Drawing.Point(229, 13);
            this.cb_Tables.Name = "cb_Tables";
            this.cb_Tables.Size = new System.Drawing.Size(210, 20);
            this.cb_Tables.TabIndex = 0;
            // 
            // btn_CreateModel
            // 
            this.btn_CreateModel.Location = new System.Drawing.Point(445, 13);
            this.btn_CreateModel.Name = "btn_CreateModel";
            this.btn_CreateModel.Size = new System.Drawing.Size(85, 23);
            this.btn_CreateModel.TabIndex = 1;
            this.btn_CreateModel.Text = "生成模型";
            this.btn_CreateModel.UseVisualStyleBackColor = true;
            this.btn_CreateModel.Click += new System.EventHandler(this.btn_CreateModel_Click);
            // 
            // tb_Result
            // 
            this.tb_Result.Location = new System.Drawing.Point(13, 106);
            this.tb_Result.Multiline = true;
            this.tb_Result.Name = "tb_Result";
            this.tb_Result.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tb_Result.Size = new System.Drawing.Size(743, 531);
            this.tb_Result.TabIndex = 4;
            this.tb_Result.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Ctrl_A);
            // 
            // tb_DatabaseName
            // 
            this.tb_DatabaseName.Location = new System.Drawing.Point(13, 13);
            this.tb_DatabaseName.Name = "tb_DatabaseName";
            this.tb_DatabaseName.Size = new System.Drawing.Size(129, 21);
            this.tb_DatabaseName.TabIndex = 5;
            this.tb_DatabaseName.Text = "NewReport";
            // 
            // btn_connect
            // 
            this.btn_connect.Location = new System.Drawing.Point(148, 12);
            this.btn_connect.Name = "btn_connect";
            this.btn_connect.Size = new System.Drawing.Size(75, 23);
            this.btn_connect.TabIndex = 6;
            this.btn_connect.Text = "链接";
            this.btn_connect.UseVisualStyleBackColor = true;
            this.btn_connect.Click += new System.EventHandler(this.btn_connect_Click);
            // 
            // btn_Insert
            // 
            this.btn_Insert.Location = new System.Drawing.Point(536, 13);
            this.btn_Insert.Name = "btn_Insert";
            this.btn_Insert.Size = new System.Drawing.Size(108, 23);
            this.btn_Insert.TabIndex = 7;
            this.btn_Insert.Text = "插入模型代码";
            this.btn_Insert.UseVisualStyleBackColor = true;
            this.btn_Insert.Click += new System.EventHandler(this.btn_Insert_Click);
            // 
            // btn_Update
            // 
            this.btn_Update.Location = new System.Drawing.Point(650, 13);
            this.btn_Update.Name = "btn_Update";
            this.btn_Update.Size = new System.Drawing.Size(106, 23);
            this.btn_Update.TabIndex = 8;
            this.btn_Update.Text = "更新模型代码";
            this.btn_Update.UseVisualStyleBackColor = true;
            this.btn_Update.Click += new System.EventHandler(this.btn_Update_Click);
            // 
            // btn_ControlToModel
            // 
            this.btn_ControlToModel.Location = new System.Drawing.Point(13, 40);
            this.btn_ControlToModel.Name = "btn_ControlToModel";
            this.btn_ControlToModel.Size = new System.Drawing.Size(129, 23);
            this.btn_ControlToModel.TabIndex = 9;
            this.btn_ControlToModel.Text = "控件值赋给模型";
            this.btn_ControlToModel.UseVisualStyleBackColor = true;
            this.btn_ControlToModel.Click += new System.EventHandler(this.btn_ControlToModel_Click);
            // 
            // Btn_ModelToControl
            // 
            this.Btn_ModelToControl.Location = new System.Drawing.Point(13, 69);
            this.Btn_ModelToControl.Name = "Btn_ModelToControl";
            this.Btn_ModelToControl.Size = new System.Drawing.Size(129, 23);
            this.Btn_ModelToControl.TabIndex = 10;
            this.Btn_ModelToControl.Text = "模型值赋给控件";
            this.Btn_ModelToControl.UseVisualStyleBackColor = true;
            this.Btn_ModelToControl.Click += new System.EventHandler(this.Btn_ModelToControl_Click);
            // 
            // btn_DataRowToModel
            // 
            this.btn_DataRowToModel.Location = new System.Drawing.Point(148, 40);
            this.btn_DataRowToModel.Name = "btn_DataRowToModel";
            this.btn_DataRowToModel.Size = new System.Drawing.Size(165, 23);
            this.btn_DataRowToModel.TabIndex = 11;
            this.btn_DataRowToModel.Text = "DataRow(单行)赋值给模型";
            this.btn_DataRowToModel.UseVisualStyleBackColor = true;
            // 
            // btn_OpenDictionary
            // 
            this.btn_OpenDictionary.Location = new System.Drawing.Point(319, 40);
            this.btn_OpenDictionary.Name = "btn_OpenDictionary";
            this.btn_OpenDictionary.Size = new System.Drawing.Size(75, 23);
            this.btn_OpenDictionary.TabIndex = 12;
            this.btn_OpenDictionary.Text = "数据字典";
            this.btn_OpenDictionary.UseVisualStyleBackColor = true;
            this.btn_OpenDictionary.Click += new System.EventHandler(this.btn_OpenDictionary_Click);
            // 
            // btn_InsertParameter
            // 
            this.btn_InsertParameter.Location = new System.Drawing.Point(536, 40);
            this.btn_InsertParameter.Name = "btn_InsertParameter";
            this.btn_InsertParameter.Size = new System.Drawing.Size(108, 23);
            this.btn_InsertParameter.TabIndex = 13;
            this.btn_InsertParameter.Text = "插入Param代码";
            this.btn_InsertParameter.UseVisualStyleBackColor = true;
            this.btn_InsertParameter.Click += new System.EventHandler(this.btn_InsertParameter_Click);
            // 
            // CreateModelForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(768, 649);
            this.Controls.Add(this.btn_InsertParameter);
            this.Controls.Add(this.btn_OpenDictionary);
            this.Controls.Add(this.btn_DataRowToModel);
            this.Controls.Add(this.Btn_ModelToControl);
            this.Controls.Add(this.btn_ControlToModel);
            this.Controls.Add(this.btn_Update);
            this.Controls.Add(this.btn_Insert);
            this.Controls.Add(this.btn_connect);
            this.Controls.Add(this.tb_DatabaseName);
            this.Controls.Add(this.tb_Result);
            this.Controls.Add(this.btn_CreateModel);
            this.Controls.Add(this.cb_Tables);
            this.Name = "CreateModelForm";
            this.Text = "CreateModelForm";
            this.Load += new System.EventHandler(this.CreateModelForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cb_Tables;
        private System.Windows.Forms.Button btn_CreateModel;
        private System.Windows.Forms.TextBox tb_Result;
        private System.Windows.Forms.TextBox tb_DatabaseName;
        private System.Windows.Forms.Button btn_connect;
        private System.Windows.Forms.Button btn_Insert;
        private System.Windows.Forms.Button btn_Update;
        private System.Windows.Forms.Button btn_ControlToModel;
        private System.Windows.Forms.Button Btn_ModelToControl;
        private System.Windows.Forms.Button btn_DataRowToModel;
        private System.Windows.Forms.Button btn_OpenDictionary;
        private System.Windows.Forms.Button btn_InsertParameter;
    }
}