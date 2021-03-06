﻿using System;
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
    [Authorize(Roles = "perro")]
    public class AsignaturasController : BaseController
    {
        private MoodleConnection db = new MoodleConnection();

        // GET: Asignaturas
        public ActionResult Index()
        {
            ViewBag.CarrerasMap = db.getCarrerasMap();
            return View(db.Asignaturas.ToList());
        }

        // GET: Asignaturas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asignaturas asignaturas = db.Asignaturas.Find(id);
            if (asignaturas == null)
            {
                return HttpNotFound();
            }
            ViewBag.CarrerasMap = db.getCarrerasMap();
            return View(asignaturas);
        }

        // GET: Asignaturas/Create
        public ActionResult Create()
        {
              ViewBag.ListaCarreras = db.Carreras.ToList();
            return View();
        }

        // POST: Asignaturas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Description,Id_Carrera")] Asignaturas asignaturas)
        {
            if (ModelState.IsValid)
            {
                db.Asignaturas.Add(asignaturas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(asignaturas);
        }

        // GET: Asignaturas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asignaturas asignaturas = db.Asignaturas.Find(id);
            if (asignaturas == null)
            {
                return HttpNotFound();
            }
            ViewBag.SelectedID = id;
            ViewBag.ListaCarreras = db.Carreras.ToList();
            return View(asignaturas);
        }

        // POST: Asignaturas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Description,Id_Carrera")] Asignaturas asignaturas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(asignaturas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(asignaturas);
        }

        // GET: Asignaturas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asignaturas asignaturas = db.Asignaturas.Find(id);
            if (asignaturas == null)
            {
                return HttpNotFound();
            }
            ViewBag.CarrerasMap = db.getCarrerasMap();
            return View(asignaturas);
        }

        // POST: Asignaturas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Asignaturas asignaturas = db.Asignaturas.Find(id);
            try
            {
                db.Asignaturas.Remove(asignaturas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                ViewBag.CarrerasMap = db.getCarrerasMap();
                ViewBag.ERROR = "Esta asignatura no puede borrarse porque hay una dependencia con Secciones.";
                return View(asignaturas);
            }
            
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
