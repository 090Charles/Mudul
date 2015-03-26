using BibliotecaApp;
using MudulProject.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.UI;

namespace MudulProject.Controllers
{
    public class CalendarioController : Controller
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
            String tipoUsuario = new SQLQuery().getUserRole(3);
            ArrayList listaAEnviar = new ArrayList();
            if (tipoUsuario != null || tipoUsuario.Length != 0)
            {
                tipoUsuario = Regex.Replace(tipoUsuario, @"\s+", "");
                switch (tipoUsuario.ToUpper())
                {
                    case "ALUMNO":
                        foreach (ActividadXAlumno actXAlumno in new SQLQuery().cargarActividadesXAlumno(3))
                        {
                            Actividades actividad = db.Actividades.Find(actXAlumno.Id);
                            if (actividad != null)
                            {
                                listaAEnviar.Add(actividad);
                            }
                        }
                        break;
                    case "MAESTRO":
                        break;
                    default:listaAEnviar = new ArrayList(db.Actividades.ToList());
                        break;
                }
            }
            var jsonSerialiser = new JavaScriptSerializer();
            var json = jsonSerialiser.Serialize(listaAEnviar);
            return Json(json, JsonRequestBehavior.AllowGet);
        }

    }
}