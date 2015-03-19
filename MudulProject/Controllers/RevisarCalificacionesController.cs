using BibliotecaApp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MudulProject.Controllers
{
    public class RevisarCalificacionesController : Controller
    {
        int idtipo;
        int idusuario;
        //
        // GET: /RevisarCalificaciones/
        public ActionResult Index()
        {
            var query = new SQLQuery();
            string qstring = @"Select ac.Description as Asignatura, u.Nombre, axa.HoraSubida as [Hora Subida], axa.HoraCalificacion as [Hora Calificacion], axa.Nota
                            from ActividadXAlumno axa 
                            join Actividades ac on axa.Id_actividad=ac.Id
                            join Usuarios u on axa.Id_alumno=u.NumberAccountId";
            DataTable lista = query.getTable(qstring);
            ViewBag.Tabla = lista;
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }
	}
}