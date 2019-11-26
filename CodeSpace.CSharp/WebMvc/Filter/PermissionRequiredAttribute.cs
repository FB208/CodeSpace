using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMvc.Filter
{
    public class PermissionRequiredAttribute: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)

        {
            var isDefined = false;
            var controllerActionDescriptor = filterContext.ActionDescriptor as ControllerActionDescriptor;
            if (controllerActionDescriptor != null)
            {
                isDefined = controllerActionDescriptor.MethodInfo.GetCustomAttributes(inherit: true)
                  .Any(a => a.GetType().Equals(typeof(NoPermissionRequiredAttribute)));
            }
            if (isDefined) return;
            var ss = filterContext.HttpContext.Request;
            //if (HttpContext.Current.Session.GetString("LoginInfo") == null)
            //{
            //    filterContext.Result = new RedirectResult("/Account/Login");
            //}
            base.OnActionExecuting(filterContext);
        }
    }
    
}
