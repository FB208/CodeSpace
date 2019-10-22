using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TCP.Client
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// https://www.cnblogs.com/SoftWareIe/p/9861512.html
        /// </summary>
        TcpClient client = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tb_IP.Text))
            {
                //tb_IP.Text = "127.0.0.1";
                tb_IP.Text = "123.207.187.133";
            }
            if (string.IsNullOrWhiteSpace(tb_port.Text))
            {
                tb_port.Text = "5000";
            }

        }
        /// <summary>
        /// 链接服务器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_connect_Click(object sender, EventArgs e)
        {
            client = new TcpClient();
            try
            {
                if (client.Connected==true)
                {
                    client.Close();
                }
                client.Connect(tb_IP.Text, int.Parse(tb_port.Text));      // 与服务器连接
            }
            catch (Exception ex)
            {
                tb_Msg.AppendText(ex.Message + "\r\n");
                return;
            }
            tb_Msg.AppendText("连接成功" + "\r\n");
        }

        private void Btn_Send_Click(object sender, EventArgs e)
        {
            if (client.Connected==false)
            {
                MessageBox.Show("请先链接TCP服务器");
                return;
            }
            string data = tb_SendData.Text;
            if (data != "")
            {
                NetworkStream streamToServer = client.GetStream();        //创建一个客户端的NetworkStream对象
                byte[] buffer = Encoding.UTF8.GetBytes(data);     // 获得缓存

                streamToServer.Write(buffer, 0, buffer.Length);     // 发往服务器
                int numb = streamToServer.Read(buffer, 0, buffer.Length);     //接收来自服务器传回来的数据，保存到buffer数组(byte型)中去
                string msg = Encoding.UTF8.GetString(buffer, 0, buffer.Length);   //将数组中的内容转化成string字符串，并且输出
                tb_Msg.AppendText(msg + "\r\n");
            }
        }

        private void Btn_Close_Click(object sender, EventArgs e)
        {
            client.Close();
        }

        private void Btn_UDPSend_Click(object sender, EventArgs e)
        {
            UdpClient udp = new UdpClient();

                udp.Connect(tb_IP.Text, 6000);

                                Byte[] sendByte = Encoding.UTF8.GetBytes(DateTime.Now.ToLongDateString() + tb_SendData.Text);
                               
                                udp.Send(sendByte, sendByte.Length);
                        
                         
             

        }

        private void Btn_CreateTcpService_Click(object sender, EventArgs e)
        {
            TCP.CreateListener form = new TCP.CreateListener();
            form.Show();
            
        }

        private void Btn_CreateTcpConnection_Click(object sender, EventArgs e)
        {
            TCP.ConnectionView form = new TCP.ConnectionView();
            form.Show();
        }
    }
}
