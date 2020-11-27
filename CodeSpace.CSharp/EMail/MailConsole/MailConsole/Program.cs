using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MailConsole
{
    class Program
    {
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
        static void Main(string[] args)
        {
            DecodeBase64("utf-8",)

        //    TcpClient clientSocket = new TcpClient();
        //    clientSocket.Connect("pop.qq.com", 995);//连接到QQ邮箱POP服务器
        //    //建立SSL连接
        //    SslStream stream = new SslStream(
        //        clientSocket.GetStream(),
        //        false,
        //        (object sender, X509Certificate cert, X509Chain chain, SslPolicyErrors errors) => {
        //            return true;//接收所有的远程SSL链接
        //        });
        //    stream.AuthenticateAsClient("pop.qq.com");//验证

            //    //得到输入流
            //    StreamReader reader = new StreamReader(stream, Encoding.Default, true);
            //    //得到输出流
            //    StreamWriter writer = new StreamWriter(stream);

            //    Console.WriteLine(reader.ReadLine());//以+Ok开头，表示连接成功

            //    writer.WriteLine("USER 2027197042@qq.com");
            //    writer.Flush();
            //    Console.WriteLine(reader.ReadLine());//+Ok 表示用户名正确

            //    writer.WriteLine("PASS hqbblqvhrgypefhe");//授权码
            //    writer.Flush();
            //    Console.WriteLine(reader.ReadLine());//+Ok 表示密码正确


            //    try
            //    {
            //        writer.WriteLine("STAT");
            //        writer.Flush();
            //        Console.WriteLine(reader.ReadLine());//获得邮件数 +OK 189 1058197  表示 189封邮件，1058197b

            //        writer.WriteLine("RETR 1");
            //        writer.Flush();
            //        String result = null;//获得第1封邮件的内容，读取的内容需要使用base64解码
            //        string content = reader.ReadLine();
            //        while (content != null)
            //        {
            //            Console.WriteLine(content);
            //            content = reader.ReadLine();
            //        }
            //        writer.WriteLine("STAT");
            //        writer.Flush();
            //        Console.WriteLine(reader.ReadLine());
            //    }
            //    catch (Exception ex)
            //    {

            //        throw;
            //    }


            Console.ReadLine();
        }
    }
}
