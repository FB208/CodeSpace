namespace TCP.Client.TCP
{
    partial class ListenerView
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
            this.tb_console = new System.Windows.Forms.TextBox();
            this.cb_client = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_refreshClient = new System.Windows.Forms.Button();
            this.tb_data = new System.Windows.Forms.TextBox();
            this.btn_sentToClient = new System.Windows.Forms.Button();
            this.cb_IsSetTime = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // tb_console
            // 
            this.tb_console.Location = new System.Drawing.Point(17, 16);
            this.tb_console.Margin = new System.Windows.Forms.Padding(4);
            this.tb_console.Multiline = true;
            this.tb_console.Name = "tb_console";
            this.tb_console.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.tb_console.Size = new System.Drawing.Size(576, 440);
            this.tb_console.TabIndex = 0;
            // 
            // cb_client
            // 
            this.cb_client.FormattingEnabled = true;
            this.cb_client.Location = new System.Drawing.Point(92, 470);
            this.cb_client.Margin = new System.Windows.Forms.Padding(4);
            this.cb_client.Name = "cb_client";
            this.cb_client.Size = new System.Drawing.Size(393, 23);
            this.cb_client.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 474);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "客户端";
            // 
            // btn_refreshClient
            // 
            this.btn_refreshClient.Location = new System.Drawing.Point(495, 468);
            this.btn_refreshClient.Margin = new System.Windows.Forms.Padding(4);
            this.btn_refreshClient.Name = "btn_refreshClient";
            this.btn_refreshClient.Size = new System.Drawing.Size(100, 29);
            this.btn_refreshClient.TabIndex = 3;
            this.btn_refreshClient.Text = "刷新";
            this.btn_refreshClient.UseVisualStyleBackColor = true;
            this.btn_refreshClient.Click += new System.EventHandler(this.Btn_refreshClient_Click);
            // 
            // tb_data
            // 
            this.tb_data.Location = new System.Drawing.Point(17, 514);
            this.tb_data.Margin = new System.Windows.Forms.Padding(4);
            this.tb_data.Multiline = true;
            this.tb_data.Name = "tb_data";
            this.tb_data.Size = new System.Drawing.Size(468, 98);
            this.tb_data.TabIndex = 4;
            // 
            // btn_sentToClient
            // 
            this.btn_sentToClient.Location = new System.Drawing.Point(496, 582);
            this.btn_sentToClient.Margin = new System.Windows.Forms.Padding(4);
            this.btn_sentToClient.Name = "btn_sentToClient";
            this.btn_sentToClient.Size = new System.Drawing.Size(100, 29);
            this.btn_sentToClient.TabIndex = 5;
            this.btn_sentToClient.Text = "发送";
            this.btn_sentToClient.UseVisualStyleBackColor = true;
            this.btn_sentToClient.Click += new System.EventHandler(this.Btn_sentToClient_Click);
            // 
            // cb_IsSetTime
            // 
            this.cb_IsSetTime.AutoSize = true;
            this.cb_IsSetTime.Location = new System.Drawing.Point(17, 619);
            this.cb_IsSetTime.Name = "cb_IsSetTime";
            this.cb_IsSetTime.Size = new System.Drawing.Size(384, 19);
            this.cb_IsSetTime.TabIndex = 7;
            this.cb_IsSetTime.Text = "在收到[28-上传系统时间]后答复设置当前时间的指令";
            this.cb_IsSetTime.UseVisualStyleBackColor = true;
            // 
            // ListenerView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(611, 681);
            this.Controls.Add(this.cb_IsSetTime);
            this.Controls.Add(this.btn_sentToClient);
            this.Controls.Add(this.tb_data);
            this.Controls.Add(this.btn_refreshClient);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cb_client);
            this.Controls.Add(this.tb_console);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ListenerView";
            this.Text = "ListenerView";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ListenerView_FormClosing);
            this.Load += new System.EventHandler(this.ListenerView_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_console;
        private System.Windows.Forms.ComboBox cb_client;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_refreshClient;
        private System.Windows.Forms.TextBox tb_data;
        private System.Windows.Forms.Button btn_sentToClient;
        private System.Windows.Forms.CheckBox cb_IsSetTime;
    }
}