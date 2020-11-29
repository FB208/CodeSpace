using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp.Common;

namespace WpfApp.Model
{
    public class LoginModel: NotifyBase
    {
        string _userName;
        public string UserName
        {
            get { return _userName; }
            set
            {
                _userName = value;
                this.DoNotify();
            }
        }


        string _password;
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                this.DoNotify();
            }
        }

        string _validationCode;
        public string ValidationCode
        {
            get { return _validationCode; }
            set
            {
                _validationCode = value;
                this.DoNotify();
            }
        }
    }
}
