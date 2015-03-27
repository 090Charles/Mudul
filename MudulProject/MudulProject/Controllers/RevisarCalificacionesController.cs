using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MudulProject.Models;

namespace MudulProject.Controllers
{
     [Authorize]
    public class RevisarCalificacionesController : BaseController
    {
        //
        // GET: /RevisarCalificaciones/
        public ActionResult Index()
        {
            return View();
        }
	}
}