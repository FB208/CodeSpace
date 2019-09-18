using Autofac;
using AutoMapper;
using AutoMapper.Configuration;
using Common.Standard.AutoMapper9;
using System;
using System.Collections.Generic;
using System.Text;
using WebMvc.DemoClass.AutoMapperDemo;

namespace WebMvc.XUnitTest.AutoMapperTest
{
    public class Injection:Module
    {
        protected static IContainer Container { get; set; }
        protected override void Load(ContainerBuilder builder)
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
            Container = builder.Build();
            using (var scope= Container.BeginLifetimeScope())
            {
                var expression = scope.Resolve<MapperConfigurationExpression>();
                expression.CreateMap<PhysicalAttribute, PeopleDto>()
                .ForMember(m => m.Eye, n => n.MapFrom(s => s.Eye))
                .ForMember(m => m.Mouth, n => n.MapFrom(s => s.Mouth));
                //.ForMember(m => m.Ear, n => n.Ignore());
                expression.CreateMap<SocialAttribute, PeopleDto>()
                    .ForMember(m => m.Age, n => n.MapFrom(s => s.Age))
                    .ForMember(m => m.IsMarried, n => n.MapFrom(s => s.IsMarried));
            }
        }
    }
}
