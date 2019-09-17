using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using WebMvc.DemoClass.AutoMapperDemo;

namespace WebMvc.MSTest
{
    [TestClass]
    public class DtoHelperTest
    {
        [TestMethod]
        public void GetDto()
        {
            PeopleDto result = new PeopleDto() { Eye = "双眼皮", Mouth = "红润", Age = 18, IsMarried = false };
            PhysicalAttribute physical = new PhysicalAttribute() { Eye = "双眼皮", Mouth = "红润" };
            SocialAttribute social = new SocialAttribute() { Name = "张三", IsMarried = false, Age = 18 };
            PeopleDto output = new DtoHelper().GetDto(physical, social);
            Assert.AreEqual(JsonConvert.SerializeObject(result), JsonConvert.SerializeObject(output));
        }
    }
}
