using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;


namespace WebMvc.DAL.BBSAdmin
{
    public class DbContextFactory
    {
        /// <summary>
        /// 这里将来改成单例
        /// </summary>
        public static DbContext Create()
        {
            DbContext dbContext = Common.StaticTools.CallContext.GetData("DbContext") as DbContext;
            if (dbContext == null)
            {
                dbContext = new Model.BBSAdmin.BBSAdminContext();
                Common.StaticTools.CallContext.SetData("DbContext", dbContext);
            }
            return dbContext;
        }
    }
}
