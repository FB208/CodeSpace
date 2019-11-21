using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCP.Client.Models
{
    public class HaiKangYongChuanModel
    {
        /// <summary>
        /// 起始字符 len：2
        /// </summary>
        public string[] StartCode { get; set; }
        /// <summary>
        /// 流水号 len:2
        /// </summary>
        public string[] LiuShui { get; set; }
        /// <summary>
        /// 协议版本号 len:2
        /// </summary>
        public string[] XieYiBanBen { get; set; }
        /// <summary>
        /// 时间 len:6
        /// </summary>
        public string[] ShiJian { get; set; }
        /// <summary>
        /// 源地址 len:6
        /// </summary>
        public string[] YuanDiZhi { get; set; }
        /// <summary>
        /// 目的地址 len:6
        /// </summary>
        public string[] MuDiDiZhi { get; set; }
        /// <summary>
        /// 应用数据单元长度 len:2
        /// </summary>
        public int DataLength { get; set; }
        /// <summary>
        /// 命令字节 len:1
        /// </summary>
        public string[] MingLingZiJie { get; set; }
        /// <summary>
        /// 应用数据 len:dataLength maxlen:1024
        /// </summary>
        public string DataContent { get; set; }
        /// <summary>
        /// CRC-16校验值 len:1
        /// </summary>
        public string[] CRC_16 { get; set; }
        /// <summary>
        /// 结束符 len:2
        /// </summary>
        public string[] EndCode { get; set; }

        public Body_BuJianStateModel bodyBuJianState { get; set; }
    }

    /// <summary>
    /// 建筑消防设施部件状态
    /// </summary>
    public class Body_BuJianStateModel
    {
        /// <summary>
        /// 系统类型 len:1
        /// </summary>
        public string XiTongLeiXing { get; set; }
        /// <summary>
        /// 系统地址 len:1
        /// </summary>
        public string XiTongDiZhi { get; set; }
        /// <summary>
        /// 部件类型 len:1
        /// </summary>
        public string BuJianLeiXing { get; set; }
        /// <summary>
        /// 部件地址 len:4
        /// </summary>
        public string BuJianDiZhi { get; set; }

        /// <summary>
        /// 部件状态 len:2
        /// </summary>
        public string BuJianZhuangTai { get; set; }
        /// <summary>
        /// 部件说明 len:31
        /// </summary>
        public string BuJianShuoMing { get; set; }
    }
}
