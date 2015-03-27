using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;

namespace MudulProject.Models
{
    public class BaseController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var cacheKey = string.Format(ConfigurationManager.AppSettings["cacheKey"], System.Web.HttpContext.Current.User.Identity.Name);
            if (User.Identity.IsAuthenticated && HttpRuntime.Cache[cacheKey] == null)
            {
                var timeout = Convert.ToInt32(ConfigurationManager.AppSettings["cacheTimeout"]);

                HttpRuntime.Cache.Insert(cacheKey, "es-HN", null,
                                         DateTime.Now.AddMinutes(timeout), Cache.NoSlidingExpiration);
            }

            base.OnActionExecuting(filterContext);
        }
    }
}