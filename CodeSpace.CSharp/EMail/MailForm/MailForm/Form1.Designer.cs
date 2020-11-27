namespace MailForm
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_login = new System.Windows.Forms.Button();
            this.tb_console = new System.Windows.Forms.TextBox();
            this.btn_count = new System.Windows.Forms.Button();
            this.btn_getone = new System.Windows.Forms.Button();
            this.btn_readline = new System.Windows.Forms.Button();
            this.btn_startTask = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_login
            // 
            this.btn_login.Location = new System.Drawing.Point(12, 12);
            this.btn_login.Name = "btn_login";
            this.btn_login.Size = new System.Drawing.Size(75, 23);
            this.btn_login.TabIndex = 0;
            this.btn_login.Text = "登录";
            this.btn_login.UseVisualStyleBackColor = true;
            this.btn_login.Click += new System.EventHandler(this.btn_login_Click);
            // 
            // tb_console
            // 
            this.tb_console.Location = new System.Drawing.Point(12, 41);
            this.tb_console.Multiline = true;
            this.tb_console.Name = "tb_console";
            this.tb_console.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tb_console.Size = new System.Drawing.Size(776, 397);
            this.tb_console.TabIndex = 1;
            // 
            // btn_count
            // 
            this.btn_count.Location = new System.Drawing.Point(93, 12);
            this.btn_count.Name = "btn_count";
            this.btn_count.Size = new System.Drawing.Size(75, 23);
            this.btn_count.TabIndex = 2;
            this.btn_count.Text = "获取邮件数";
            this.btn_count.UseVisualStyleBackColor = true;
            this.btn_count.Click += new System.EventHandler(this.btn_count_Click);
            // 
            // btn_getone
            // 
            this.btn_getone.Location = new System.Drawing.Point(174, 12);
            this.btn_getone.Name = "btn_getone";
            this.btn_getone.Size = new System.Drawing.Size(75, 23);
            this.btn_getone.TabIndex = 3;
            this.btn_getone.Text = "获取最新邮件";
            this.btn_getone.UseVisualStyleBackColor = true;
            this.btn_getone.Click += new System.EventHandler(this.btn_getone_Click);
            // 
            // btn_readline
            // 
            this.btn_readline.Location = new System.Drawing.Point(255, 12);
            this.btn_readline.Name = "btn_readline";
            this.btn_readline.Size = new System.Drawing.Size(75, 23);
            this.btn_readline.TabIndex = 4;
            this.btn_readline.Text = "读一行";
            this.btn_readline.UseVisualStyleBackColor = true;
            this.btn_readline.Click += new System.EventHandler(this.btn_readline_Click);
            // 
            // btn_startTask
            // 
            this.btn_startTask.Location = new System.Drawing.Point(336, 12);
            this.btn_startTask.Name = "btn_startTask";
            this.btn_startTask.Size = new System.Drawing.Size(110, 23);
            this.btn_startTask.TabIndex = 5;
            this.btn_startTask.Text = "启动定时任务";
            this.btn_startTask.UseVisualStyleBackColor = true;
            this.btn_startTask.Click += new System.EventHandler(this.btn_startTask_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_startTask);
            this.Controls.Add(this.btn_readline);
            this.Controls.Add(this.btn_getone);
            this.Controls.Add(this.btn_count);
            this.Controls.Add(this.tb_console);
            this.Controls.Add(this.btn_login);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_login;
        private System.Windows.Forms.TextBox tb_console;
        private System.Windows.Forms.Button btn_count;
        private System.Windows.Forms.Button btn_getone;
        private System.Windows.Forms.Button btn_readline;
        private System.Windows.Forms.Button btn_startTask;
    }
}

