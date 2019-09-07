namespace FBCodeProduce
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.O_StringBuilderForm = new System.Windows.Forms.Button();
            this.btn_Model = new System.Windows.Forms.Button();
            this.DbSearch = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_Setting = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Setting)).BeginInit();
            this.SuspendLayout();
            // 
            // O_StringBuilderForm
            // 
            this.O_StringBuilderForm.Location = new System.Drawing.Point(13, 13);
            this.O_StringBuilderForm.Name = "O_StringBuilderForm";
            this.O_StringBuilderForm.Size = new System.Drawing.Size(98, 23);
            this.O_StringBuilderForm.TabIndex = 0;
            this.O_StringBuilderForm.Text = "StringBuilder";
            this.O_StringBuilderForm.UseVisualStyleBackColor = true;
            this.O_StringBuilderForm.Click += new System.EventHandler(this.O_StringBuilderForm_Click);
            // 
            // btn_Model
            // 
            this.btn_Model.Location = new System.Drawing.Point(117, 13);
            this.btn_Model.Name = "btn_Model";
            this.btn_Model.Size = new System.Drawing.Size(75, 23);
            this.btn_Model.TabIndex = 1;
            this.btn_Model.Text = "生成模型";
            this.btn_Model.UseVisualStyleBackColor = true;
            this.btn_Model.Click += new System.EventHandler(this.btn_Model_Click);
            // 
            // DbSearch
            // 
            this.DbSearch.Location = new System.Drawing.Point(13, 42);
            this.DbSearch.Name = "DbSearch";
            this.DbSearch.Size = new System.Drawing.Size(75, 23);
            this.DbSearch.TabIndex = 2;
            this.DbSearch.Text = "全库查询";
            this.DbSearch.UseVisualStyleBackColor = true;
            this.DbSearch.Click += new System.EventHandler(this.DbSearch_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(104, 41);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "shajiForm";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btn_Setting
            // 
            this.btn_Setting.Image = global::FBCodeProduce.Properties.Resources.setting;
            this.btn_Setting.Location = new System.Drawing.Point(245, 4);
            this.btn_Setting.Name = "btn_Setting";
            this.btn_Setting.Size = new System.Drawing.Size(32, 32);
            this.btn_Setting.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.btn_Setting.TabIndex = 4;
            this.btn_Setting.TabStop = false;
            this.btn_Setting.Click += new System.EventHandler(this.btn_Setting_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.btn_Setting);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.DbSearch);
            this.Controls.Add(this.btn_Model);
            this.Controls.Add(this.O_StringBuilderForm);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btn_Setting)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button O_StringBuilderForm;
        private System.Windows.Forms.Button btn_Model;
        private System.Windows.Forms.Button DbSearch;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox btn_Setting;
    }
}

