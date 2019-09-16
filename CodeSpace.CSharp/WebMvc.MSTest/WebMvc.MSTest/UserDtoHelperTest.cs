using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using WebMvc.ViewModel;

namespace WebMvc.MSTest
{
    [TestClass]
    public class UserDtoHelperTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            UserDto result = new UserDto() { ID = 1, Name = "张三",
                //Eye = "眼"
            };
            UserDto output=new UserDtoHelper().GetDto();

            PropertyInfo[] pis_result = result.GetType().GetProperties();
            PropertyInfo[] pis_output = output.GetType().GetProperties();
            //for (int i = 0; i < pis_result.Length; i++)
            //{
            //    for (int j = 0; j < pis_output.Length; j++)
            //    {
            //        if (pis_result[i].Name==pis_output[j].Name)
            //        {
            //            Assert.AreEqual(pis_result[i].GetValue(result), pis_output[j].GetValue(output),pis_result[i].Name);
            //            break;
            //        }
            //    }
            //}

            Assert.AreEqual(JsonConvert.SerializeObject(result), JsonConvert.SerializeObject(output));
        }
    }
}
