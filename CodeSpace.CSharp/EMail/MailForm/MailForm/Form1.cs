using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MailForm
{
    public partial class Form1 : Form
    {
        /*
         命令	描述
        USER [username]	用户名
        PASS [password]	密码
        APOP [Name,Digest]	认可Digest是MD5消息摘要
        STAT	处理请求服务器发回关于邮箱的统计资料，如邮件总数和总字节数
        UIDL [Msg#]	处理返回邮件的唯一标识符，POP3会话的每个标识符都将是唯一的
        LIST [Msg#]	处理返回邮件数量和每个邮件的大小
        RETR [Msg#]	处理返回由参数标识的邮件的全部文本
        DELE [Msg#]	处理服务器将由参数标识的邮件标记为删除，由quit命令执行
        RSET	处理服务器将重置所有标记为删除的邮件，用于撤消DELE命令
        TOP [Msg# n]	处理服务器将返回由参数标识的邮件前n行内容，n必须是正整数
        NOOP	处理服务器返回一个肯定的响应
        QUIT	终止会话
         */
        TcpClient clientSocket;
        SslStream stream;
        StreamReader reader;
        StreamWriter writer;
        delegate void myDelegate<T>(T t);
        myDelegate<string> myD_ShowMessage;

        int currentIndex = 0;//当前邮件序号
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            clientSocket = new TcpClient();
            clientSocket.Connect("pop.qq.com", 995);//连接到QQ邮箱POP服务器
            //建立SSL连接
            stream = new SslStream(
                clientSocket.GetStream(),
                false,
                (object sender0, X509Certificate cert, X509Chain chain, SslPolicyErrors errors) => {
                    return true;//接收所有的远程SSL链接
                });
            stream.AuthenticateAsClient("pop.qq.com");//验证


            //得到输入流
            reader = new StreamReader(stream, Encoding.Default, true);
            //得到输出流
            writer = new StreamWriter(stream);

            tb_console.Text += ReadMessage(stream) + "\r\n";//reader.ReadLine()+"\r\n";


            //代理子线程
            myD_ShowMessage = new myDelegate<string>(ShowMessage);
        }
        public void ShowMessage(string text)
        {
            tb_console.AppendText($"{text}\r\n");
        }
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_login_Click(object sender, EventArgs e)
        {
            writer.WriteLine("USER 2027197042@qq.com");
            writer.Flush();
            tb_console.Text += reader.ReadLine() + "\r\n";
            //tb_console.Text += ReadMessage(stream) + "\r\n";

            writer.WriteLine("PASS hqbblqvhrgypefhe");//授权码
            writer.Flush();
            tb_console.Text += reader.ReadLine() + "\r\n";
            //tb_console.Text += ReadMessage(stream) + "\r\n";
        }
        /// <summary>
        /// 获取邮件编号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_count_Click(object sender, EventArgs e)
        {
            writer.WriteLine("STAT");
            writer.Flush();
            tb_console.Text += reader.ReadLine() + "\r\n";
            //tb_console.Text += ReadMessage(stream) + "\r\n";
        }

        private void btn_getone_Click(object sender, EventArgs e)
        {
            writer.WriteLine("RETR 1");
            writer.Flush();
            string result = reader.ReadLine();
            string base64 = result;
            while (result != ".")
            {
                base64 += result ;
                result = reader.ReadLine();
                //if (result != ".")
                //{
                //    result = reader.ReadLine();
                //}
                //else {
                //    result = null;
                //}
            }
            int headLength = base64.IndexOf("base64Mime-Version: 1.0") + 23;
            string content = base64.Substring(headLength, base64.Length - headLength);
            tb_console.Text += DecodeBase64("utf-8", content) + "\r\n";
            //tb_console.Text += ReadMessage(stream) + "\r\n";
        }

        private void btn_readline_Click(object sender, EventArgs e)
        {
            writer.WriteLine("UIDL");
            writer.Flush();
            string result = reader.ReadLine();
            string base64 = result;
            while (result != ".")
            {
                base64 += result;
                result = reader.ReadLine();
            }
            tb_console.Text += base64 + "\r\n";
        }


        #region MyRegion
        static string ReadMessage(SslStream sslStream)
        {
            byte[] buffer = new byte[1024000];
            StringBuilder messageData = new StringBuilder();
            int bytes = -1;
            do
            {
                bytes = sslStream.Read(buffer, 0, buffer.Length);
                Decoder decoder = Encoding.UTF8.GetDecoder();
                char[] chars = new char[decoder.GetCharCount(buffer, 0, bytes)];
                decoder.GetChars(buffer, 0, bytes, chars, 0);
                messageData.Append(chars);
                if (messageData.ToString().IndexOf("") != -1)
                {
                    break;
                }
            }
            while (bytes != 0);
            return messageData.ToString();
        }
        #endregion

        ///解码
        public static string DecodeBase64(string code_type, string code)
        {
            string decode = "";
            byte[] bytes = Convert.FromBase64String(code);
            try
            {
                decode = Encoding.GetEncoding(code_type).GetString(bytes);
            }
            catch
            {
                decode = code;
            }
            return decode;
        }
        /// <summary>
        /// 启动定时任务
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_startTask_Click(object sender, EventArgs e)
        {
            Thread getMailThread = new Thread(getMail);
            getMailThread.IsBackground = true;
            getMailThread.Start();
        }

        void getMail()
        {
            while (true)
            {
                writer.WriteLine("STAT");
                writer.Flush();
                //tb_console.Text += reader.ReadLine() + "\r\n";
                string str = reader.ReadLine();
                Invoke(myD_ShowMessage, str);
                int index = Convert.ToInt32(str.Split(' ')[1]);
                for (int i = currentIndex + 1; i <= index; i++)
                {
                    writer.WriteLine($"RETR {i}");
                    writer.Flush();
                    string result = reader.ReadLine();
                    string base64 = result+"\r\n";
                    while (result != ".")
                    {
                        base64 += result + "\r\n";
                        result = reader.ReadLine();
                    }
                    Invoke(myD_ShowMessage, base64);
                    //int headLength = base64.IndexOf("base64Mime-Version: 1.0") + 23;
                    //string content = base64.Substring(headLength, base64.Length - headLength);
                    //Invoke(myD_ShowMessage, DecodeBase64("utf-8", content));
                }
                currentIndex = index;
                int time = new Random().Next(4000, 7000);
                Thread.Sleep(time);
            }


        }
    }
}
