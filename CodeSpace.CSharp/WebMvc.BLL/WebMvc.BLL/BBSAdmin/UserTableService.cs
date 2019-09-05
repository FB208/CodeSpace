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
        private IUserTableDAL userTableDAL = DALContainer.Container.Resolve<IUserTableDAL>();
        public override void SetDal()
        {
            Dal = userTableDAL;
        }

    }
}
