using Autofac;
using System;

namespace AutofacConsole
{
    class Program
    {
        private static IContainer Container { get; set; }
        static void Main(string[] args)
        {
            //非依赖注入的写法
            //new TodayWriter(new ConsoleOutput()).WriteDate();
            //Console.ReadKey();

            //依赖注入容器
            var builder = new ContainerBuilder();

            //通过类型注册
            //builder.RegisterType<ConsoleOutput>().As<IOutput>();
            //builder.RegisterType<TodayWriter>().As<IDateWriter>();
            //通过构造函数注册
            //builder.RegisterType<ConfigReader>().UsingConstructor(typeof(string)).WithParameter("configSectionName", "sectionName");
            //builder.RegisterType<TodayWriter>().UsingConstructor(typeof(IOutput)).WithParameter("output", new ConsoleOutput());
            //实例组件
            //builder.RegisterInstance(new ConfigReader("testConfig")).As<IConfigReader>().ExternallyOwned();
            //Lambda表达式组件
            //builder.Register(m => new ConsoleOutput());
            //builder.Register(m => new TodayWriter(m.Resolve<ConsoleOutput>()));
            //属性注入-反射方法
            //builder.RegisterType<HelloUser>().PropertiesAutowired();
            //属性注入-Lambda
            //builder.Register(m => new ConfigReader("sectionName") { _attributeInjection = "AttributeName" });
            //方法注入-Lambda
            //builder.RegisterType<Method>();
            //builder.Register(c =>
            //    {
            //        var result = new HelloUser();
            //        result.SayHello(c.Resolve<Method>());
            //        return result;
            //    });
            //方法注入-激活时间处理程序
            builder.RegisterType<Method>();
            builder.RegisterType<HelloUser>().OnActivating(e =>
            {
                var m = e.Context.Resolve<Method>();
                e.Instance.SayHello(m);
            });



            Container = builder.Build();
            using (var scope = Container.BeginLifetimeScope())
            {
                //通过类型注册
                //var writer = scope.Resolve<IDateWriter>();
                //writer.WriteDate();
                //通过构造函数注册
                //scope.Resolve<ConfigReader>().Write();
                //scope.Resolve<TodayWriter>().WriteDate();
                //实例组件
                //scope.Resolve<IConfigReader>().Write();
                //Lambda表达式组件
                //scope.Resolve<TodayWriter>().WriteDate();
                //属性注入-反射方法
                //scope.Resolve<HelloUser>().SayHello();
                //属性注入-Lambda
                //scope.Resolve<ConfigReader>().Write();
                //方法注入-Lambda
                //scope.Resolve<HelloUser>();
                //方法注入-激活时间处理程序
                scope.Resolve<HelloUser>();
            }
        }

    }

    public interface IOutput
    {
        void Write(string content);
    }
    public class ConsoleOutput : IOutput
    {
        public void Write(string content)
        {
            Console.WriteLine(content);
        }
    }
    public interface IDateWriter
    {
        void WriteDate();
    }
    public class TodayWriter : IDateWriter
    {
        private IOutput _output;
        public TodayWriter(IOutput output)
        {
            this._output = output;
        }

        public void WriteDate()
        {
            this._output.Write(DateTime.Today.ToShortDateString());
        }
    }

    public interface IConfigReader
    {
        void Write();
    }
    public class ConfigReader : IConfigReader
    {

        public string _configSectionName;
        public string _attributeInjection { get; set; }

        public ConfigReader(string configSectionName)
        {
            _configSectionName = configSectionName;
        }
        public void Write()
        {
            if (!string.IsNullOrWhiteSpace(_attributeInjection))
            {
                Console.WriteLine(_attributeInjection + "  " + _configSectionName);
            }
            else
            {
                Console.WriteLine(_configSectionName);
            }

        }

        
    }
    public class HelloUser
    {
        public string UserName { get; set; }
        public HelloUser()
        { }
        public void SayHello(Method m)
        {
            Console.WriteLine($"Hello {UserName}");
            m.Write();
        }
    }
    public class Method
    {
        public void Write()
        {
            Console.WriteLine("this is a method");
        }
    }
}
