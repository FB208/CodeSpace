using System;
using System.Collections.Generic;
using System.Text;
using WebMvc.IBLL.BBSAdmin;
using WebMvc.IDAL.BBSAdmin;
using WebMvc.Model.BBSAdmin;

namespace WebMvc.BLL.BBSAdmin
{
    public class KeywordsService : BaseService<Keywords>, IKeywordsService
    {
        private IKeywordsDAL keywordsDAL = DALContainer.Container.Resolve<IKeywordsDAL>();
        public override void SetDal()
        {
            Dal = keywordsDAL;
        }

    }
}
