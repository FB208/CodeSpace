using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp.Model
{
    public class ClassesModel
    {
        public string Name { get; set; }
        public UserModel Teacher { get; set; }
        public List<UserModel> Students { get; set; }
    }
}
