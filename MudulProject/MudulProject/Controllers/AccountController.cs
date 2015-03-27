using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity.SqlServer;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using MudulProject.Models;

namespace MudulProject.Controllers
{
 
    public class AccountController : BaseController
    {
        [AllowAnonymous]
        public ActionResult Login(string returnUrl = "")
        {
            //check if the user is authenticated
            if (User.Identity.IsAuthenticated)
            {
                //if the user is logged in and access to /Account/Login
                //the web page will auto logout the user
                return Logout();
            }

            ViewBag.ReturnUrl = returnUrl;

            return PartialView();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(AccountModel model, string returnUrl = "")
        {
            if (ModelState.IsValid)
            {


                if (Membership.ValidateUser(model.Username, model.Password)) //if (Membership.ValidateUser(model.Username, model.Password)) //
                {
                    FormsAuthentication.SetAuthCookie(model.Username, false);
                    return RedirectToAction("Index", "Home");
              
                }

                ModelState.AddModelError(string.Empty, "Error al ingresar");
            }

            return PartialView();
        }

        public ActionResult Logout()
        {
            var cacheKey = string.Format(ConfigurationManager.AppSettings["cacheKey"], User.Identity.Name);
          

            HttpContext.Cache.Remove(cacheKey);

            //HttpContext.Cache[cacheKey] = new List<string>();
            FormsAuthentication.SignOut();

            return RedirectToAction("Login");
        }
    }
}