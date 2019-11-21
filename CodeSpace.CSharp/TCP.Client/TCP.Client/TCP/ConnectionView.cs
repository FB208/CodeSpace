using Common.Standard;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TCP.Client.Helper;

namespace TCP.Client.TCP
{
    public partial class ConnectionView : Form
    {
        TcpClient client = null;
        public ConnectionView()
        {
            InitializeComponent();
            tb_ClientIP.Text = IPHelper.GetThisIP();
            tb_ClientPort.Text = "6000";
        }
        /// <summary>
        /// 创建链接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_connect_Click(object sender, EventArgs e)
        {
            string serverIP = tb_IP.Text.Trim();
            int serverPort = Convert.ToInt32(tb_port.Text.Trim());
            string clientIP = tb_ClientIP.Text.Trim();
            int clientPort = Convert.ToInt32(tb_ClientPort.Text.Trim());

            client = new TcpClient(new IPEndPoint(IPAddress.Any, clientPort));
            try
            {
                if (client.Connected == true)
                {
                    tb_Msg.AppendText("客户端已链接" + "\r\n");
                    return;
                }
                client.Connect(serverIP, serverPort);//与服务器连接
            }
            catch (Exception ex)
            {
                tb_Msg.AppendText(ex.Message + "\r\n");
                return;
            }
            tb_Msg.AppendText("connect success" + "\r\n");
        }
        /// <summary>
        /// 断开链接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Close_Click(object sender, EventArgs e)
        {
            client.Close();
        }

        private void Btn_Send_Click(object sender, EventArgs e)
        {
            if (client.Connected == false)
            {
                tb_Msg.AppendText("Client closed" + "\r\n");
                return;
            }
            string data = tb_SendData.Text.Trim();
            string errorMsg = "";
            if (data != "")
            {

                NetworkStream streamToServer = client.GetStream();
                byte[] buffer = Encoding.UTF8.GetBytes(data);

                streamToServer.Write(buffer, 0, buffer.Length);

        int num = streamToServer.Read(buffer, 0, buffer.Length);
                if (num == 0)
                {
                    tb_Msg.AppendText("Client closed" + "\r\n");
                    return;
                }
                else
                {
                    string msg = Encoding.UTF8.GetString(buffer, 0, buffer.Length);
                    tb_Msg.AppendText(msg + "\r\n");
                }

            }
        }
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
    }
}
