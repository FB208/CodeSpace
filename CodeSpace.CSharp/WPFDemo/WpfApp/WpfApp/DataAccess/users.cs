using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp.DataAccess
{
    public class Users
    {
        public string user_id { get; set; }
        public string user_name { get; set; }
        public string real_name { get; set; }
        public string pwd { get; set; }
        public int is_validation { get; set; }
        public int is_can_login { get; set; }
        public int is_teacher { get; set; }
        public string avatar { get; set; }
        public int gender { get; set; }
    }
}
