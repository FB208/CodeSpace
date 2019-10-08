﻿using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace Listener
{
    class Program
    {
        private static void HandleClient(TcpClient tcpclient, string ipadd)
        {

            //lock (tcpclient)
            //{
                if (tcpclient == null)
                {
                    return;
                }

                // Buffer for reading data
                Byte[] bytes = new Byte[10240];
                String data = null;

                // Enter the listening loop.
                while (tcpclient.Connected)
                {


                    data = null;

                    NetworkStream stream = tcpclient.GetStream();

                    int i;

                    if ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                    {
                        data = System.Text.Encoding.UTF8.GetString(bytes, 0, i);

                        byte[] msg = System.Text.Encoding.UTF8.GetBytes(data);

                        
                        //显示接收到的消息
                        Console.WriteLine(data);

                        stream.Write(msg, 0, msg.Length);
                    }
                    //tcpclient.Close();
                }
            //}
        }
        static void Main(string[] args)
        {
            try
            {
                IPAddress ip = new IPAddress(new byte[] { 127, 0, 0, 1 });
                //在3721端口新建一个TcpListener对象
                TcpListener listener = new TcpListener(ip, 80);
                listener.Start();
                Console.WriteLine("started listening..");
                TaskFactory tasks = new TaskFactory();
                TcpClient client = null;
                string ipaddress = string.Empty;
                //开始监听
                while (true)
                {
                    client = listener.AcceptTcpClient();

                    tasks.StartNew(() => HandleClient(client, ipaddress)).Wait();

                    //Socket s = listener.AcceptSocket();

                    //string remote = s.RemoteEndPoint.ToString();
                    ////允许js跨越访问
                    //var bytes = System.Text.Encoding.UTF8.GetBytes("HTTP/1.1 200 OK\r\nAccess-Control-Allow-Origin: * \r\n\r\nOK");
                    //s.Send(bytes);
                    //s.Shutdown(SocketShutdown.Send);
                }
            }
            catch (System.Security.SecurityException)
            {
                Console.WriteLine("firewall says no no to application – application cries..");
            }
            catch (Exception ex)
            {
                Console.WriteLine("stoped listening..\r\n"+ex.Message);
            }
            Console.WriteLine("Hello World!");
        }
        

    }
}
