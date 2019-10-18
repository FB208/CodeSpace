using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TCP.Client.Helper
{
    public static class TCPHelper
    {
        public static bool SendToClient(this TcpClient client, string message,out string errorMsg)
        {
            try
            {
                byte[] bytes = new byte[1024 * 100];
                bytes = Encoding.UTF8.GetBytes(message);
                NetworkStream stream = client.GetStream();
                    stream.Write(bytes, 0, bytes.Length);
                stream.Flush();
                errorMsg = "";
                return true;
            }
            catch (Exception ex)
            {
                errorMsg = ex.Message;
                return false;
            }
        }
    }
}
