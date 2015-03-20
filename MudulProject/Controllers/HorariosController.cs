using MudulProject.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace MudulProject.Controllers
{
    public class HorariosController : Controller
    {
        private MoodleConnection db = new MoodleConnection();
        //
        // GET: /Horarios/
        public ActionResult Index()
        {
            ViewBag.HorariosMap = db.getHorariosMap();
            return View(db.Horarios.ToList());
        }
	
    // GET: Horarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Horarios horario = db.Horarios.Find(id);
            if (horario == null)
            {
                return HttpNotFound();
            }
            ViewBag.HorariosMap = db.getHorariosMap();
            return View(horario);
        }

        // GET: Horarios/Create
        public ActionResult Create()
        {
            return View();
        }
        // POST: Horarios/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Hora")] Horarios horario)
        {
            if (ModelState.IsValid)
            {
                db.Horarios.Add(horario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(horario);
        }
        // GET: Horarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Horarios horario = db.Horarios.Find(id);
            if (horario == null)
            {
                return HttpNotFound();
            }
            ViewBag.SelectedID = id;
            return View(horario);
        }

        // POST: Horarios/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Hora")] Horarios horario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(horario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(horario);
        }

        // GET: Asignaturas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Horarios horarios = db.Horarios.Find(id);
            if (horarios == null)
            {
                return HttpNotFound();
            }
            ViewBag.HorariosMap = db.getHorariosMap();
            return View(horarios);
        }

        // POST: Asignaturas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Horarios horarios = db.Horarios.Find(id);
            try
            {
                db.Horarios.Remove(horarios);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                ViewBag.AulasMap = db.getAulasMap();
                ViewBag.ERROR = "Este Horario no puede borrarse porque hay una dependencia con Secciones.";
                return View(horarios);
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
