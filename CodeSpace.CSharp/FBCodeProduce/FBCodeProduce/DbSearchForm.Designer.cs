namespace FBCodeProduce
{
    partial class DbSearchForm
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
            this.tb_SearchResult = new System.Windows.Forms.TextBox();
            this.tb_SearchTxt = new System.Windows.Forms.TextBox();
            this.btn_Search = new System.Windows.Forms.Button();
            this.btn_Result = new System.Windows.Forms.Button();
            this.btn_select = new System.Windows.Forms.Button();
            this.btn_update = new System.Windows.Forms.Button();
            this.tb_NewValue = new System.Windows.Forms.TextBox();
            this.lbl_oldValue = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tb_SearchResult
            // 
            this.tb_SearchResult.Location = new System.Drawing.Point(12, 114);
            this.tb_SearchResult.Multiline = true;
            this.tb_SearchResult.Name = "tb_SearchResult";
            this.tb_SearchResult.Size = new System.Drawing.Size(542, 287);
            this.tb_SearchResult.TabIndex = 0;
            // 
            // tb_SearchTxt
            // 
            this.tb_SearchTxt.Location = new System.Drawing.Point(59, 13);
            this.tb_SearchTxt.Name = "tb_SearchTxt";
            this.tb_SearchTxt.Size = new System.Drawing.Size(130, 21);
            this.tb_SearchTxt.TabIndex = 1;
            // 
            // btn_Search
            // 
            this.btn_Search.Location = new System.Drawing.Point(209, 11);
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.Size = new System.Drawing.Size(75, 23);
            this.btn_Search.TabIndex = 2;
            this.btn_Search.Text = "查询";
            this.btn_Search.UseVisualStyleBackColor = true;
            this.btn_Search.Click += new System.EventHandler(this.btn_Search_Click);
            // 
            // btn_Result
            // 
            this.btn_Result.Location = new System.Drawing.Point(12, 85);
            this.btn_Result.Name = "btn_Result";
            this.btn_Result.Size = new System.Drawing.Size(75, 23);
            this.btn_Result.TabIndex = 3;
            this.btn_Result.Text = "文本";
            this.btn_Result.UseVisualStyleBackColor = true;
            this.btn_Result.Click += new System.EventHandler(this.btn_Result_Click);
            // 
            // btn_select
            // 
            this.btn_select.Location = new System.Drawing.Point(93, 85);
            this.btn_select.Name = "btn_select";
            this.btn_select.Size = new System.Drawing.Size(75, 23);
            this.btn_select.TabIndex = 4;
            this.btn_select.Text = "SELECT";
            this.btn_select.UseVisualStyleBackColor = true;
            this.btn_select.Click += new System.EventHandler(this.btn_select_Click);
            // 
            // btn_update
            // 
            this.btn_update.Location = new System.Drawing.Point(174, 85);
            this.btn_update.Name = "btn_update";
            this.btn_update.Size = new System.Drawing.Size(75, 23);
            this.btn_update.TabIndex = 5;
            this.btn_update.Text = "UPDATE";
            this.btn_update.UseVisualStyleBackColor = true;
            this.btn_update.Click += new System.EventHandler(this.btn_update_Click);
            // 
            // tb_NewValue
            // 
            this.tb_NewValue.Location = new System.Drawing.Point(59, 40);
            this.tb_NewValue.Name = "tb_NewValue";
            this.tb_NewValue.Size = new System.Drawing.Size(130, 21);
            this.tb_NewValue.TabIndex = 6;
            // 
            // lbl_oldValue
            // 
            this.lbl_oldValue.AutoSize = true;
            this.lbl_oldValue.Location = new System.Drawing.Point(12, 16);
            this.lbl_oldValue.Name = "lbl_oldValue";
            this.lbl_oldValue.Size = new System.Drawing.Size(41, 12);
            this.lbl_oldValue.TabIndex = 7;
            this.lbl_oldValue.Text = "原值：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 8;
            this.label1.Text = "新值：";
            // 
            // DbSearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 413);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbl_oldValue);
            this.Controls.Add(this.tb_NewValue);
            this.Controls.Add(this.btn_update);
            this.Controls.Add(this.btn_select);
            this.Controls.Add(this.btn_Result);
            this.Controls.Add(this.btn_Search);
            this.Controls.Add(this.tb_SearchTxt);
            this.Controls.Add(this.tb_SearchResult);
            this.Name = "DbSearchForm";
            this.Text = "DbSearchForm";
            this.Load += new System.EventHandler(this.DbSearchForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_SearchResult;
        private System.Windows.Forms.TextBox tb_SearchTxt;
        private System.Windows.Forms.Button btn_Search;
        private System.Windows.Forms.Button btn_Result;
        private System.Windows.Forms.Button btn_select;
        private System.Windows.Forms.Button btn_update;
        private System.Windows.Forms.TextBox tb_NewValue;
        private System.Windows.Forms.Label lbl_oldValue;
        private System.Windows.Forms.Label label1;
    }
}