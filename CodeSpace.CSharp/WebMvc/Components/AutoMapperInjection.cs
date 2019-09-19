using Autofac;
using AutoMapper;
using AutoMapper.Configuration;
using WebMvc.DemoClass.AutoMapperDemo;

namespace WebMvc.Components
{
    public static class AutoMapperInjection
    {
        public static ContainerBuilder LoadAutoMapper(this ContainerBuilder builder)
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
