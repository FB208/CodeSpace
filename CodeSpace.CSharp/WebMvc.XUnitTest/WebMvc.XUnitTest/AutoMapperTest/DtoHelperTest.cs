using Autofac;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Moq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using WebMvc.Components;
using WebMvc.DemoClass.AutoMapperDemo;
using WebMvc.XUnitTest.AutoMapperTest;
using Xunit;

namespace WebMvc.XUnitTest.AutoMapperTest
{
    
    public class DtoHelperTest
    {
        [Fact]
        public void GetDto() {
            AutoMapperInjection inject = new AutoMapperInjection(new ContainerBuilder());
            inject.Load();
            IContainer Container = inject.builder.Build();
            using (var scope = Container.BeginLifetimeScope())
            {
                PeopleDto result = new PeopleDto() { Eye = "双眼皮", Mouth = "红润", Age = 18, IsMarried = false };
                PhysicalAttribute physical = new PhysicalAttribute() { Eye = "双眼皮", Mouth = "红润" };
                SocialAttribute social = new SocialAttribute() { Name = "张三", IsMarried = false, Age = 18 };
                PeopleDto output = new DtoHelper(scope.Resolve<IMapper>()).GetDto(physical, social);
                //Assert.Same(result, output);
                Assert.Equal(JsonConvert.SerializeObject(result), JsonConvert.SerializeObject(output));
            }

        }
    }
}
