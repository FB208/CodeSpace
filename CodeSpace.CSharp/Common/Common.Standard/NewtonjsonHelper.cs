using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Common.Standard
{
    public class NewtonjsonHelper
    {
        /// <summary>
        /// 读取Json
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static JObject ReadFile(string path)
        {
            using (StreamReader sr = new StreamReader(path))
            {
                JsonReader reader = new JsonTextReader(sr);
                JObject jobj = JObject.Load(reader);
                return jobj;
            }
        }
        /// <summary>
        /// JObject 写入json文件
        /// </summary>
        /// <param name="path"></param>
        /// <param name="json"></param>
        /// <returns></returns>
        public static bool WriteFile(string path,JObject json)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(path))
                {
                    using (JsonWriter write = new JsonTextWriter(sw))
                    {
                        json.WriteTo(write);
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
    }
}
