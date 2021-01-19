using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp.Common;
using WpfApp.Model;

namespace WpfApp.ViewModel
{
    public class FirstPageViewModel : NotifyBase
    {
        private int _instrumentValue;

        public int InstrumentValue
        {
            get { return _instrumentValue; }
            set { _instrumentValue = value; this.DoNotify(); }
        }

        public List<ClassesModel> list { get; set; }

        public FirstPageViewModel()
        {
            list = new List<ClassesModel>();
            list.Add(new ClassesModel()
            {
                Name = "课程名称课程名称课程名称",
                Teacher = new UserModel()
                {
                    UserName = "张三",
                    Gender = 1,
                    Avatar = "asdfsafsaiofjaso"
                },
                Students = new List<UserModel>() { 
                    new UserModel(){ UserName="学生1",Gender=0},
                    new UserModel(){ UserName="学生2",Gender=1},
                    new UserModel(){ UserName="学生3",Gender=2}
                }
            });
            list.Add(new ClassesModel()
            {
                Name = "课程名称课程名称课程名称",
                Teacher = new UserModel()
                {
                    UserName = "张三",
                    Gender = 1,
                    Avatar = "asdfsafsaiofjaso"
                },
                Students = new List<UserModel>() {
                    new UserModel(){ UserName="学生1",Gender=0},
                    new UserModel(){ UserName="学生2",Gender=1},
                    new UserModel(){ UserName="学生3",Gender=2}
                }
            });
            list.Add(new ClassesModel()
            {
                Name = "课程名称课程名称课程名称",
                Teacher = new UserModel()
                {
                    UserName = "张三",
                    Gender = 1,
                    Avatar = "asdfsafsaiofjaso"
                },
                Students = new List<UserModel>() {
                    new UserModel(){ UserName="学生1",Gender=0},
                    new UserModel(){ UserName="学生2",Gender=1},
                    new UserModel(){ UserName="学生3",Gender=2}
                }
            });
            list.Add(new ClassesModel()
            {
                Name = "课程名称课程名称课程名称",
                Teacher = new UserModel()
                {
                    UserName = "张三",
                    Gender = 1,
                    Avatar = "asdfsafsaiofjaso"
                },
                Students = new List<UserModel>() {
                    new UserModel(){ UserName="学生1",Gender=0},
                    new UserModel(){ UserName="学生2",Gender=1},
                    new UserModel(){ UserName="学生3",Gender=2}
                }
            });
            list.Add(new ClassesModel()
            {
                Name = "课程名称课程名称课程名称",
                Teacher = new UserModel()
                {
                    UserName = "张三",
                    Gender = 1,
                    Avatar = "asdfsafsaiofjaso"
                },
                Students = new List<UserModel>() {
                    new UserModel(){ UserName="学生1",Gender=0},
                    new UserModel(){ UserName="学生2",Gender=1},
                    new UserModel(){ UserName="学生3",Gender=2}
                }
            });
        }

        private void init()
        {

        }
    }
}
