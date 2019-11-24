using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCP.Client.Models
{
    public class HaiKangYongChuanModel
    {
        public HaiKangYongChuanModel() {
            Content_Information = new Content_Information();
            Content_Object = new List<Content_Object>();
        }
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
        /// <summary>
        /// 数据单元标识符
        /// </summary>
        public Content_Information Content_Information { get; set; }
        /// <summary>
        /// 信息对象
        /// </summary>
        public List<Content_Object> Content_Object { get; set; }
    }
    /// <summary>
    /// 数据单元标识符
    /// </summary>
    public class Content_Information {
        /// <summary>
        /// 类型标志
        /// </summary>
        public string LeiXingBiaoZhi { get; set; }
        /// <summary>
        /// 信息对象数目
        /// </summary>
        public int DuiXiangShuMu { get; set; }
    }
    public class Content_Object
    {
        /// <summary>
        /// 信息对象数目
        /// </summary>
        public Content_Body Content_Body { get; set; }
        /// <summary>
        /// 时间标签
        /// </summary>
        public string ShiJianBiaoQian { get; set; }
    }
    /// <summary>
    /// 建筑消防设施部件状态
    /// </summary>
    public class Content_Body
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
        /// 系统状态 len:2
        /// </summary>
        public string XiTongZhuangTai { get; set; }
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
        /// <summary>
        /// 用户信息传输装置运行状态 len:1
        /// </summary>
        public string YongChuanYunXingZhuangTai { get; set; }
        /// <summary>
        /// 用户信息传输装置软件版本 len:2
        /// </summary>
        public string YongChuanRuanJianBanBen { get; set; }
        /// <summary>
        /// 操作信息
        /// </summary>
        public string CaoZuoXinXi { get; set; }
        /// <summary>
        /// 操作员编号
        /// </summary>
        public string CaoZuoYuanBianHao { get; set; }
    }
}
