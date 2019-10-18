namespace TCP.Client.TCP
{
    partial class ConnectionView
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
            this.btn_Close = new System.Windows.Forms.Button();
            this.tb_port = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_IP = new System.Windows.Forms.TextBox();
            this.btn_connect = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lbl_State = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tb_Msg = new System.Windows.Forms.TextBox();
            this.tb_SendData = new System.Windows.Forms.TextBox();
            this.btn_Send = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.tb_ClientIP = new System.Windows.Forms.TextBox();
            this.tb_ClientPort = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_Close
            // 
            this.btn_Close.Location = new System.Drawing.Point(472, 11);
            this.btn_Close.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(56, 21);
            this.btn_Close.TabIndex = 16;
            this.btn_Close.Text = "断开";
            this.btn_Close.UseVisualStyleBackColor = true;
            this.btn_Close.Click += new System.EventHandler(this.Btn_Close_Click);
            // 
            // tb_port
            // 
            this.tb_port.Location = new System.Drawing.Point(264, 11);
            this.tb_port.Margin = new System.Windows.Forms.Padding(2);
            this.tb_port.Name = "tb_port";
            this.tb_port.Size = new System.Drawing.Size(120, 21);
            this.tb_port.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(215, 14);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 14;
            this.label2.Text = "端口：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 14);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 13;
            this.label1.Text = "目标IP：";
            // 
            // tb_IP
            // 
            this.tb_IP.Location = new System.Drawing.Point(66, 11);
            this.tb_IP.Margin = new System.Windows.Forms.Padding(2);
            this.tb_IP.Name = "tb_IP";
            this.tb_IP.Size = new System.Drawing.Size(138, 21);
            this.tb_IP.TabIndex = 12;
            // 
            // btn_connect
            // 
            this.btn_connect.Location = new System.Drawing.Point(400, 11);
            this.btn_connect.Margin = new System.Windows.Forms.Padding(2);
            this.btn_connect.Name = "btn_connect";
            this.btn_connect.Size = new System.Drawing.Size(56, 21);
            this.btn_connect.TabIndex = 11;
            this.btn_connect.Text = "链接";
            this.btn_connect.UseVisualStyleBackColor = true;
            this.btn_connect.Click += new System.EventHandler(this.Btn_connect_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(556, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 17;
            this.label3.Text = "当前状态:";
            // 
            // lbl_State
            // 
            this.lbl_State.AutoSize = true;
            this.lbl_State.ForeColor = System.Drawing.Color.Red;
            this.lbl_State.Location = new System.Drawing.Point(634, 17);
            this.lbl_State.Name = "lbl_State";
            this.lbl_State.Size = new System.Drawing.Size(35, 12);
            this.lbl_State.TabIndex = 18;
            this.lbl_State.Text = "CLOSE";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 244);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 23;
            this.label4.Text = "发送消息：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 85);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(113, 12);
            this.label5.TabIndex = 22;
            this.label5.Text = "接收消息(控制台)：";
            // 
            // tb_Msg
            // 
            this.tb_Msg.Location = new System.Drawing.Point(13, 100);
            this.tb_Msg.Margin = new System.Windows.Forms.Padding(2);
            this.tb_Msg.Multiline = true;
            this.tb_Msg.Name = "tb_Msg";
            this.tb_Msg.ReadOnly = true;
            this.tb_Msg.Size = new System.Drawing.Size(578, 126);
            this.tb_Msg.TabIndex = 21;
            // 
            // tb_SendData
            // 
            this.tb_SendData.Location = new System.Drawing.Point(13, 259);
            this.tb_SendData.Margin = new System.Windows.Forms.Padding(2);
            this.tb_SendData.Multiline = true;
            this.tb_SendData.Name = "tb_SendData";
            this.tb_SendData.Size = new System.Drawing.Size(581, 138);
            this.tb_SendData.TabIndex = 20;
            // 
            // btn_Send
            // 
            this.btn_Send.Location = new System.Drawing.Point(13, 401);
            this.btn_Send.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Send.Name = "btn_Send";
            this.btn_Send.Size = new System.Drawing.Size(56, 20);
            this.btn_Send.TabIndex = 19;
            this.btn_Send.Text = "发送";
            this.btn_Send.UseVisualStyleBackColor = true;
            this.btn_Send.Click += new System.EventHandler(this.Btn_Send_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 39);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 25;
            this.label6.Text = "本机IP：";
            // 
            // tb_ClientIP
            // 
            this.tb_ClientIP.Location = new System.Drawing.Point(66, 36);
            this.tb_ClientIP.Margin = new System.Windows.Forms.Padding(2);
            this.tb_ClientIP.Name = "tb_ClientIP";
            this.tb_ClientIP.ReadOnly = true;
            this.tb_ClientIP.Size = new System.Drawing.Size(138, 21);
            this.tb_ClientIP.TabIndex = 24;
            // 
            // tb_ClientPort
            // 
            this.tb_ClientPort.Location = new System.Drawing.Point(284, 36);
            this.tb_ClientPort.Margin = new System.Windows.Forms.Padding(2);
            this.tb_ClientPort.Name = "tb_ClientPort";
            this.tb_ClientPort.Size = new System.Drawing.Size(120, 21);
            this.tb_ClientPort.TabIndex = 27;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(215, 39);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 26;
            this.label7.Text = "本机端口：";
            // 
            // ConnectionView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tb_ClientPort);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tb_ClientIP);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tb_Msg);
            this.Controls.Add(this.tb_SendData);
            this.Controls.Add(this.btn_Send);
            this.Controls.Add(this.lbl_State);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.tb_port);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_IP);
            this.Controls.Add(this.btn_connect);
            this.Name = "ConnectionView";
            this.Text = "ConnectionView";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.TextBox tb_port;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_IP;
        private System.Windows.Forms.Button btn_connect;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbl_State;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tb_Msg;
        private System.Windows.Forms.TextBox tb_SendData;
        private System.Windows.Forms.Button btn_Send;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tb_ClientIP;
        private System.Windows.Forms.TextBox tb_ClientPort;
        private System.Windows.Forms.Label label7;
    }
}