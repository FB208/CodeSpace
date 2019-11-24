using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TCP.Client.EF;
using TCP.Client.Helper;
using TCP.Client.Models;
using TCP.Client.Servers;

namespace TCP.Client.TCP
{
    public partial class ListenerView : Form
    {
        private string _ip;
        private int _port;
        delegate void myDelegate<T>(T t);
        myDelegate<string> myD_ShowMessage;
        private static byte[] bytes = new byte[1024 * 100];
        GBEntities db = new GBEntities();
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
        public ListenerView(string ip, int port)
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
                IPAddress ip = IPAddress.Parse(_ip);
                int port = _port;
                TcpListener listener = new TcpListener(ip, port);

                tb_console.AppendText($"IP:{_ip}\r\n");
                tb_console.AppendText($"PORT:{_port}\r\n");
                listener.Start();
                tb_console.AppendText($"Listener...\r\n");
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
                listener.BeginAcceptTcpClient(new AsyncCallback(GetAcceptTcpclient), listener);

            }
            catch (Exception ex)
            {
                tb_console.AppendText($"stoped listening...\r\n");
                tb_console.AppendText($"ERROR:{ex.Message}\r\n");
            }
        }
        private void GetAcceptTcpclient(IAsyncResult State)
        {
            //处理多个客户端接入
            TcpListener listener = (TcpListener)State.AsyncState;
            //接收到客户端请求
            TcpClient client = listener.EndAcceptTcpClient(State);
            //保存到客户端集合中
            clients.Add(new TcpClientModel() { TcpClient = client, RemoteEndPoint = client.Client.RemoteEndPoint.ToString() });

            Invoke(myD_ShowMessage, $"\nGet a new client:{client.Client.RemoteEndPoint.ToString()}");
            //开启线程用来持续接收来自客户端的数据
            Thread myThread = new Thread(() =>
            {
                ReceiveMsgFromClient(client);
            });
            myThread.Start();
            listener.BeginAcceptTcpClient(new AsyncCallback(GetAcceptTcpclient), listener);
        }
        /// <summary>
        /// 响应接收的消息
        /// </summary>
        /// <param name="reciveClient"></param>
        private void ReceiveMsgFromClient(object reciveClient)
        {
            TcpClient client = reciveClient as TcpClient;
            if (client == null)
            {
                Invoke(myD_ShowMessage, $"client error");
                return;
            }
            while (true)
            {
                //try
                //{
                NetworkStream stream = client.GetStream();
                int num = stream.Read(bytes, 0, bytes.Length); //将数据读到result中，并返回字符长度                  
                if (num != 0)
                {
                    string str = StringHelper.byteToHexStr(bytes, num);
                    //string str = Encoding.UTF8.GetString(bytes, 0, num);//把字节数组中流存储的数据以字符串方式赋值给str
                    //在服务器显示收到的数据
                    Invoke(myD_ShowMessage, "From: " + client.Client.RemoteEndPoint.ToString() + " : " + str);
                    //解析收到的数据
                    HaiKangYongChuanServer server = new HaiKangYongChuanServer();
                    HaiKangYongChuanModel reqModel = server.Analyze(str);
                    //显示内容
                    StringBuilder showStr = new StringBuilder();
                    showStr.Append($"\r\n");
                    showStr.Append($"流水号：{string.Join("",reqModel.LiuShui)}\r\n");
                    showStr.Append($"协议版本号：{string.Join("", reqModel.XieYiBanBen)}\r\n");
                    showStr.Append($"时间：{HaiKangYongChuanServer.CodeToTime(reqModel.ShiJian)}\r\n");
                    showStr.Append($"源地址：{string.Join("", reqModel.YuanDiZhi)}\r\n");
                    showStr.Append($"目的地址：{string.Join("", reqModel.MuDiDiZhi)}\r\n");
                    string mingLingZiJie = reqModel.MingLingZiJie[0].Convert16To10();
                    showStr.Append($"命令：{db.Keywords.FirstOrDefault(m=>m.KeyType== "控制单元命令"&&m.KeyCode== mingLingZiJie)?.KeyContent?? mingLingZiJie}\r\n");
                    showStr.Append($"数据单元类型：{db.Keywords.FirstOrDefault(m => m.KeyType == "数据单元标识符_类型标志" && m.KeyCode == reqModel.Content_Information.LeiXingBiaoZhi)?.KeyContent ?? reqModel.Content_Information.LeiXingBiaoZhi}\r\n");
                    showStr.Append($"接收到{reqModel.Content_Object.Count}个信息对象\r\n");
                    foreach (var item in reqModel.Content_Object)
                    {
                        //上传 建筑消防设施 部件 运行状态
                        showStr.Append($"---------------------\r\n");
                        //showStr.Append($"信息类型：{db.Keywords.FirstOrDefault(m => m.KeyType == "数据单元标识符_类型标志" && m.KeyCode == reqModel. )}\n");
                        string xiTongLeiXing = item.Content_Body.XiTongLeiXing?.TrimStart('0');
                        showStr.Append($"系统类型：{db.Keywords.FirstOrDefault(m => m.KeyType == "系统类型" && m.KeyCode == xiTongLeiXing)?.KeyContent ?? item.Content_Body.XiTongLeiXing}\r\n");
                        showStr.Append($"系统地址：{item.Content_Body.XiTongDiZhi}\r\n");
                        showStr.Append($"系统状态：{new HaiKangYongChuanServer().AnalyzeBitCode(item.Content_Body.XiTongZhuangTai, "建筑消防设施系统状态")}\r\n");
                        string buJianLeiXing = item.Content_Body.BuJianLeiXing?.TrimStart('0');
                        showStr.Append($"部件类型：{db.Keywords.FirstOrDefault(m => m.KeyType == "部件类型" && m.KeyCode == buJianLeiXing)?.KeyContent ?? item.Content_Body.BuJianLeiXing}\r\n");
                        showStr.Append($"部件地址：{item.Content_Body.BuJianDiZhi}\r\n");
                        showStr.Append($"部件状态：{new HaiKangYongChuanServer().AnalyzeBuJianZhuangTai(item.Content_Body.BuJianZhuangTai)}\r\n");

                        showStr.Append($"部件说明：{item.Content_Body.BuJianShuoMing}\r\n");
                        //说明解码
                        //Encoding gb18030 = Encoding.GetEncoding("GB18030");
                        //byte[] smbytes = StringHelper.strToToHexByte(item.Content_Body.BuJianShuoMing);
                        //string smStr = gb18030.GetString(smbytes);

                        //上传用户信息传输装置 运行状态
                        showStr.Append($"用户信息传输装置运行状态：{new HaiKangYongChuanServer().AnalyzeBitCode(item.Content_Body.YongChuanYunXingZhuangTai, "用户信息传输装置运行状态")}\r\n");
                        //上传用户信息传输装置软件版本
                        showStr.Append($"用户信息传输装置软件版本：{item.Content_Body.YongChuanRuanJianBanBen}\r\n");
                        showStr.Append($"操作信息：{new HaiKangYongChuanServer().AnalyzeBitCode(item.Content_Body.CaoZuoXinXi, "用户信息传输装置操作标志")}\r\n");
                        showStr.Append($"操作员编号：{item.Content_Body.CaoZuoYuanBianHao}\r\n");
                        showStr.Append($"时间标签：{HaiKangYongChuanServer.CodeToTime(item.ShiJianBiaoQian)}\r\n");
                        showStr.Append($"\r\n");
                        
                    }
                    Invoke(myD_ShowMessage, showStr.ToString());



                    //FileStream fs = new FileStream(Application.StartupPath+@"//test.txt", FileMode.OpenOrCreate, FileAccess.Write);
                    //fs.Write(bytes, 0, bytes.Length);
                    //fs.Close();
                    //服务器收到消息后并会给客户端一个消息。
                    //string msg = "Your message has been received by the server[" + str + "]";
                    StringBuilder returnStr = new StringBuilder();
                    returnStr.Append(reqModel.StartCode[0]);
                    returnStr.Append(reqModel.StartCode[1]);
                    returnStr.Append(reqModel.LiuShui[0]);
                    returnStr.Append(reqModel.LiuShui[1]);
                    returnStr.Append(reqModel.XieYiBanBen[0]);
                    returnStr.Append(reqModel.XieYiBanBen[1]);
                    returnStr.Append(HaiKangYongChuanServer.TimeToCode(DateTime.Now));
                    returnStr.Append(reqModel.MuDiDiZhi[0]);//回发时把原地址和目的地址调转
                    returnStr.Append(reqModel.MuDiDiZhi[1]);
                    returnStr.Append(reqModel.MuDiDiZhi[2]);
                    returnStr.Append(reqModel.MuDiDiZhi[3]);
                    returnStr.Append(reqModel.MuDiDiZhi[4]);
                    returnStr.Append(reqModel.MuDiDiZhi[5]);
                    returnStr.Append(reqModel.YuanDiZhi[0]);//回发时把原地址和目的地址调转
                    returnStr.Append(reqModel.YuanDiZhi[1]);
                    returnStr.Append(reqModel.YuanDiZhi[2]);
                    returnStr.Append(reqModel.YuanDiZhi[3]);
                    returnStr.Append(reqModel.YuanDiZhi[4]);
                    returnStr.Append(reqModel.YuanDiZhi[5]);
                    returnStr.Append("0000");//应用数据单元长度为0
                    returnStr.Append("03");//命令字节：确认
                    //crc校验
                    int checksum = 0;
                    string checkStr = returnStr.ToString().Substring(4, returnStr.ToString().Length - 4);
                    byte[] c = StringHelper.strToToHexByte(checkStr);
                    for (int i = 0; i < c.Length; i++)
                    {
                        checksum += c[i];
                    }
                    var crc64 = (byte)(checksum & 0xFF);
                    returnStr.Append(crc64.ToString().Convert10To16());
                    returnStr.Append(reqModel.EndCode[0]);
                    returnStr.Append(reqModel.EndCode[1]);
                    string msg = returnStr.ToString();
                    bool result = TCPHelper.SendToClient(client, msg, out msg);
                    if (!result)
                    {
                        Invoke(myD_ShowMessage, "Return message faild: " + msg);
                    }
                }
                else
                {   //这里需要注意 当num=0时表明客户端已经断开连接，需要结束循环，不然会死循环一直卡住
                    Invoke(myD_ShowMessage, $"Client closed");
                    break;
                }
                //}
                //catch (Exception e)
                //{
                //    //链接失败 从集合中移除出错客户端
                //    clients.Remove(clients.FirstOrDefault(m => m.RemoteEndPoint == client.Client.RemoteEndPoint.ToString()));
                //    Invoke(myD_ShowMessage, "error:" + e.ToString());
                //    break;
                //}

            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="srcEncoding">原编码</param>
        /// <param name="dstEncoding">目标编码</param>
        /// <param name="srcBytes">原</param>
        public static void OutputByEncoding(Encoding srcEncoding, Encoding dstEncoding, string srcStr)
        {
            byte[] srcBytes = srcEncoding.GetBytes(srcStr);
            Console.WriteLine("Encoding.GetBytes: {0}", BitConverter.ToString(srcBytes));
            byte[] bytes = Encoding.Convert(srcEncoding, dstEncoding, srcBytes);
            Console.WriteLine("Encoding.GetBytes: {0}", BitConverter.ToString(bytes));
            string result = dstEncoding.GetString(bytes);
            Console.WriteLine("Encoding.GetString: {0}", result);
        }

        public void ShowMessage(string text)
        {
            tb_console.AppendText($"{text}\r\n");
        }


    }
}
