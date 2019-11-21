using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;

namespace WebMvc.Areas.WebApi.Base
{
    [AllowCrossSiteJson("*")]
    public abstract class BaseController : Controller
    {
        public BaseController()
        {
            var req = Request;
        }
        
    }
}