using Autofac;
using AutoMapper;
using AutoMapper.Configuration;
using WebMvc.DemoClass.AutoMapperDemo;

namespace WebMvc.Components
{
    public class AutoMapperInjection
    {
        public ContainerBuilder builder { get; set; }

        public AutoMapperInjection(ContainerBuilder _builder) {
            builder = _builder;
        }
        public ContainerBuilder Load()
        {

            builder.RegisterType<MapperConfigurationExpression>().SingleInstance();
            builder.Register(m => {
                var mapperConfigurationExpression = m.Resolve<MapperConfigurationExpression>();
                var instance = new MapperConfiguration(mapperConfigurationExpression);
                return instance;
            });
            builder.Register(m => {
                var mapperConfiguration = m.Resolve<MapperConfiguration>();
                return mapperConfiguration.CreateMapper();
            });
            return builder;
            
        }
    }
}
