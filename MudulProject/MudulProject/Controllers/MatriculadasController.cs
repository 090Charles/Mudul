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
    public class MatriculadasController : Controller
    {

        private MoodleConnection db = new MoodleConnection();

        //
        // GET: /Matriculadas/
        public ActionResult Index()
        {
            return View(db.Asignaturasmatriculadas.ToList());
        }

        //
        // GET: /Matriculadas/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Matriculadas/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Matriculadas/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Matriculadas/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Matriculadas/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Matriculadas/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Matriculadas/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
