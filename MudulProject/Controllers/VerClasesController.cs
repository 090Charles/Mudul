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
    public class VerClasesController : Controller
    {
        private MoodleConnection db = new MoodleConnection();
        private int idalumno = 3;
        // GET: /VerClases/
        public ActionResult Index()
        {
            var query = new SQLQuery();
            string qstring = string.Format(@"select sxa.Id, asig.Description as Asignatura, sxa.Idseccion as Seccion
from SeccionesXAlumno sxa
join Usuarios u on sxa.Idalumno=u.NumberAccountId
join Asignaturas asig on sxa.Idasignatura=asig.Id
where sxa.Idalumno={0} and u.Id_TipoUsuario=1;",idalumno);
            DataTable result = query.getTable(qstring);

            if (result == null)
            {
                ViewBag.ERROR = "No se pudo cargar las clases";
                return View();
            }
            ViewBag.Tabla = result;
            qstring = "";
            qstring = string.Format(@"select distinct u.Nombre, u.Apellido from SeccionesXAlumno sxa
join Usuarios u on sxa.Idalumno=u.NumberAccountId
where sxa.Idalumno={0};", idalumno);
            DataTable nombreAlumno = query.getTable(qstring);
            if (nombreAlumno == null)
            {
                ViewBag.ERROR = "No se pudo cargar el nombre del alumno";
                return View();
            }
            foreach (DataRow row in nombreAlumno.Rows)
            {
                qstring = string.Format("{0} {1}", row["Nombre"].ToString(), row["Apellido"].ToString());
            }
            ViewBag.NombreCompleto = qstring;
            return View();
        }

        public ActionResult VerActividades(int? id)
        {
            if (id == null)
            {
                return HttpNotFound("Error, no se encontro ningun dato que cargar");
            }
            var query = new SQLQuery();
            string qstring = string.Format(@"select * from Actividades ac where ac.Id_seccion={0}",id.Value);
            DataTable result = query.getTable(qstring);
            if (result==null)
            {
                ViewBag.SinDatos = 1;
                ViewBag.ERROR = "No hay actividades para esta seccion";
            }
            ViewBag.SinDatos = 0;
            ViewBag.Tabla = result;
            return View();
        }

        // GET: /VerClases/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SeccionesXAlumno seccionesxalumno = db.seccionesxalumno.Find(id);
            if (seccionesxalumno == null)
            {
                return HttpNotFound();
            }
            return View(seccionesxalumno);
        }

        // GET: /VerClases/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /VerClases/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Idseccion,Idalumno,Idasignatura")] SeccionesXAlumno seccionesxalumno)
        {
            if (ModelState.IsValid)
            {
                db.seccionesxalumno.Add(seccionesxalumno);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(seccionesxalumno);
        }

        // GET: /VerClases/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SeccionesXAlumno seccionesxalumno = db.seccionesxalumno.Find(id);
            if (seccionesxalumno == null)
            {
                return HttpNotFound();
            }
            return View(seccionesxalumno);
        }

        // POST: /VerClases/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Idseccion,Idalumno,Idasignatura")] SeccionesXAlumno seccionesxalumno)
        {
            if (ModelState.IsValid)
            {
                db.Entry(seccionesxalumno).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(seccionesxalumno);
        }

        // GET: /VerClases/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SeccionesXAlumno seccionesxalumno = db.seccionesxalumno.Find(id);
            if (seccionesxalumno == null)
            {
                return HttpNotFound();
            }
            return View(seccionesxalumno);
        }

        // POST: /VerClases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SeccionesXAlumno seccionesxalumno = db.seccionesxalumno.Find(id);
            db.seccionesxalumno.Remove(seccionesxalumno);
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

        private void llenarMapasDB()
        {
            ViewBag.MapaAsignaturas = db.getAsignaturas();
            ViewBag.MapasAlumnos = db.getAlumnosMap();
        }
    }
}
