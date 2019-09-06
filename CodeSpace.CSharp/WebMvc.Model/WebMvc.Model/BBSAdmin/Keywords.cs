using System;
using System.Collections.Generic;

namespace WebMvc.Model.BBSAdmin
{
    public partial class Keywords
    {
        public int Id { get; set; }
        public string KeyType { get; set; }
        public string KeyWord { get; set; }
        public string Content { get; set; }
        public int? Sort { get; set; }
        public string Memo { get; set; }
    }
}
