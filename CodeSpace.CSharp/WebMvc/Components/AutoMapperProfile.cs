using Autofac;
using AutoMapper;
using AutoMapper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMvc.DemoClass.AutoMapperDemo;
using WebMvc.Model.BBSAdmin;
using WebMvc.ViewModel;

namespace WebMvc.Components
{
    public class AutoMapperProfile: Profile
    {
        public void Mapping(ILifetimeScope scope) {

            var expression = scope.Resolve<MapperConfigurationExpression>();
            #region PeopleDto
            expression.CreateMap<PhysicalAttribute, PeopleDto>()
            .ForMember(m => m.Eye, n => n.MapFrom(s => s.Eye))
            .ForMember(m => m.Mouth, n => n.MapFrom(s => s.Mouth));
            //.ForMember(m => m.Ear, n => n.Ignore());
            expression.CreateMap<SocialAttribute, PeopleDto>()
                .ForMember(m => m.Age, n => n.MapFrom(s => s.Age))
                .ForMember(m => m.IsMarried, n => n.MapFrom(s => s.IsMarried));
            #endregion
            #region UserAdminVM
            //expression.CreateMap<UserTable, UserAdminVM>();
            #endregion
        }
    }
}
