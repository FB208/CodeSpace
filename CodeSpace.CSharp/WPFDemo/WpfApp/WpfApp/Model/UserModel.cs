using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp.Common;

namespace WpfApp.Model
{
    public class UserModel:NotifyBase
    {
        public string Avatar { get; set; }
        public string UserName { get; set; }
        public int Gender { get; set; }
    }
}
