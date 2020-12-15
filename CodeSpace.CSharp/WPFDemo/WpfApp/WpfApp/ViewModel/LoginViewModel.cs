using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfApp.Common;
using WpfApp.DataAccess;
using WpfApp.Helper;
using WpfApp.Model;

namespace WpfApp.ViewModel
{
    public class LoginViewModel:NotifyBase
    {
        public LoginModel loginModel { get; set; } = new LoginModel();
        public CommandBase CloseWindowCommand { get; set; }
        public CommandBase LoginCommand { get; set; }

        private string _errorMessage;

        public string ErrorMessage
        {
            get { return _errorMessage; }
            set { _errorMessage = value; this.DoNotify(); }//
        }


        public LoginViewModel() {
            //this.loginModel = new LoginModel();
            //this.loginModel.UserName = "Jovan";
            //this.loginModel.Password = "123456";
            //this.loginModel.ValidationCode = "2907";

            this.CloseWindowCommand = new CommandBase();
            this.CloseWindowCommand.DoExecute = new Action<object>((o) => {
                (o as Window).Close();
            });
            this.CloseWindowCommand.DoCanExecute = new Func<object, bool>((o) => { return true; });


            //登录事件
            this.LoginCommand = new CommandBase();
            this.LoginCommand.DoExecute = new Action<object>(DoLogin);
            this.LoginCommand.DoCanExecute = new Func<object, bool>((o) => { return true; });
        }

        void DoLogin(object o)
        {
            this.ErrorMessage = "";
            if (string.IsNullOrWhiteSpace(loginModel.UserName))
            {
                this.ErrorMessage = "用户名不能为空";
                return;
            }
            //if (string.IsNullOrWhiteSpace(loginModel.Password))
            //{
            //    this.ErrorMessage = "密码不能为空";
            //    return;
            //}
            if (string.IsNullOrWhiteSpace(loginModel.ValidationCode))
            {
                this.ErrorMessage = "验证码不能为空";
                return;
            }
            GlobalValues.UserInfo = DapperHelper<Users>.QueryFirstOrDefault("select * from users",null);
            
            Application.Current.Dispatcher.Invoke(new Action(() =>
            {
                (o as Window).DialogResult = true;
            }));

            //Task.Run()
        }

        
    }
}
