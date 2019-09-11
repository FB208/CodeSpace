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

    }
}
