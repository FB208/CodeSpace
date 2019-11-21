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
            List<string> codelist =codeStr.ToArray().Select(m=>m.ToString()).ToList<string>();
            HaiKangYongChuanModel model = new HaiKangYongChuanModel();
            model.StartCode = new string[] { codelist.TakeCode(1 * baseCount), codelist.TakeCode(1 * baseCount)};
            model.LiuShui = new string[] { codelist.TakeCode(1 * baseCount), codelist.TakeCode(1 * baseCount) };
            model.XieYiBanBen = new string[] { codelist.TakeCode(1 * baseCount), codelist.TakeCode(1 * baseCount) };
            model.ShiJian = new string[] { codelist.TakeCode(1 * baseCount), codelist.TakeCode(1 * baseCount), codelist.TakeCode(1 * baseCount), codelist.TakeCode(1 * baseCount), codelist.TakeCode(1 * baseCount), codelist.TakeCode(1 * baseCount) };
            model.YuanDiZhi = new string[] { codelist.TakeCode(1 * baseCount), codelist.TakeCode(1 * baseCount), codelist.TakeCode(1 * baseCount), codelist.TakeCode(1 * baseCount), codelist.TakeCode(1 * baseCount), codelist.TakeCode(1 * baseCount) };
            model.MuDiDiZhi = new string[] { codelist.TakeCode(1 * baseCount), codelist.TakeCode(1 * baseCount), codelist.TakeCode(1 * baseCount), codelist.TakeCode(1 * baseCount), codelist.TakeCode(1 * baseCount), codelist.TakeCode(1 * baseCount) };
            string low = codelist.TakeCode(1 * baseCount);
            string heigh = codelist.TakeCode(1 * baseCount);
            model.DataLength = int.Parse(heigh + low);
            model.MingLingZiJie = new string[] { codelist.TakeCode(1 * baseCount) };
            model.DataContent = codelist.TakeCode(int.Parse(model.DataLength.Convert16To10())*baseCount);
            model.CRC_16 = new string[] { codelist.TakeCode(1 * baseCount) };
            model.EndCode = new string[] { codelist.TakeCode(1 * baseCount), codelist.TakeCode(1 * baseCount) };

            AnalyzeDataContent(model);
            return model;
        }

        public void AnalyzeDataContent(HaiKangYongChuanModel model)
        {
            
            string code = model.DataContent;
            List<string> codelist = code.ToArray().Select(m => m.ToString()).ToList<string>();
            string 类型标识 = StringHelper.Convert16To10(codelist.TakeCode(1 * baseCount));
            switch (类型标识)
            {
                case "1":
                    {
                        //上传建筑消防设施系统状态 
                    }
                    break;
                case "2":
                    {
                        //上传 建筑消防设施 部件 运行状态
                        //信息对象数目
                        int bodyCount = int.Parse(StringHelper.Convert16To10(codelist.TakeCode(1 * baseCount)));
                        for (int i = 0; i < bodyCount; i++)
                        {
                            model.bodyBuJianState=AnalyzeDataContent_2(codelist.TakeCode(40 * baseCount));
                            string timeCode = codelist.TakeCode(6 * baseCount);
                        }
                    } break;
                case "21": {
                        //上传用户信息传输装置 运行状态
                    } break;
                case "24": {
                        //上传用户信息传输装置操作信息
                        
                        
                    } break;
                case "25": {
                        //上传用户信息传输装置软件版本
                    }
                    break;
                case "90": {
                        //同步 用户 信息传输 装置时钟
                    } break;
                case "91":
                    {
                        //查岗命令
                    }
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// //上传 建筑消防设施 部件 运行状态
        /// </summary>
        /// <param name="code">40位</param>
        public Body_BuJianStateModel AnalyzeDataContent_2(string code)
        {
            List<string> codelist = code.ToArray().Select(m => m.ToString()).ToList<string>();
            Body_BuJianStateModel model = new Body_BuJianStateModel();
            model.XiTongLeiXing = codelist.TakeCode(1 * baseCount);
            model.XiTongDiZhi = codelist.TakeCode(1 * baseCount);
            model.BuJianLeiXing = codelist.TakeCode(1 * baseCount);
            
            string dizhi= codelist.TakeCodeDesc(4 * baseCount);
            string zhuangt = codelist.TakeCodeDesc(2 * baseCount);
            model.BuJianDiZhi = dizhi;
            model.BuJianZhuangTai = zhuangt;
            model.BuJianShuoMing = codelist.TakeCode(31 * baseCount);

            //byte[] stateBytes = StringHelper.IntToByteArray(int.Parse(model.BuJianZhuangTai));
            //StringBuilder str = new StringBuilder();
            //List<Keyword> keyword = db.Keywords.Where(m => m.KeyType == "建筑消防设施部件状态").ToList();
            //for (int i = 0; i < stateBytes.Length; i++)
            //{
            //    if (stateBytes[i]==1)
            //    {
            //        str.Append($"{keyword.FirstOrDefault(m => m.Keyword1 == i + "").KeyContent}|");
            //    }
            //    else if (stateBytes[i] == 0)
            //    {
            //        str.Append($"{keyword.FirstOrDefault(m => m.Keyword1 == i + "").Memo1}|");
            //    }
            //}
            return model;
        }
        /// <summary>
        /// 直接返回16进制国标代码
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static string TimeToCode(DateTime time)
        {
            string result = "";
            string timeStr = time.ToString("ssmmHHddMMyy");
            for (int i = 0; i < 6; i++)
            {
                string temp = timeStr.Substring(2 * i, 2);
                result += int.Parse(temp).ToString("X").PadLeft(2, '0');
            }
            return result;

        }
    }

}
