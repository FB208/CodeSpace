using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace UDP.Listener
{
    class Program
    {
        static void Main(string[] args)
        {
            UdpClient udp = new UdpClient(6000);
            IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Any, 6000);

                while (true)
                {
                    try
                    {
                        if (udp.Available < 0) continue;
                        if (udp.Client == null) return;
                        byte[] bytes = udp.Receive(ref ipEndPoint);
                        var resStr = Encoding.UTF8.GetString(bytes,0,bytes.Length);
                        Console.WriteLine(resStr);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                }


        }
    }
}
