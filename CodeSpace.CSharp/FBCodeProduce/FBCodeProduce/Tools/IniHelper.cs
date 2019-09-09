using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace FBCodeProduce.Tools
{
    public class IniHelper
    {
        private static string defaultFilePath = Application.StartupPath + "\\Config.ini";//获取INI文件路径
        private string strSec = ""; //INI文件名
        

        #region 公共方法
        /// <summary>
        /// 根据Key读取Value
        /// </summary>
        /// <param name="sectionName">section名称</param>
        /// <param name="key">key的名称</param>
        /// <param name="filePath">文件路径</param>
        public static string GetValue(string sectionName, string key, string filePath="")
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                filePath = defaultFilePath;
            }
            byte[] buffer = new byte[2048];
            int length = GetPrivateProfileString(sectionName, key, "发生错误", buffer, 999, filePath);
            string rs = System.Text.UTF8Encoding.Default.GetString(buffer, 0, length);
            return rs;
        }
        /// <summary>
        /// 获取ini文件内所有的section名称
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <returns>返回一个包含section名称的集合</returns>
        public static List<string> GetSectionNames(string filePath="")
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                filePath = defaultFilePath;
            }
            byte[] buffer = new byte[2048];
            int length = GetPrivateProfileString(null, "", "", buffer, 999, filePath);
            String[] rs = System.Text.UTF8Encoding.Default.GetString(buffer, 0, length).Split(new string[] { "\0" }, StringSplitOptions.RemoveEmptyEntries);
            return rs.ToList();
        }
        /// <summary>
        /// 获取指定section内的所有key
        /// </summary>
        /// <param name="sectionName">section名称</param>
        /// <param name="filePath">文件路径</param>
        /// <returns>返回一个包含key名称的集合</returns>
        public static List<string> GetKeys(string sectionName, string filePath="")
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                filePath = defaultFilePath;
            }
            byte[] buffer = new byte[2048];
            int length = GetPrivateProfileString(sectionName, null, "", buffer, 999, filePath);
            String[] rs = System.Text.UTF8Encoding.Default.GetString(buffer, 0, length).Split(new string[] { "\0" }, StringSplitOptions.RemoveEmptyEntries);
            return rs.ToList();
        }

        /// <summary>
        /// 保存内容到ini文件
        /// <para>若存在相同的key，就覆盖，否则就增加</para>
        /// </summary>
        /// <param name="sectionName">section名称</param>
        /// <param name="key">key的名称</param>
        /// <param name="value">存储的值</param>
        /// <param name="filePath">文件路径</param>
        public static bool SetValue(string sectionName, string key, string value, string filePath="")
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                filePath = defaultFilePath;
            }
            int rs = (int)WritePrivateProfileString(sectionName, key, value, filePath);
            return rs > 0;
        }
        /// <summary>
        /// 移除指定的section
        /// </summary>
        /// <param name="sectionName">section名称</param>
        /// <param name="filePath">文件路径</param>
        /// <returns></returns>
        public static bool RemoveSection(string sectionName, string filePath="")
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                filePath = defaultFilePath;
            }
            int rs = (int)WritePrivateProfileString(sectionName, null, "", filePath);
            return rs > 0;
        }
        /// <summary>
        /// 移除指定的key
        /// </summary>
        /// <param name="sectionName">section名称</param>
        /// <param name="filePath">文件路径</param>
        /// <returns></returns>
        public static bool Removekey(string sectionName, string key, string filePath="")
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                filePath = defaultFilePath;
            }
            int rs = (int)WritePrivateProfileString(sectionName, key, null, filePath);
            return rs > 0;
        }

        #endregion


        #region 私有方法
        /// <summary>
        /// 读取操作
        /// </summary>
        /// <param name="sectionName">{string | null}：要读区的区域名。若传入null值，第4个参数returnBuffer将会获得所有的section name</param>
        /// <param name="key"> {string | null}：key的名称。若传入null值，第4个参数returnBuffer将会获得所有的指定sectionName下的所有key name</param>
        /// <param name="defaultValue">{string}：key没找到时的返回值。</param>
        /// <param name="returnBuffer">{byte[]}：key所对应的值。</param>
        /// <param name="size"></param>
        /// <param name="filePath">{string}：ini文件路径。</param>
        /// <returns></returns>
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string sectionName, string key, string defaultValue, byte[] returnBuffer, int size, string filePath);

        /// <summary>
        /// 写入操作
        /// </summary>
        /// <param name="sectionName">{string}：要写入的区域名</param>
        /// <param name="key">{string | null}：key的名称。若传入null值，将移除指定的section</param>
        /// <param name="value">{string | null}：设置key所对应的值。若传入null值，将移除指定的key</param>
        /// <param name="filePath">{string}：ini文件路径</param>
        /// <returns></returns>
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string sectionName, string key, string value, string filePath);
        #endregion
    }
}
