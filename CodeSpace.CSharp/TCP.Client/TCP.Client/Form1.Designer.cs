namespace TCP.Client
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
            this.btn_connect = new System.Windows.Forms.Button();
            this.btn_Send = new System.Windows.Forms.Button();
            this.tb_SendData = new System.Windows.Forms.TextBox();
            this.tb_Msg = new System.Windows.Forms.TextBox();
            this.tb_IP = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_port = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_Close = new System.Windows.Forms.Button();
            this.btn_UDPSend = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_connect
            // 
            this.btn_connect.Location = new System.Drawing.Point(583, 18);
            this.btn_connect.Name = "btn_connect";
            this.btn_connect.Size = new System.Drawing.Size(75, 25);
            this.btn_connect.TabIndex = 0;
            this.btn_connect.Text = "链接";
            this.btn_connect.UseVisualStyleBackColor = true;
            this.btn_connect.Click += new System.EventHandler(this.Btn_connect_Click);
            // 
            // btn_Send
            // 
            this.btn_Send.Location = new System.Drawing.Point(15, 489);
            this.btn_Send.Name = "btn_Send";
            this.btn_Send.Size = new System.Drawing.Size(75, 25);
            this.btn_Send.TabIndex = 1;
            this.btn_Send.Text = "发送";
            this.btn_Send.UseVisualStyleBackColor = true;
            this.btn_Send.Click += new System.EventHandler(this.Btn_Send_Click);
            // 
            // tb_SendData
            // 
            this.tb_SendData.Location = new System.Drawing.Point(15, 311);
            this.tb_SendData.Multiline = true;
            this.tb_SendData.Name = "tb_SendData";
            this.tb_SendData.Size = new System.Drawing.Size(773, 172);
            this.tb_SendData.TabIndex = 2;
            // 
            // tb_Msg
            // 
            this.tb_Msg.Location = new System.Drawing.Point(15, 112);
            this.tb_Msg.Multiline = true;
            this.tb_Msg.Name = "tb_Msg";
            this.tb_Msg.Size = new System.Drawing.Size(770, 156);
            this.tb_Msg.TabIndex = 3;
            // 
            // tb_IP
            // 
            this.tb_IP.Location = new System.Drawing.Point(52, 18);
            this.tb_IP.Name = "tb_IP";
            this.tb_IP.Size = new System.Drawing.Size(183, 25);
            this.tb_IP.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "IP";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(305, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "Port";
            // 
            // tb_port
            // 
            this.tb_port.Location = new System.Drawing.Point(351, 17);
            this.tb_port.Name = "tb_port";
            this.tb_port.Size = new System.Drawing.Size(159, 25);
            this.tb_port.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "服务器消息：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 293);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 15);
            this.label4.TabIndex = 9;
            this.label4.Text = "客户端消息：";
            // 
            // btn_Close
            // 
            this.btn_Close.Location = new System.Drawing.Point(680, 18);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(75, 25);
            this.btn_Close.TabIndex = 10;
            this.btn_Close.Text = "断开";
            this.btn_Close.UseVisualStyleBackColor = true;
            this.btn_Close.Click += new System.EventHandler(this.Btn_Close_Click);
            // 
            // btn_UDPSend
            // 
            this.btn_UDPSend.Location = new System.Drawing.Point(15, 49);
            this.btn_UDPSend.Name = "btn_UDPSend";
            this.btn_UDPSend.Size = new System.Drawing.Size(75, 23);
            this.btn_UDPSend.TabIndex = 11;
            this.btn_UDPSend.Text = "UDPSend";
            this.btn_UDPSend.UseVisualStyleBackColor = true;
            this.btn_UDPSend.Click += new System.EventHandler(this.Btn_UDPSend_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 615);
            this.Controls.Add(this.btn_UDPSend);
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tb_port);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_IP);
            this.Controls.Add(this.tb_Msg);
            this.Controls.Add(this.tb_SendData);
            this.Controls.Add(this.btn_Send);
            this.Controls.Add(this.btn_connect);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_connect;
        private System.Windows.Forms.Button btn_Send;
        private System.Windows.Forms.TextBox tb_SendData;
        private System.Windows.Forms.TextBox tb_Msg;
        private System.Windows.Forms.TextBox tb_IP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_port;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Button btn_UDPSend;
    }
}

