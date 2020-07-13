namespace FBCodeProduce.Forms
{
    partial class StringBuilderForm
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
            this.tb_content = new System.Windows.Forms.TextBox();
            this.btn_clear = new System.Windows.Forms.Button();
            this.tb_Result = new System.Windows.Forms.TextBox();
            this.btn_Add = new System.Windows.Forms.Button();
            this.tb_sqlName = new System.Windows.Forms.TextBox();
            this.box_Replace = new System.Windows.Forms.GroupBox();
            this.btn_Turn = new System.Windows.Forms.Button();
            this.btn_deleteReplace = new System.Windows.Forms.Button();
            this.tb_new = new System.Windows.Forms.TextBox();
            this.tb_old = new System.Windows.Forms.TextBox();
            this.list_replace = new System.Windows.Forms.ListView();
            this.btn_addReplace = new System.Windows.Forms.Button();
            this.btn_add_product = new System.Windows.Forms.Button();
            this.box_Replace.SuspendLayout();
            this.SuspendLayout();
            // 
            // tb_content
            // 
            this.tb_content.Location = new System.Drawing.Point(12, 160);
            this.tb_content.Multiline = true;
            this.tb_content.Name = "tb_content";
            this.tb_content.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tb_content.Size = new System.Drawing.Size(610, 130);
            this.tb_content.TabIndex = 0;
            this.tb_content.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Ctrl_A);
            // 
            // btn_clear
            // 
            this.btn_clear.Location = new System.Drawing.Point(12, 13);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(75, 23);
            this.btn_clear.TabIndex = 2;
            this.btn_clear.Text = "清除";
            this.btn_clear.UseVisualStyleBackColor = true;
            this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
            // 
            // tb_Result
            // 
            this.tb_Result.Location = new System.Drawing.Point(12, 296);
            this.tb_Result.Multiline = true;
            this.tb_Result.Name = "tb_Result";
            this.tb_Result.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tb_Result.Size = new System.Drawing.Size(610, 254);
            this.tb_Result.TabIndex = 3;
            this.tb_Result.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Ctrl_A);
            // 
            // btn_Add
            // 
            this.btn_Add.Location = new System.Drawing.Point(94, 13);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(75, 23);
            this.btn_Add.TabIndex = 4;
            this.btn_Add.Text = "添加";
            this.btn_Add.UseVisualStyleBackColor = true;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // tb_sqlName
            // 
            this.tb_sqlName.Location = new System.Drawing.Point(348, 15);
            this.tb_sqlName.Name = "tb_sqlName";
            this.tb_sqlName.Size = new System.Drawing.Size(140, 21);
            this.tb_sqlName.TabIndex = 5;
            this.tb_sqlName.Text = "sql";
            // 
            // box_Replace
            // 
            this.box_Replace.Controls.Add(this.btn_Turn);
            this.box_Replace.Controls.Add(this.btn_deleteReplace);
            this.box_Replace.Controls.Add(this.tb_new);
            this.box_Replace.Controls.Add(this.tb_old);
            this.box_Replace.Controls.Add(this.list_replace);
            this.box_Replace.Controls.Add(this.btn_addReplace);
            this.box_Replace.Location = new System.Drawing.Point(12, 42);
            this.box_Replace.Name = "box_Replace";
            this.box_Replace.Size = new System.Drawing.Size(610, 112);
            this.box_Replace.TabIndex = 6;
            this.box_Replace.TabStop = false;
            this.box_Replace.Text = "替换内容";
            // 
            // btn_Turn
            // 
            this.btn_Turn.Location = new System.Drawing.Point(113, 48);
            this.btn_Turn.Name = "btn_Turn";
            this.btn_Turn.Size = new System.Drawing.Size(98, 24);
            this.btn_Turn.TabIndex = 5;
            this.btn_Turn.Text = "反转";
            this.btn_Turn.UseVisualStyleBackColor = true;
            this.btn_Turn.Click += new System.EventHandler(this.btn_Turn_Click);
            // 
            // btn_deleteReplace
            // 
            this.btn_deleteReplace.Location = new System.Drawing.Point(113, 21);
            this.btn_deleteReplace.Name = "btn_deleteReplace";
            this.btn_deleteReplace.Size = new System.Drawing.Size(98, 23);
            this.btn_deleteReplace.TabIndex = 4;
            this.btn_deleteReplace.Text = "删除";
            this.btn_deleteReplace.UseVisualStyleBackColor = true;
            this.btn_deleteReplace.Click += new System.EventHandler(this.btn_deleteReplace_Click);
            // 
            // tb_new
            // 
            this.tb_new.Location = new System.Drawing.Point(7, 48);
            this.tb_new.Name = "tb_new";
            this.tb_new.Size = new System.Drawing.Size(100, 21);
            this.tb_new.TabIndex = 3;
            // 
            // tb_old
            // 
            this.tb_old.Location = new System.Drawing.Point(7, 21);
            this.tb_old.Name = "tb_old";
            this.tb_old.Size = new System.Drawing.Size(100, 21);
            this.tb_old.TabIndex = 2;
            // 
            // list_replace
            // 
            this.list_replace.GridLines = true;
            this.list_replace.HideSelection = false;
            this.list_replace.LabelEdit = true;
            this.list_replace.Location = new System.Drawing.Point(217, 20);
            this.list_replace.Name = "list_replace";
            this.list_replace.Size = new System.Drawing.Size(387, 78);
            this.list_replace.TabIndex = 1;
            this.list_replace.UseCompatibleStateImageBehavior = false;
            this.list_replace.View = System.Windows.Forms.View.SmallIcon;
            this.list_replace.MouseClick += new System.Windows.Forms.MouseEventHandler(this.list_replace_MouseClick);
            // 
            // btn_addReplace
            // 
            this.btn_addReplace.Location = new System.Drawing.Point(6, 75);
            this.btn_addReplace.Name = "btn_addReplace";
            this.btn_addReplace.Size = new System.Drawing.Size(100, 23);
            this.btn_addReplace.TabIndex = 0;
            this.btn_addReplace.Text = "添加";
            this.btn_addReplace.UseVisualStyleBackColor = true;
            this.btn_addReplace.Click += new System.EventHandler(this.btn_addReplace_Click);
            // 
            // btn_add_product
            // 
            this.btn_add_product.Location = new System.Drawing.Point(175, 13);
            this.btn_add_product.Name = "btn_add_product";
            this.btn_add_product.Size = new System.Drawing.Size(122, 23);
            this.btn_add_product.TabIndex = 7;
            this.btn_add_product.Text = "添加(生成器自用)";
            this.btn_add_product.UseVisualStyleBackColor = true;
            this.btn_add_product.Click += new System.EventHandler(this.btn_add_product_Click);
            // 
            // StringBuilderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 562);
            this.Controls.Add(this.btn_add_product);
            this.Controls.Add(this.box_Replace);
            this.Controls.Add(this.tb_sqlName);
            this.Controls.Add(this.btn_Add);
            this.Controls.Add(this.tb_Result);
            this.Controls.Add(this.btn_clear);
            this.Controls.Add(this.tb_content);
            this.Name = "StringBuilderForm";
            this.Text = "StringBuilderForm";
            this.Load += new System.EventHandler(this.StringBuilderForm_Load);
            this.box_Replace.ResumeLayout(false);
            this.box_Replace.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_content;
        private System.Windows.Forms.Button btn_clear;
        private System.Windows.Forms.TextBox tb_Result;
        private System.Windows.Forms.Button btn_Add;
        private System.Windows.Forms.TextBox tb_sqlName;
        private System.Windows.Forms.GroupBox box_Replace;
        private System.Windows.Forms.TextBox tb_new;
        private System.Windows.Forms.TextBox tb_old;
        private System.Windows.Forms.ListView list_replace;
        private System.Windows.Forms.Button btn_addReplace;
        private System.Windows.Forms.Button btn_deleteReplace;
        private System.Windows.Forms.Button btn_Turn;
        private System.Windows.Forms.Button btn_add_product;
    }
}