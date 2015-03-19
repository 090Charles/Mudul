using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MudulProject.Models;
using BibliotecaApp;

namespace MudulProject.Controllers
{
    public class RevisarCalificacionesController : Controller
    {
        private MoodleConnection db = new MoodleConnection();
        int idtipo = 1;
        int idusuario = 3;

        // GET: /RevisarCalificaciones/
        public ActionResult Index()
        {
            llenarMapasDB();
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

        // GET: /RevisarCalificaciones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ActividadXAlumno actividadxalumno = db.ActividadXAlumno.Find(id);
            if (actividadxalumno == null)
            {
                return HttpNotFound();
            }
            return View(actividadxalumno);
        }

        // GET: /RevisarCalificaciones/Create
        public ActionResult Create()
        {
            llenarListaDB();
            return View();
        }

        // POST: /RevisarCalificaciones/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Id_actividad,Id_alumno,HoraSubida,HoraCalificacion,Nota,Archivo,Comentario")] ActividadXAlumno actividadxalumno)
        {
            if (ModelState.IsValid)
            {
                db.ActividadXAlumno.Add(actividadxalumno);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(actividadxalumno);
        }

        // GET: /RevisarCalificaciones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ActividadXAlumno actividadxalumno = db.ActividadXAlumno.Find(id);
            if (actividadxalumno == null)
            {
                return HttpNotFound();
            }
            return View(actividadxalumno);
        }

        // POST: /RevisarCalificaciones/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Id_actividad,Id_alumno,HoraSubida,HoraCalificacion,Nota,Archivo,Comentario")] ActividadXAlumno actividadxalumno)
        {
            if (ModelState.IsValid)
            {
                db.Entry(actividadxalumno).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(actividadxalumno);
        }

        // GET: /RevisarCalificaciones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ActividadXAlumno actividadxalumno = db.ActividadXAlumno.Find(id);
            if (actividadxalumno == null)
            {
                return HttpNotFound();
            }
            return View(actividadxalumno);
        }

        // POST: /RevisarCalificaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ActividadXAlumno actividadxalumno = db.ActividadXAlumno.Find(id);
            db.ActividadXAlumno.Remove(actividadxalumno);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        private void llenarListaDB()
        {
            ViewBag.ListaActividades = db.Actividades.ToList();
            var lista = db.Usuarios.ToList();
            List<Usuarios> alumnos = new List<Usuarios>();
            foreach (Usuarios user in lista)
            {
                if (user.Id_TipoUsuario == 1)
                    alumnos.Add(user);
            }
            ViewBag.ListaAlumnos = alumnos;
        }
        private void llenarMapasDB()
        {
            ViewBag.MapaActividadeas = db.getActividadesMap();
            ViewBag.MapaAlumnos = db.getAlumnosMap();
        }
    }
}
