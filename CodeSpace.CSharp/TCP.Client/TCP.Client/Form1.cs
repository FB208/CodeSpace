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
using TCP.Client.Servers;

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




            #region 二进制翻译
            //string str_16 = "4040120001012e2110120b136653f0660c000000000000003000020201010112ff00ff00030001a0a0a0a0a0a0a0a0a0a0a0a0a0a0a0a0a0a0a0a000000000000000000000002511110119ea2323";
            //List<int> str_10_list = new List<int>();
            //for (int i = 0; i < str_16.Length; i=i+2)
            //{
            //    string one_str_16 = str_16.Substring(i, 2);
            //    int one_int_16=int.Parse(one_str_16,
            //    System.Globalization.NumberStyles.HexNumber);

            //    str_10_list.Add(one_int_16);
            //}
            //new HaiKangYongChuanServer().Analyze(str_16);
            #endregion
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
        private string StringToHexString(string s, Encoding encode)
        {
            byte[] b = encode.GetBytes(s);//按照指定编码将string编程字节数组
            string result = string.Empty;
            for (int i = 0; i < b.Length; i++)//逐字节变为16进制字符
            {
                result += Convert.ToString(b[i], 16);
            }
            return result;
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
