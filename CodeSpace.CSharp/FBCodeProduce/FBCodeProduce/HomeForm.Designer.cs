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
            this.O_StringBuilderForm = new System.Windows.Forms.Button();
            this.btn_codeProduce = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // O_StringBuilderForm
            // 
            this.O_StringBuilderForm.Location = new System.Drawing.Point(13, 13);
            this.O_StringBuilderForm.Name = "O_StringBuilderForm";
            this.O_StringBuilderForm.Size = new System.Drawing.Size(75, 23);
            this.O_StringBuilderForm.TabIndex = 0;
            this.O_StringBuilderForm.Text = "StringBuilder";
            this.O_StringBuilderForm.UseVisualStyleBackColor = true;
            this.O_StringBuilderForm.Click += new System.EventHandler(this.O_StringBuilderForm_Click);
            // 
            // btn_codeProduce
            // 
            this.btn_codeProduce.Location = new System.Drawing.Point(115, 13);
            this.btn_codeProduce.Name = "btn_codeProduce";
            this.btn_codeProduce.Size = new System.Drawing.Size(75, 23);
            this.btn_codeProduce.TabIndex = 1;
            this.btn_codeProduce.Text = "代码生成";
            this.btn_codeProduce.UseVisualStyleBackColor = true;
            this.btn_codeProduce.Click += new System.EventHandler(this.btn_codeProduce_Click);
            // 
            // HomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_codeProduce);
            this.Controls.Add(this.O_StringBuilderForm);
            this.Name = "HomeForm";
            this.Text = "HomeForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button O_StringBuilderForm;
        private System.Windows.Forms.Button btn_codeProduce;
    }
}