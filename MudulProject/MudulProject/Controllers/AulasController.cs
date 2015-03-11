using MudulProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MudulProject.Controllers
{
    public class AulasController : Controller
    {
        private MoodleConnection db = new MoodleConnection();
        //
        // GET: /Aulas/
        public ActionResult Index()
        {
            ViewBag.AulasMap = db.getAulasMap();
            return View(db.Aulas.ToList());
        }
	}
}