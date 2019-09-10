using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBCodeProduce.Models
{
    public class DbSearchModel
    {
        /// <summary>
        /// 是否模糊查询 true=模糊查询 like=全字匹配
        /// </summary>
        public bool IsLike { get; set; }
    }
}
