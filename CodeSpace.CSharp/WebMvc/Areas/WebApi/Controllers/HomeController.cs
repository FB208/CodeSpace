using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebMvc.Areas.WebApi.Base;
using WebMvc.Filter;

namespace WebMvc.Areas.WebApi.Controllers
{
    [Area("WebApi")]
    public class HomeController : BaseController
    {
        public class Test {
            public string name { get; set; }
            public int age { get; set; }
        }
        [NoPermissionRequired]
        public JsonResult Index()
        {
            Test test = new Test()
            {
                name="test",
                age=26
            };
            return Json(new Result
            {
                success = true,
                Data = test
            });
        }
    }
}