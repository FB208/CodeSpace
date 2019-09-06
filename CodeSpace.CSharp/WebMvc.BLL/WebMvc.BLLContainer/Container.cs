using Autofac;
using System;
using System.Collections.Generic;
using System.Text;
using WebMvc.BLL.BBSAdmin;
using WebMvc.IBLL.BBSAdmin;

namespace WebMvc.BLLContainer
{
    public class Container
    {
        /// <summary>
        /// IOC 容器
        /// </summary>
        public static IContainer container = null;

        /// <summary>
        /// 获取 IDal 的实例化对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Resolve<T>()
        {
            try
            {
                if (container == null)
                {
                    Initialise();
                }
            }
            catch (System.Exception ex)
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
            builder.RegisterType<UserTableService>().As<IUserTableService>().InstancePerLifetimeScope();
            builder.RegisterType<KeywordsService>().As<IKeywordsService>().InstancePerLifetimeScope();
            container = builder.Build();
        }
    }
}
