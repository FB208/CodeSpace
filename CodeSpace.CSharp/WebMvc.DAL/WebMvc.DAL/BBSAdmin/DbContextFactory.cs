using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using Microsoft.Extensions.Options;
using WebMvc.Model.BBSAdmin;
using WebMvc.Common.StaticTools;

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
                string connectionString = new AppConfigurationServices().GetConfiguration().GetConnectionString("BBSAdminConnection");
                var optionsBuilder = new DbContextOptionsBuilder<Model.BBSAdmin.BBSAdminContext>()
                .UseMySql(connectionString)//,o=>o.UseRowNumberForPaging()
                .Options;
                dbContext = new Model.BBSAdmin.BBSAdminContext(optionsBuilder);
                Common.StaticTools.CallContext.SetData("DbContext", dbContext);
            }
            return dbContext;
        }
    }
}
