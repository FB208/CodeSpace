using System;
using System.Collections.Generic;
using System.Text;
using WebMvc.IBLL.BBSAdmin;
using WebMvc.IDAL.BBSAdmin;
using WebMvc.Model.BBSAdmin;

namespace WebMvc.BLL.BBSAdmin
{
    public class UserTableService : BaseService<UserTable>, IUserTableService
    {
        //private IUserTableDAL userTableDAL = DALContainer.Container.Resolve<IUserTableDAL>();
        private IUserTableDAL userTableDAL;
        public UserTableService(IUserTableDAL iUserTableDAL) {
            userTableDAL = iUserTableDAL;
            SetDal();
        }
        public override void SetDal()
        {
            Dal = userTableDAL;
        }

        //public UserAdminVM GetVM(UserTable user)
        //{

        //    ReflectionHelper.CopyValue<UserTable, UserAdminVM>(user, this);
        //    return this;
        //}
        //public List<UserAdminVM> GetVMList(List<UserTable> userList)
        //{
        //    List<UserAdminVM> vmlist = new List<UserAdminVM>();
        //    UserAdminVM vm;
        //    foreach (var user in userList)
        //    {

        //        vm = user.MapTo<UserAdminVM>();
        //        //ReflectionHelper.CopyValue(user, vm);
        //        vmlist.Add(vm);
        //    }
        //    return vmlist;
        //}

        //public UserTable GetUserTable(UserTable user)
        //{
        //    UserAdminVM vm = this;
        //    ReflectionHelper.CopyValue(vm, user);
        //    return user;
        //}
    }
}
