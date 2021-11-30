using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBCodeProduceWPF.Config
{
    public class UserSetting
    {
        private UserSetting() { }
        object lockObj = new object();
        private string _consultRoomName;
        private TcpServer _tcpServer;
        static bool isInit = false;

        #region 属性
        public string consultRoomName
        {
            get { return _consultRoomName; }
            set
            {
                lock (lockObj)
                {
                    _consultRoomName = value;
                    this.SaveUserSetting();
                }
            }
        }
        public TcpServer tcpServer
        {
            get { return _tcpServer; }
            set
            {
                lock (lockObj)
                {
                    _tcpServer = value;
                }
            }
        }
        #endregion



        private static UserSetting instance = null;

        public static UserSetting GetInstance()
        {
            if (instance == null)
            {
                instance = new UserSetting();
                instance.Init();
            }
            return instance;
        }

        public void Init()
        {
            isInit = true;
            string path = AppDomain.CurrentDomain.BaseDirectory + "userSetting.json";
            using (StreamReader sr = new StreamReader(path, Encoding.UTF8))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Converters.Add(new JavaScriptDateTimeConverter());
                serializer.NullValueHandling = NullValueHandling.Ignore;
                JsonReader reader = new JsonTextReader(sr);
                instance = serializer.Deserialize<UserSetting>(reader);
            }
            isInit = false;
        }

        void SaveUserSetting()
        {
            if (!isInit)
            {
                string path = AppDomain.CurrentDomain.BaseDirectory + "\\userSetting.json";
                using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.ReadWrite))
                {
                    string json = JsonConvert.SerializeObject(instance);
                    byte[] bytes = System.Text.Encoding.UTF8.GetBytes(json);
                    fs.Write(bytes, 0, bytes.Length);
                }
            }
        }
    }

    public class TcpServer
    {
        public string IP { get; set; }
        public string Port { get; set; }
    }
}
