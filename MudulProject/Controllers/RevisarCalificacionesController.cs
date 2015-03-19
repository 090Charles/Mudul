using BibliotecaApp;
using MudulProject.Models;
using ActividadXAlumno;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MudulProject.Controllers
{
    public class RevisarCalificacionesController : Controller
    {
        private MoodleConnection db = new MoodleConnection();
        int idtipo=1;
        int idusuario=3;
        //
        // GET: /RevisarCalificaciones/
        public ActionResult Index()
        {
            var query = new SQLQuery();
            string qstring = @"Select axa.Id, ac.Description as Actividad, u.Nombre, axa.HoraSubida as [Hora Subida], axa.HoraCalificacion as [Hora Calificacion], axa.Nota
                            from ActividadXAlumno axa 
                            join Actividades ac on axa.Id_actividad=ac.Id
                            join Usuarios u on axa.Id_alumno=u.NumberAccountId";
            DataTable lista = query.getTable(qstring);
            ViewBag.Tabla = lista;
            return View();
        }

        public ActionResult IndexAlumno()
        {
            if (idtipo == 1)
            {
                var query = new SQLQuery();
                string qstring = @"Select axa.Id, ac.Description as Actividad, u.Nombre, axa.HoraSubida as [Hora Subida], axa.Nota
                            from ActividadXAlumno axa 
                            join Actividades ac on axa.Id_actividad=ac.Id
                            join Usuarios u on axa.Id_alumno=u.NumberAccountId
                            where axa.Id_alumno=" + idusuario.ToString();
                DataTable lista = query.getTable(qstring);
                ViewBag.Tabla = lista;
                return View();
            }
            else
                return Redirect("Index");
        }

        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Edit(int id)
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Id_Aulas,Id_Asignaturas,Id_Periodo,Id_Horarios")] ActividadXAlumno axa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(axa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(axa);
        }
	}
}