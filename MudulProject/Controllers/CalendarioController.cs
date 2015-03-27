using BibliotecaApp;
using MudulProject.Models;
using Newtonsoft.Json;
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
            var jsonSerialiser = new JavaScriptSerializer();
            String tipoUsuario = new SQLQuery().getUserRole(4);
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
                                Dictionary<string, string> values = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonSerialiser.Serialize(actividad));
                                values.Add("IdActividad", actXAlumno.Id+"");
                                listaAEnviar.Add(values);
                            }
                        }
                        break;
                    case "MAESTRO":
                        listaAEnviar = getActividadesXMaestro(4);
                        break;
                    default:listaAEnviar = new ArrayList(db.Actividades.ToList());
                        break;
                }
            }
            
            var json = jsonSerialiser.Serialize(listaAEnviar);
            return Json(json, JsonRequestBehavior.AllowGet);
        }

        private ArrayList getActividadesXMaestro(int mId)
        {
            var connection = new SQLQuery();
            DataTable dataTable = connection.getTable(string.Format(@"SELECT act.Id, act.Description, act.HoraInicio, act.HoraLimite, act.Id_seccion, act.Titulo, act.Ponderacion
                            FROM Actividades act
                            INNER JOIN AsignaturasXMaestro axm
                            ON axm.NumberAccountId = {0}
                            INNER JOIN Secciones sec
                            ON sec.Id_Asignaturas = axm.Id_Asignaturas
                            AND act.Id_seccion = sec.Id;",mId));
            ArrayList returnList = new ArrayList();
            foreach (DataRow row in dataTable.Rows)
            {
                Actividades act = new Actividades();
                act.Id = (int)row["Id"];
                act.Description = (string)row["Description"];
                act.HoraInicio = (DateTime)row["HoraInicio"];
                act.HoraLimite = (DateTime)row["HoraLimite"];
                act.Id_seccion = (int)row["Id_seccion"];
                act.Titulo = (string)row["Titulo"];
                act.Ponderacion = (decimal)row["Ponderacion"];
                returnList.Add(act);
            }
            return returnList;
        }

    }
}