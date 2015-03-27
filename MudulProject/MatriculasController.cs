using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MudulProject.Models;

namespace MudulProject
{
    public class MatriculasController : Controller
    {
        private MoodleConnection db = new MoodleConnection();

        // GET: Matriculas
        public ActionResult Index()
        {
            ViewBag.AlumnosMap = db.getAlumnosMap();
            ViewBag.TiposMatriculaMap = db.getTiposMatriculaMap();
            ViewBag.MetodosDePagoMap = db.getMetodosDePagoMap();
            ViewBag.CampusesMap = db.getCampusesMap();
            return View(db.Matriculas.ToList());
        }

        // GET: Matriculas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Matriculas matriculas = db.Matriculas.Find(id);
            if (matriculas == null)
            {
                return HttpNotFound();
            }
            ViewBag.AlumnosMap = db.getAlumnosMap();
            ViewBag.TiposMatriculaMap = db.getTiposMatriculaMap();
            ViewBag.MetodosDePagoMap = db.getMetodosDePagoMap();
            ViewBag.CampusesMap = db.getCampusesMap();
            return View(matriculas);
        }

        // GET: Matriculas/Create
        public ActionResult Create()
        {
            ViewBag.ListaAlumnos = db.Usuarios.ToList();
            ViewBag.ListaTiposMatricula = db.TipoMatriculas.ToList();
            ViewBag.ListaMetodosDePago = db.MetodosDePagos.ToList();
            ViewBag.ListaCampuses = db.Campuses.ToList();

            

            return View();
        }

        // POST: Matriculas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FechaMatricula,NumberAccountId_Usuarios,Id_TipoMatricula,Id_MetodosDePago,Id_Campus,Total")] Matriculas matriculas)
        {
            if (ModelState.IsValid)
            {
                db.Matriculas.Add(matriculas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(matriculas);
        }

        // GET: Matriculas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Matriculas matriculas = db.Matriculas.Find(id);
            if (matriculas == null)
            {
                return HttpNotFound();
            }

            ViewBag.ListaAlumnos = db.Usuarios.ToList();
            ViewBag.ListaTiposMatricula = db.TipoMatriculas.ToList();
            ViewBag.ListaMetodosDePago = db.MetodosDePagos.ToList();
            ViewBag.ListaCampuses = db.Campuses.ToList();


            ViewBag.SelectedID = id;

            return View(matriculas);
        }

        // POST: Matriculas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FechaMatricula,NumberAccountId_Usuarios,Id_TipoMatricula,Id_MetodosDePago,Id_Campus,Total")] Matriculas matriculas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(matriculas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(matriculas);
        }

        // GET: Matriculas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Matriculas matriculas = db.Matriculas.Find(id);
            if (matriculas == null)
            {
                return HttpNotFound();
            }

            ViewBag.AlumnosMap = db.getAlumnosMap();
            ViewBag.TiposMatriculaMap = db.getTiposMatriculaMap();
            ViewBag.MetodosDePagoMap = db.getMetodosDePagoMap();
            ViewBag.CampusesMap = db.getCampusesMap();
            return View(matriculas);
        }

        // POST: Matriculas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Matriculas matriculas = db.Matriculas.Find(id);
            db.Matriculas.Remove(matriculas);
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
