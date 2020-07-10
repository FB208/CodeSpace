using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBCodeProduce.Helpers
{
    public static class StringHelper
    {
        /// <summary>
        /// 字符串str重复输出count次
        /// </summary>
        /// <param name="str"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public static string repeat(this string str,int count)
        {
            string space = "";
            for (int i = 0; i < count; i++)
            {
                space += " ";
            }
            return space;
        }
    }
}
