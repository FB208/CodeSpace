using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMvc.Areas.WebApi.Base
{
    public class AllowCrossSiteJsonAttribute : ActionFilterAttribute
    {
        private string[] _domains;
        public AllowCrossSiteJsonAttribute(string domain)
        {
            _domains = new string[] { domain };
        }
        public AllowCrossSiteJsonAttribute(string[] domains)
        {
            _domains = domains;
        }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //var context = filterContext.RequestContext.HttpContext;
            //var host = context.Request.UrlReferrer.Authority;

            //暂时不限制域名
            filterContext.HttpContext.Response.Headers.Add("Access-Control-Allow-Origin", "*");
            filterContext.HttpContext.Response.Headers.Add("Access-Control-Allow-Headers", "*,token");
            filterContext.HttpContext.Response.Headers.Add("Access-Control-Allow-Methods", "*");
            //filterContext.RequestContext.HttpContext.Response.AddHeader("Access-Control-Allow-Origin", "*");
            //filterContext.RequestContext.HttpContext.Response.AddHeader("Access-Control-Allow-Credentials", "true");
            //filterContext.RequestContext.HttpContext.Response.AddHeader("Access-Control-Allow-Methods", "*");
            //filterContext.RequestContext.HttpContext.Response.AddHeader("Access-Control-Allow-Headers", "Content-Type,Access-Token");
            //filterContext.RequestContext.HttpContext.Response.AddHeader("Access-Control-Expose-Headers", "*");

            if (filterContext.HttpContext.Request.Method.Equals("OPTIONS"))
            {
                filterContext.HttpContext.Response.StatusCode = 200;
                //filterContext.RequestContext.HttpContext.res
                //HttpUtil.setResponse(response, HttpStatus.OK.value(), null);

            }
            //if (host != null && _domains.Contains(host))
            //{

            //}
            base.OnActionExecuting(filterContext);
        }
    }
}
