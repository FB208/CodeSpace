using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Common.Standard
{
    public static class IPHelper
    {
        /// <summary>
        /// 获取本地IP地址信息
        /// </summary>
        public static string GetThisIP()
        {
            ///获取本地的IP地址
            string AddressIP = string.Empty;
            foreach (IPAddress _IPAddress in Dns.GetHostEntry(Dns.GetHostName()).AddressList)
            {
                if (_IPAddress.AddressFamily.ToString() == "InterNetwork")
                {
                    AddressIP = _IPAddress.ToString();
                }
            }
            return AddressIP;
        }
    }
}
