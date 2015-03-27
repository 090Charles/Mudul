using MudulProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.UI;

namespace MudulProject.Controllers
{
     [Authorize]
    public class CalendarioController : BaseController
    {
        private MoodleConnection db = new MoodleConnection();

        // GET: Calendario
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        [OutputCache(Duration=3600, VaryByParam="none", Location=OutputCacheLocation.Client, NoStore=true)]
        public ActionResult AjaxTest()
        {
            var jsonSerialiser = new JavaScriptSerializer();
            var json = jsonSerialiser.Serialize(db.Actividades.ToList());
            return Json(json, JsonRequestBehavior.AllowGet);
        }

    }
}