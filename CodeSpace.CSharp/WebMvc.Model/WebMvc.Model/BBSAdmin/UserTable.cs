using System;
using System.Collections.Generic;

namespace WebMvc.Model.BBSAdmin
{
    public partial class UserTable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Age { get; set; }
        public string Sex { get; set; }
    }
}
