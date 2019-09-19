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
using Xunit.Abstractions;

namespace WebMvc.XUnitTest.AutoMapperTest
{
    
    public class DtoHelperTest
    {
        ITestOutputHelper outputHelper;
        public DtoHelperTest(ITestOutputHelper output)
        {
            this.outputHelper = output;
        }

        [Fact]
        public void GetDto() {
            //moke
            ContainerBuilder builder = new ContainerBuilder();
            builder.LoadAutoMapper();
            builder.RegisterType<AutoMapperProfile>();
            IContainer Container = builder.Build();
            using (var scope = Container.BeginLifetimeScope())
            {
                scope.Resolve<AutoMapperProfile>().Mapping(scope);
                PeopleDto result = new PeopleDto() { Eye = "双眼皮", Mouth = "红润", Age = 18, IsMarried = false };
                PhysicalAttribute physical = new PhysicalAttribute() { Eye = "双眼皮", Mouth = "红润" };
                SocialAttribute social = new SocialAttribute() { Name = "张三", IsMarried = false, Age = 18 };
                PeopleDto output = new DtoHelper(scope.Resolve<IMapper>()).GetDto(physical, social);
                //Assert.Same(result, output);
                Assert.Equal(JsonConvert.SerializeObject(result), JsonConvert.SerializeObject(output));
                outputHelper.WriteLine(JsonConvert.SerializeObject(output));
            }

        }
    }
}
