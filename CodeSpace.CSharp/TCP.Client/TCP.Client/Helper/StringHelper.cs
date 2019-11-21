using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCP.Client.Helper
{
    public static class StringHelper
    {
        /// <summary>
        /// 16进制字符串转10进制数字
        /// </summary>
        /// <param name="str16"></param>
        /// <returns></returns>
        public static string Convert16To10(this string str16)
        {
            return int.Parse(str16, System.Globalization.NumberStyles.HexNumber).ToString();
        }
        public static string Convert16To10(this int int16)
        {
            return int.Parse(int16.ToString(), System.Globalization.NumberStyles.HexNumber).ToString();
        }
        public static string Convert10To16(this string str10)
        {
            string result = "";
            result = Convert.ToInt64(str10, 10).ToString("X").PadLeft(2, '0');
            //if (str10.Length==1)
            //{
            //    //result = Convert.ToInt64(str10,16).ToString().PadLeft(2, '0');
            //}
            //else
            //{
            //    for (int i = 0; i < str10.Length / 2; i++)
            //    {
            //        string temp = str10.Substring(i * 2, 2);
            //        result += Convert.ToInt64(str10, 16).ToString().PadLeft(2, '0');
            //    }
            //}
            return result;
        }
        /// <summary>
        /// 字符串集合中取X几位拼接成字符串
        /// </summary>
        /// <param name="list"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public static string TakeCode(this List<string> list, int count)
        {
            string result= string.Join("", list.Take(count));
            list.RemoveRange(0, count);
            return result;
        }

        public static string TakeCodeDesc(this List<string> list,int count)
        {
            List<string> thislist = list.TakeCode(count).ToArray().Select(m => m.ToString()).ToList<string>();
            string result = "";
            for (int i = 0; i < count; i=i+2)
            {
                result = thislist[i] + thislist[i + 1]+result ;
            }
            List<string> tempList = new List<string>();


            return result;
        }
        /// <summary>
        /// 字节数组转16进制字符串
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static string byteToHexStr(byte[] bytes,int length)
        {
            string returnStr = "";
            if (bytes != null)
            {
                for (int i = 0; i < length; i++)
                {
                    returnStr += bytes[i].ToString("X2");
                }
            }
            return returnStr;
        }
        /// <summary>
        /// 字符串转16进制字节数组
        /// </summary>
        /// <param name="hexString"></param>
        /// <returns></returns>
        public static byte[] strToToHexByte(string hexString)
        {
            hexString = hexString.Replace(" ", "").Trim();
            if ((hexString.Length % 2) != 0)
                hexString += " ";
            byte[] returnBytes = new byte[hexString.Length / 2];
            for (int i = 0; i < returnBytes.Length; i++)
                returnBytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            return returnBytes;
        }

        /// <summary>
        /// 十进制转二进制数组
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        public static byte[] IntToByteArray(int src)
        {
            string bitStr = Convert.ToString(src, 2);
            char[] bitArray = bitStr.ToArray();

            byte[] bytes = new byte[bitArray.Length];
            for (int i = 0; i < bitArray.Length; i++)
            {
                bytes[i] = Convert.ToByte(bitArray[i].ToString(),10);
            }
            return bytes;
        }

    }
}
