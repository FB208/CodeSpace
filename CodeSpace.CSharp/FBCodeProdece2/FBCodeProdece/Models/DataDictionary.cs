using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FBCodeProduce.Models
{
    public class DataDictionary
    {
        public string ColumnName { get; set; }
        public string IsIdentity { get; set; }
        public string IsPK { get; set; }
        public string Type { get; set; }
        public int lenth { get; set; }
        public string Remark { get; set; }
    }
}
