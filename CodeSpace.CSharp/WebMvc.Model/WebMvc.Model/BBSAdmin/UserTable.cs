using System;
using System.Collections.Generic;

namespace WebMvc.Model.BBSAdmin
{
    public partial class UserTable
    {
        public string Uuid { get; set; }
        public string UserName { get; set; }
        public string NickName { get; set; }
        public string Pwd { get; set; }
        public string Introduction { get; set; }
        public string Email { get; set; }
        public string RoleFlag { get; set; }
        public string HomePage { get; set; }
        public string Tel { get; set; }
    }
}
