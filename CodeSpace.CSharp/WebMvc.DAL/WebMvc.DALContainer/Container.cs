using Autofac;
using System;
using System.Collections.Generic;
using System.Text;
using WebMvc.DAL.BBSAdmin;
using WebMvc.IDAL.BBSAdmin;

namespace WebMvc.DALContainer
{
    public class Container
    {
        public static IContainer container = null;

        public static T Resolve<T>()
        {
            try
            {
                if (container==null)
                {
                    Initialise();
                }
            }
            catch (Exception ex)
            {
                throw new System.Exception("IOC实例化出错!" + ex.Message);
            }
            return container.Resolve<T>();
        }
        /// <summary>
        /// 初始化
        /// </summary>
        public static void Initialise()
        {
            var builder = new ContainerBuilder();
            //格式：builder.RegisterType<xxxx>().As<Ixxxx>().InstancePerLifetimeScope();
            builder.RegisterType<UserTableDAL>().As<IUserTableDAL>().InstancePerLifetimeScope();
            builder.RegisterType<KeywordsDAL>().As<IKeywordsDAL>().InstancePerLifetimeScope();
            container = builder.Build();
        }
    }
}
