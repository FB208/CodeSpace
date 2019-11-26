using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCP.Client.Models;
using TCP.Client.Helper;
using System.Data.Entity.Infrastructure;
using TCP.Client.EF;

namespace TCP.Client.Servers
{
    public class HaiKangYongChuanServer
    {
        GBEntities db = new GBEntities();
        //一个字节是几位字符
        int baseCount = 2;
        public HaiKangYongChuanModel Analyze(string codeStr)
        {
            List<string> codelist = codeStr.ToArray().Select(m => m.ToString()).ToList<string>();
            HaiKangYongChuanModel model = new HaiKangYongChuanModel();
            model.StartCode = new string[] { codelist.TakeCode(1 * baseCount), codelist.TakeCode(1 * baseCount) };
            model.LiuShui = new string[] { codelist.TakeCode(1 * baseCount), codelist.TakeCode(1 * baseCount) };
            model.XieYiBanBen = new string[] { codelist.TakeCode(1 * baseCount), codelist.TakeCode(1 * baseCount) };
            model.ShiJian = new string[] { codelist.TakeCode(1 * baseCount), codelist.TakeCode(1 * baseCount), codelist.TakeCode(1 * baseCount), codelist.TakeCode(1 * baseCount), codelist.TakeCode(1 * baseCount), codelist.TakeCode(1 * baseCount) };
            model.YuanDiZhi = new string[] { codelist.TakeCode(1 * baseCount), codelist.TakeCode(1 * baseCount), codelist.TakeCode(1 * baseCount), codelist.TakeCode(1 * baseCount), codelist.TakeCode(1 * baseCount), codelist.TakeCode(1 * baseCount) };
            model.MuDiDiZhi = new string[] { codelist.TakeCode(1 * baseCount), codelist.TakeCode(1 * baseCount), codelist.TakeCode(1 * baseCount), codelist.TakeCode(1 * baseCount), codelist.TakeCode(1 * baseCount), codelist.TakeCode(1 * baseCount) };
            string low = codelist.TakeCode(1 * baseCount);
            string heigh = codelist.TakeCode(1 * baseCount);
            model.DataLength = int.Parse(StringHelper.Convert16To10(heigh + low));// 
            model.MingLingZiJie = new string[] { codelist.TakeCode(1 * baseCount) };
            model.DataContent = codelist.TakeCode(model.DataLength * baseCount);
            model.CRC_16 = new string[] { codelist.TakeCode(1 * baseCount) };
            model.EndCode = new string[] { codelist.TakeCode(1 * baseCount), codelist.TakeCode(1 * baseCount) };

            AnalyzeDataContent(model);
            return model;
        }

        public void AnalyzeDataContent(HaiKangYongChuanModel model)
        {

            string code = model.DataContent;
            if (code.Length > 0)
            {
                List<string> codelist = code.ToArray().Select(m => m.ToString()).ToList<string>();
                //类型标识
                string LeiXingBiaoZhi = StringHelper.Convert16To10(codelist.TakeCode(1 * baseCount));
                //信息对象数目
                int bodyCount = int.Parse(StringHelper.Convert16To10(codelist.TakeCode(1 * baseCount)));
                model.Content_Information.LeiXingBiaoZhi = LeiXingBiaoZhi;
                model.Content_Information.DuiXiangShuMu = bodyCount;
                switch (model.Content_Information.LeiXingBiaoZhi)
                {
                    case "1":
                        {
                            //上传建筑消防设施系统状态 
                            for (int i = 0; i < bodyCount; i++)
                            {
                                Content_Object contentObject = new Content_Object();
                                contentObject.Content_Body = AnalyzeDataContent_1(codelist.TakeCode(4 * baseCount));
                                contentObject.ShiJianBiaoQian = codelist.TakeCode(6 * baseCount);
                                model.Content_Object.Add(contentObject);
                            }
                        }
                        break;
                    case "2":
                        {
                            //上传 建筑消防设施 部件 运行状态
                            for (int i = 0; i < bodyCount; i++)
                            {
                                Content_Object contentObject = new Content_Object();
                                contentObject.Content_Body = AnalyzeDataContent_2(codelist.TakeCode(40 * baseCount));
                                contentObject.ShiJianBiaoQian = codelist.TakeCode(6 * baseCount);
                                model.Content_Object.Add(contentObject);
                            }
                        }
                        break;
                    case "21":
                        {
                            //上传用户信息传输装置 运行状态
                            for (int i = 0; i < bodyCount; i++)
                            {
                                Content_Object contentObject = new Content_Object();
                                contentObject.Content_Body = AnalyzeDataContent_21(codelist.TakeCode(1 * baseCount));
                                contentObject.ShiJianBiaoQian = codelist.TakeCode(6 * baseCount);
                                model.Content_Object.Add(contentObject);
                            }
                        }
                        break;
                    case "24":
                        {
                            //上传用户信息传输装置操作信息
                            for (int i = 0; i < bodyCount; i++)
                            {
                                Content_Object contentObject = new Content_Object();
                                contentObject.Content_Body = AnalyzeDataContent_24(codelist.TakeCode(2 * baseCount));
                                contentObject.ShiJianBiaoQian = codelist.TakeCode(6 * baseCount);
                                model.Content_Object.Add(contentObject);
                            }
                        }
                        break;
                    case "25":
                        {
                            //上传用户信息传输装置软件版本
                            for (int i = 0; i < bodyCount; i++)
                            {
                                Content_Object contentObject = new Content_Object();
                                contentObject.Content_Body = AnalyzeDataContent_25(codelist.TakeCode(2 * baseCount));
                                //contentObject.ShiJianBiaoQian = codelist.TakeCode(6 * baseCount);
                                model.Content_Object.Add(contentObject);
                            }
                        }
                        break;
                    case "90":
                        {
                            //同步 用户 信息传输 装置时钟
                        }
                        break;
                    case "91":
                        {
                            //查岗命令
                        }
                        break;
                    default: break;

                }
            }
        }
        /// <summary>
        /// 上传建筑消防设施系统状态 
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public Content_Body AnalyzeDataContent_1(string code)
        {
            List<string> codelist = code.ToArray().Select(m => m.ToString()).ToList<string>();
            Content_Body model = new Content_Body();
            model.XiTongLeiXing = codelist.TakeCode(1 * baseCount);
            model.XiTongDiZhi = codelist.TakeCode(1 * baseCount);
            model.XiTongZhuangTai = codelist.TakeCode(2 * baseCount);
            return model;
        }
        /// <summary>
        /// //上传 建筑消防设施 部件 运行状态
        /// </summary>
        /// <param name="code">40位</param>
        public Content_Body AnalyzeDataContent_2(string code)
        {
            List<string> codelist = code.ToArray().Select(m => m.ToString()).ToList<string>();
            Content_Body model = new Content_Body();
            model.XiTongLeiXing = codelist.TakeCode(1 * baseCount);
            model.XiTongDiZhi = codelist.TakeCode(1 * baseCount);
            model.BuJianLeiXing = codelist.TakeCode(1 * baseCount);

            string dizhi = codelist.TakeCodeDesc(4 * baseCount);
            string zhuangt = codelist.TakeCodeDesc(2 * baseCount);
            model.BuJianDiZhi = dizhi;
            model.BuJianZhuangTai = zhuangt;
            model.BuJianShuoMing = codelist.TakeCode(31 * baseCount);


            return model;
        }
        /// <summary>
        /// 上传用户信息传输装置运行状态
        /// </summary>
        /// <param name="code">1位</param>
        public Content_Body AnalyzeDataContent_21(string code)
        {
            Content_Body model = new Content_Body();
            model.YongChuanYunXingZhuangTai = code;
            return model;
        }
        /// <summary>
        /// 上传用户信息传输装置运行状态
        /// </summary>
        /// <param name="code">1位</param>
        public Content_Body AnalyzeDataContent_24(string code)
        {
            Content_Body model = new Content_Body();
            List<string> codelist = code.ToArray().Select(m => m.ToString()).ToList<string>();
            model.CaoZuoXinXi = codelist.TakeCodeDesc(1 * baseCount);
            model.CaoZuoYuanBianHao = codelist.TakeCodeDesc(1 * baseCount);
            return model;
        }
        /// <summary>
        /// 上传用户信息传输装置软件版本
        /// </summary>
        /// <param name="code">1位</param>
        public Content_Body AnalyzeDataContent_25(string code)
        {
            Content_Body model = new Content_Body();
            model.YongChuanRuanJianBanBen = code;
            return model;
        }
        /// <summary>
        /// 解析部件状态
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public string AnalyzeBuJianZhuangTai(string code)
        {
            if (string.IsNullOrWhiteSpace(code))
            {
                return "";
            }
            byte[] stateBytes = StringHelper.IntToByteArray(int.Parse(code));
            StringBuilder str = new StringBuilder();
            List<Keyword> keyword = db.Keywords.Where(m => m.KeyType == "建筑消防设施部件状态").ToList();
            for (int i = 0; i < stateBytes.Length; i++)
            {
                if (stateBytes[i] == 1)
                {
                    str.Append($"{keyword.FirstOrDefault(m => m.KeyCode == i + "")?.Memo1 ?? i.ToString()}|");
                }
                else if (stateBytes[i] == 0)
                {
                    str.Append($"{keyword.FirstOrDefault(m => m.KeyCode == i + "")?.Memo0 ?? i.ToString()}|");
                }
            }
            return str.ToString();
        }
        public string AnalyzeBitCode(string code, string keyType)
        {
            if (string.IsNullOrWhiteSpace(code))
            {
                return "";
            }
            byte[] stateBytes = StringHelper.IntToByteArray(int.Parse(code.Convert16To10()));
            StringBuilder str = new StringBuilder();
            List<Keyword> keyword = db.Keywords.Where(m => m.KeyType == keyType).ToList();
            for (int i = 0; i < stateBytes.Length; i++)
            {
                if (stateBytes[i] == 1)
                {
                    str.Append($"{keyword.FirstOrDefault(m => m.KeyCode == i + "")?.Memo1 ?? i.ToString()}|");
                }
                else if (stateBytes[i] == 0)
                {
                    str.Append($"{keyword.FirstOrDefault(m => m.KeyCode == i + "")?.Memo0 ?? i.ToString()}|");
                }
            }
            return str.ToString();
        }
        /// <summary>
        /// 将时间解析成16进制国标代码
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static string TimeToCode(DateTime? time)
        {
            if (time == null)
            {
                return "";
            }
            string result = "";
            string timeStr = time?.ToString("ssmmHHddMMyy");
            for (int i = 0; i < 6; i++)
            {
                string temp = timeStr.Substring(2 * i, 2);
                result += int.Parse(temp).ToString("X").PadLeft(2, '0');
            }
            return result;
        }
        /// <summary>
        /// 将国标时间代码转换成时间
        /// </summary>
        /// <param name="timeCode"></param>
        /// <returns></returns>
        public static string CodeToTime(string timeCode)
        {
            if (string.IsNullOrWhiteSpace(timeCode))
            {
                return "";
            }
            string result = "";
            for (int i = 0; i < 6; i++)
            {
                string temp = timeCode.Substring(2 * i, 2);

                result = temp.Convert16To10() + result;
            }
            return result;
        }
        /// <summary>
        /// 将国标时间代码转换成时间
        /// </summary>
        /// <param name="timeCode">1字节16进制</param>
        /// <returns></returns>
        public static string CodeToTime(string[] timeCodes)
        {
            if (timeCodes.Length == 0)
            {
                return "";
            }
            string result = "";
            for (int i = 0; i < 6; i++)
            {
                string temp = timeCodes[i];

                result = temp.Convert16To10() + result;
            }
            return result;
        }
    }

}
