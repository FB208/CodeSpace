namespace FBCodeProduce.Forms
{
    partial class DbCompareForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DbCompareForm));
            this.label1 = new System.Windows.Forms.Label();
            this.cb_db1 = new System.Windows.Forms.ComboBox();
            this.cb_db2 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_connectDb1 = new System.Windows.Forms.Button();
            this.btn_connectDb2 = new System.Windows.Forms.Button();
            this.btn_JieGou = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cb_tables1 = new System.Windows.Forms.ComboBox();
            this.cb_tables2 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "DB1:";
            // 
            // cb_db1
            // 
            this.cb_db1.FormattingEnabled = true;
            this.cb_db1.Location = new System.Drawing.Point(47, 6);
            this.cb_db1.Name = "cb_db1";
            this.cb_db1.Size = new System.Drawing.Size(168, 20);
            this.cb_db1.TabIndex = 2;
            // 
            // cb_db2
            // 
            this.cb_db2.FormattingEnabled = true;
            this.cb_db2.Location = new System.Drawing.Point(47, 37);
            this.cb_db2.Name = "cb_db2";
            this.cb_db2.Size = new System.Drawing.Size(168, 20);
            this.cb_db2.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "DB1:";
            // 
            // btn_connectDb1
            // 
            this.btn_connectDb1.Location = new System.Drawing.Point(221, 4);
            this.btn_connectDb1.Name = "btn_connectDb1";
            this.btn_connectDb1.Size = new System.Drawing.Size(75, 23);
            this.btn_connectDb1.TabIndex = 5;
            this.btn_connectDb1.Text = "链接";
            this.btn_connectDb1.UseVisualStyleBackColor = true;
            this.btn_connectDb1.Click += new System.EventHandler(this.btn_connectDb1_Click);
            // 
            // btn_connectDb2
            // 
            this.btn_connectDb2.Location = new System.Drawing.Point(221, 35);
            this.btn_connectDb2.Name = "btn_connectDb2";
            this.btn_connectDb2.Size = new System.Drawing.Size(75, 23);
            this.btn_connectDb2.TabIndex = 6;
            this.btn_connectDb2.Text = "链接";
            this.btn_connectDb2.UseVisualStyleBackColor = true;
            this.btn_connectDb2.Click += new System.EventHandler(this.btn_connectDb2_Click);
            // 
            // btn_JieGou
            // 
            this.btn_JieGou.Location = new System.Drawing.Point(12, 79);
            this.btn_JieGou.Name = "btn_JieGou";
            this.btn_JieGou.Size = new System.Drawing.Size(75, 23);
            this.btn_JieGou.TabIndex = 9;
            this.btn_JieGou.Text = "对比表结构";
            this.btn_JieGou.UseVisualStyleBackColor = true;
            this.btn_JieGou.Click += new System.EventHandler(this.btn_JieGou_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 108);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(776, 330);
            this.textBox1.TabIndex = 10;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(-143, 63);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1569, 10);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // cb_tables1
            // 
            this.cb_tables1.FormattingEnabled = true;
            this.cb_tables1.Location = new System.Drawing.Point(302, 6);
            this.cb_tables1.Name = "cb_tables1";
            this.cb_tables1.Size = new System.Drawing.Size(121, 20);
            this.cb_tables1.TabIndex = 11;
            // 
            // cb_tables2
            // 
            this.cb_tables2.FormattingEnabled = true;
            this.cb_tables2.Location = new System.Drawing.Point(302, 37);
            this.cb_tables2.Name = "cb_tables2";
            this.cb_tables2.Size = new System.Drawing.Size(121, 20);
            this.cb_tables2.TabIndex = 12;
            // 
            // DbCompareForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 732);
            this.Controls.Add(this.cb_tables2);
            this.Controls.Add(this.cb_tables1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btn_JieGou);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btn_connectDb2);
            this.Controls.Add(this.btn_connectDb1);
            this.Controls.Add(this.cb_db2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cb_db1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DbCompareForm";
            this.Text = "DbCompareForm";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cb_db1;
        private System.Windows.Forms.ComboBox cb_db2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_connectDb1;
        private System.Windows.Forms.Button btn_connectDb2;
        private System.Windows.Forms.Button btn_JieGou;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox cb_tables1;
        private System.Windows.Forms.ComboBox cb_tables2;
    }
}