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
            builder.Register(m => new ConsoleOutput());
            builder.Register(m => new TodayWriter(m.Resolve<ConsoleOutput>()));

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
                scope.Resolve<TodayWriter>().WriteDate();

            }

            // The WriteDate method is where we'll make use
            // of our dependency injection. We'll define that
            // in a bit.
            //WriteDate();
        }
        public static void WriteDate()
        {
            // Create the scope, resolve your IDateWriter,
            // use it, then dispose of the scope.
            using (var scope = Container.BeginLifetimeScope())
            {
                var writer = scope.Resolve<IDateWriter>();
                writer.WriteDate();
            }
        }
    }
    // This interface helps decouple the concept of
    // "writing output" from the Console class. We
    // don't really "care" how the Write operation
    // happens, just that we can write.
    public interface IOutput
    {
        void Write(string content);
    }

    // This implementation of the IOutput interface
    // is actually how we write to the Console. Technically
    // we could also implement IOutput to write to Debug
    // or Trace... or anywhere else.
    public class ConsoleOutput : IOutput
    {
        public void Write(string content)
        {
            Console.WriteLine(content);
        }
    }

    // This interface decouples the notion of writing
    // a date from the actual mechanism that performs
    // the writing. Like with IOutput, the process
    // is abstracted behind an interface.
    public interface IDateWriter
    {
        void WriteDate();
    }

    // This TodayWriter is where it all comes together.
    // Notice it takes a constructor parameter of type
    // IOutput - that lets the writer write to anywhere
    // based on the implementation. Further, it implements
    // WriteDate such that today's date is written out;
    // you could have one that writes in a different format
    // or a different date.
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
   
    public interface IConfigReader {
        void Write();
    }
    public class ConfigReader : IConfigReader
    {
        public string _configSectionName;
        public ConfigReader(string configSectionName)
        {
            _configSectionName = configSectionName;
            // Store config section name
        }
        public void Write() {
            Console.WriteLine(_configSectionName);
        }
        // ...read configuration based on the section name.
    }
}
