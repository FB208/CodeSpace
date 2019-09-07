using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMvc.Controllers.Component
{
    public class PageViewComponent:ViewComponent
    {

        protected readonly IHostingEnvironment Env;
        //public PageViewComponent()
        //{
            
        //}
        public PageViewComponent(IHostingEnvironment env)
        {
            Env = env;
        }

        public async Task<IViewComponentResult> InvokeAsync(string href)
        {
            if (href.IndexOf("?") > -1)
            {
                ViewData["Page_BaseHref"] = href + "&pageIndex=";
            }
            else {
                ViewData["Page_BaseHref"] = href + "?pageIndex=";
            }
            
            return View();
        }
    }
}
