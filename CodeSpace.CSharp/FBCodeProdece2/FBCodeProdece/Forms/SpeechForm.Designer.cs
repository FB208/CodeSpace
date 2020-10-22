namespace FBCodeProduce.Forms
{
    partial class SpeechForm
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
            this.tb_val = new System.Windows.Forms.TextBox();
            this.btn_speak = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tb_val
            // 
            this.tb_val.Location = new System.Drawing.Point(52, 87);
            this.tb_val.Name = "tb_val";
            this.tb_val.Size = new System.Drawing.Size(210, 21);
            this.tb_val.TabIndex = 0;
            // 
            // btn_speak
            // 
            this.btn_speak.Location = new System.Drawing.Point(286, 87);
            this.btn_speak.Name = "btn_speak";
            this.btn_speak.Size = new System.Drawing.Size(75, 23);
            this.btn_speak.TabIndex = 1;
            this.btn_speak.Text = "播";
            this.btn_speak.UseVisualStyleBackColor = true;
            this.btn_speak.Click += new System.EventHandler(this.btn_speak_Click);
            // 
            // SpeechForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_speak);
            this.Controls.Add(this.tb_val);
            this.Name = "SpeechForm";
            this.Text = "SpeechForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_val;
        private System.Windows.Forms.Button btn_speak;
    }
}