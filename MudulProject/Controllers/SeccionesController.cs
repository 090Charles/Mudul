using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MudulProject.Models;

namespace MudulProject.Controllers
{
    public class SeccionesController : Controller
    {
        private MoodleConnection db = new MoodleConnection();

        // GET: Secciones
        public ActionResult Index()
        {
            llenarMapasDB();
            return View(db.Secciones.ToList());
        }

        // GET: Secciones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Secciones secciones = db.Secciones.Find(id);
            if (secciones == null)
            {
                return HttpNotFound();
            }
            llenarMapasDB();
            return View(secciones);
        }

        // GET: Secciones/Create
        public ActionResult Create()
        {
            llenarListaDB();
            return View();
        }

        // POST: Secciones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Id_Aulas,Id_Asignaturas,Id_Periodo,Id_Horarios")] Secciones secciones)
        {
            if (ModelState.IsValid)
            {
                db.Secciones.Add(secciones);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(secciones);
        }

        // GET: Secciones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Secciones secciones = db.Secciones.Find(id);
            if (secciones == null)
            {
                return HttpNotFound();
            }
            llenarListaDB();
            return View(secciones);
        }

        // POST: Secciones/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Id_Aulas,Id_Asignaturas,Id_Periodo,Id_Horarios")] Secciones secciones)
        {
            if (ModelState.IsValid)
            {
                db.Entry(secciones).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(secciones);
        }

        // GET: Secciones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Secciones secciones = db.Secciones.Find(id);
            if (secciones == null)
            {
                return HttpNotFound();
            }
            llenarMapasDB();
            return View(secciones);
        }

        // POST: Secciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Secciones secciones = db.Secciones.Find(id);
            db.Secciones.Remove(secciones);
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
            ViewBag.MapaAulas = db.getAulasMap();
            ViewBag.MapaAsignaturas = db.getAsignaturas();
            ViewBag.MapaPeriodos = db.getPeriodos();
            ViewBag.MapaHorarios = db.getHorariosMap();
        }
        private void llenarListaDB()
        {
            ViewBag.ListaAulas = db.Aulas.ToList();
            ViewBag.ListaAsignaturas = db.Asignaturas.ToList();
            ViewBag.ListaPeriodo = db.Periodos.ToList();
            ViewBag.ListaHorarios = db.Horarios.ToList();
        }
    }
}
