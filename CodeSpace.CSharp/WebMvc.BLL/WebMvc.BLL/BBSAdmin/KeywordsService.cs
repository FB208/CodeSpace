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
        //private IKeywordsDAL keywordsDAL = DALContainer.Container.Resolve<IKeywordsDAL>();
        private IKeywordsDAL keywordsDAL;
        public KeywordsService(IKeywordsDAL iKeywordsDAL)
        {
            keywordsDAL = iKeywordsDAL;
            SetDal();
        }
        public override void SetDal()
        {
            Dal = keywordsDAL;
        }

    }
}
