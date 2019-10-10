using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TCP.Client.Helper;

namespace TCP.Client.TCP
{
    public partial class ListenerView : Form
    {
        private string _ip;
        private int _port;
        delegate void myDelegate<T>(T t);
        myDelegate<string> myD_ShowMessage;
        private static byte[] bytes = new byte[1024*100];
        public static List<TcpClientModel> clients = new List<TcpClientModel>();
        /// <summary>
        /// 用于存储客户端
        /// </summary>
        public class TcpClientModel
        {
            /// <summary>
            /// IP:Port
            /// </summary>
            public string RemoteEndPoint { get; set; }
            /// <summary>
            /// 客户端链接对象
            /// </summary>
            public TcpClient TcpClient { get; set; }
        }
        public ListenerView()
        {
            InitializeComponent();
        }
        public ListenerView(string ip,int port)
        {
            _ip = ip;
            _port = port;
            myD_ShowMessage = new myDelegate<string>(ShowMessage);
            InitializeComponent();
            Init();
        }
        #region 控件方法
        private void ListenerView_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 刷新“已连接客户端”下拉框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_refreshClient_Click(object sender, EventArgs e)
        {
            BindClientList();
        }
        /// <summary>
        /// 发送消息到客户端
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_sentToClient_Click(object sender, EventArgs e)
        {
            TcpClient client = (TcpClient)cb_client.SelectedValue;
            string msg = "";
            bool result = TCPHelper.SendToClient(client, tb_data.Text, out msg);
            if (!result)
            {
                ShowMessage(msg);
            }

        }
        #endregion
        /// <summary>
        /// 绑定“已连接客户端”下拉框
        /// </summary>
        void BindClientList()
        {
            cb_client.DataSource = clients;
            cb_client.DisplayMember = "RemoteEndPoint";
            cb_client.ValueMember = "TcpClient";

        }
        /// <summary>
        /// 启动监听
        /// </summary>
        void Init()
        {
            try
            {
                string[] ipArray = _ip.Split('.');
                IPAddress ip = IPAddress.Parse(_ip);
                int port = _port;
                TcpListener listener = new TcpListener(ip, port);
                
                tb_console.AppendText($"IP:{_ip}\r\n");
                tb_console.AppendText($"PORT:{_port}\r\n");
                listener.Start();
                tb_console.AppendText($"监听中...\r\n");
                #region 单客户端监听
                /*
                TaskFactory tasks = new TaskFactory();
                TcpClient client = null;
                string ipaddress = string.Empty;
                //开始监听
                Thread thread = new Thread(() =>
                {
                    myDelegate<string> myD = new myDelegate<string>(ShowMessage);

                    while (true)
                    {
                        client = listener.AcceptTcpClient();
                        tasks.StartNew(() => HandleClient(client, ipaddress, myD)).Wait();
                    }
                });
                thread.IsBackground = true;
                thread.Start();
                */
                #endregion
                //异步接收 递归循环接收多个客户端
                listener.BeginAcceptTcpClient(new AsyncCallback(DoAcceptTcpclient), listener);

            }
            catch (Exception ex)
            {
                tb_console.AppendText($"stoped listening...\r\n");
                tb_console.AppendText($"ERROR:{ex.Message}\r\n");
            }
        }
        private void DoAcceptTcpclient(IAsyncResult State)
        {
            //处理多个客户端接入
            TcpListener listener = (TcpListener)State.AsyncState;
            //接收到客户端请求
            TcpClient client = listener.EndAcceptTcpClient(State);
            //保存到客户端集合中
            clients.Add(new TcpClientModel() { TcpClient=client,RemoteEndPoint=client.Client.RemoteEndPoint.ToString()});

            Invoke(myD_ShowMessage,$"\n收到新客户端:{client.Client.RemoteEndPoint.ToString()}");
            //开启线程用来持续收来自客户端的数据
            Thread myThread = new Thread(() =>{
                printReceiveMsg(client);
            });
            myThread.Start();
            listener.BeginAcceptTcpClient(new AsyncCallback(DoAcceptTcpclient), listener);
        }
        /// <summary>
        /// 响应接收的消息
        /// </summary>
        /// <param name="reciveClient"></param>
        private void printReceiveMsg(object reciveClient)
        {
            TcpClient client = reciveClient as TcpClient;
            if (client == null)
            {
                Invoke(myD_ShowMessage, $"client error");
                return;
            }
            while (true)
            {
                try
                {
                    NetworkStream stream = client.GetStream();
                    int num = stream.Read(bytes, 0, bytes.Length); //将数据读到result中，并返回字符长度                  
                    if (num != 0)
                    {
                        string str = Encoding.UTF8.GetString(bytes, 0, num);//把字节数组中流存储的数据以字符串方式赋值给str
                        //在服务器显示收到的数据
                        Invoke(myD_ShowMessage, "From: " + client.Client.RemoteEndPoint.ToString() + " : " + str);


                        //服务器收到消息后并会给客户端一个消息。
                        string msg = "服务器已收到您的消息[" + str + "]";

                        bool result = TCPHelper.SendToClient(client, msg, out msg);
                        if (!result)
                        {
                            Invoke(myD_ShowMessage, "返回消息失败: " + msg);
                        }
                    }
                    else
                    {   //这里需要注意 当num=0时表明客户端已经断开连接，需要结束循环，不然会死循环一直卡住
                        Invoke(myD_ShowMessage, $"客户端关闭");
                        break;
                    }
                }
                catch (Exception e)
                {
                    clients.Remove(clients.FirstOrDefault(m => m.RemoteEndPoint == client.Client.RemoteEndPoint.ToString()));
                    Invoke(myD_ShowMessage, "error:" + e.ToString());
                    break;
                }

            }
        }


            public void ShowMessage(string text)
        {
            tb_console.AppendText($"{text}\r\n");
        }

        
        private void HandleClient(TcpClient tcpclient, string ipadd,Delegate myD)
        {

            lock (tcpclient)
            {
                if (tcpclient == null)
                {
                    return;
                }

                // Buffer for reading data
                Byte[] bytes = new Byte[1024*100];
                String data = null;

                // Enter the listening loop.
                while (tcpclient.Connected)
                {
                    data = null;
                    NetworkStream stream = tcpclient.GetStream();
                    int i;
                    i = stream.Read(bytes, 0, bytes.Length);
                    if (i != 0)
                    {
                        data = System.Text.Encoding.UTF8.GetString(bytes, 0, i);

                        byte[] msg = System.Text.Encoding.UTF8.GetBytes($"return:{data}");
                        stream.Write(msg, 0, msg.Length);
                        Invoke(myD, data);
                        //tb_console.AppendText($"{data}\r\n");
                    }
                    //tcpclient.Close();
                }
            }
        }
        
    }
}
