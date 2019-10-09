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

namespace TCP.Client.TCP
{
    public partial class ListenerView : Form
    {
        private string _ip;
        private int _port;
        delegate void myDelegate<T>(T t);
        public ListenerView()
        {
            InitializeComponent();
        }
        public ListenerView(string ip,int port)
        {
            _ip = ip;
            _port = port;
            InitializeComponent();
            Init();
            //new Thread(() =>
            //{
            //    myDelegate myD = new myDelegate(Init);
            //    Invoke(myD);
            //}).Start();

        }
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
                TaskFactory tasks = new TaskFactory();
                TcpClient client = null;
                string ipaddress = string.Empty;
                //开始监听
                Thread thread = new Thread(() =>{
                    myDelegate<string> myD = new myDelegate<string>(ShowMessage);
                    
                    while (true)
                    {
                        client = listener.AcceptTcpClient();
                        tasks.StartNew(() => HandleClient(client, ipaddress,myD)).Wait();
                    }
                });
                thread.IsBackground = true;
                thread.Start();
                
            }
            catch (Exception ex)
            {
                tb_console.AppendText($"stoped listening...\r\n");
                tb_console.AppendText($"ERROR:{ex.Message}\r\n");
            }
        }
        public void ShowMessage(string text)
        {
            tb_console.AppendText($"{text}\r\n");
        }
        private void ListenerView_Load(object sender, EventArgs e)
        {
            
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
