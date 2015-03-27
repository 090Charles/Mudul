using MudulProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MudulProject.Controllers
{
     [Authorize]
    public class AulasController : BaseController
    {
        private MoodleConnection db = new MoodleConnection();
        //
        // GET: /Aulas/
        public ActionResult Index()
        {
            ViewBag.AulasMap = db.getAulasMap();
            return View(db.Aulas.ToList());
        }
        // GET: Aulas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aula aulas = db.Aulas.Find(id);
            if (aulas == null)
            {
                return HttpNotFound();
            }
            ViewBag.AulasMap = db.getAulasMap();
            return View(aulas);
        }

        // GET: Asignaturas/Create
        public ActionResult Create()
        {
            return View();
        }
        // POST: Asignaturas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Description,Floor")] Aula aulas)
        {
            if (ModelState.IsValid)
            {
                db.Aulas.Add(aulas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(aulas);
        }
        // GET: Asignaturas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aula aulas = db.Aulas.Find(id);
            if (aulas == null)
            {
                return HttpNotFound();
            }
            ViewBag.SelectedID = id;
            return View(aulas);
        }

        // POST: Asignaturas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Description,Floor")] Aula aulas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aulas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aulas);
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