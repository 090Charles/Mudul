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
    public class VerClasesMaestroController : Controller
    {
        private MoodleConnection db = new MoodleConnection();

        private void llenarMapasDb()
        {
            ViewBag.MapaAsignaturas = db.getAsignaturas();
            ViewBag.MapaMaestros = db.getMaestrosMap();
        }

        private void llenarListaDb()
        {
            ViewBag.ListaAsignaturas = db.Asignaturas.ToList();
            var lista = db.Usuarios.ToList();
            List<Usuarios> maestros = new List<Usuarios>();
            foreach (Usuarios user in lista)
            {
                if (user.Id_TipoUsuario == 2)
                    maestros.Add(user);
            }
            ViewBag.ListaMaestros = maestros;
        }

        // GET: /VerClasesMaestro/
        public ActionResult Index()
        {
            var query = new SQLQuery();
            string qstring = string.Format(@"Select a.Id, a.Description as Asignatura, u.Nombre, u.Apellido from AsignaturasXMaestro axm 
join Asignaturas a on axm.Id_Asignaturas=a.Id
join Usuarios u on axm.NumberAccountId=u.NumberAccountId
where axm.NumberAccountId={0};",4);
            DataTable tabla = query.getTable(qstring);
            ViewBag.Tabla = tabla;
            return View();
        }

        // GET: /VerClasesMaestro/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //AsignaturasXMaestro asignaturasxmaestro = db.AsignaturasXMaestro.Find(id);
            var query = new SQLQuery();
            string qstring = string.Format(@"select s.Id Seccion, au.Description as Aula, au.Floor as Piso from Secciones s
join Aulas au on s.Id_Aulas=au.Id
where s.Id_Asignaturas={0};", id);
            DataTable datos = query.getTable(qstring);
            
            if (datos == null)
            {
                return HttpNotFound();
            }
            ViewBag.Tabla = datos;            
            return View(datos);
        }

        // GET: /VerClasesMaestro/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /VerClasesMaestro/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Id_Asignaturas,NumberAccountId")] AsignaturasXMaestro asignaturasxmaestro)
        {
            if (ModelState.IsValid)
            {
                db.AsignaturasXMaestro.Add(asignaturasxmaestro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(asignaturasxmaestro);
        }

        // GET: /VerClasesMaestro/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AsignaturasXMaestro asignaturasxmaestro = db.AsignaturasXMaestro.Find(id);
            if (asignaturasxmaestro == null)
            {
                return HttpNotFound();
            }
            return View(asignaturasxmaestro);
        }

        // POST: /VerClasesMaestro/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Id_Asignaturas,NumberAccountId")] AsignaturasXMaestro asignaturasxmaestro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(asignaturasxmaestro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(asignaturasxmaestro);
        }

        // GET: /VerClasesMaestro/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AsignaturasXMaestro asignaturasxmaestro = db.AsignaturasXMaestro.Find(id);
            if (asignaturasxmaestro == null)
            {
                return HttpNotFound();
            }
            return View(asignaturasxmaestro);
        }

        // POST: /VerClasesMaestro/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AsignaturasXMaestro asignaturasxmaestro = db.AsignaturasXMaestro.Find(id);
            db.AsignaturasXMaestro.Remove(asignaturasxmaestro);
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
    }
}
