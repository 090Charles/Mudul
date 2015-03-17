using MudulProject.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MudulProject.Controllers
{
    public class HistorialClasesController : Controller
    {
        //
        // GET: /HistorialClases/
        public ActionResult Index()
        {
           /* var table = new HistorialClases();
            {
                table.tabla = table.Retornar_Tabla(5);
            }
            ViewData["HistorialClases"] = table;
            return View(ViewData);*
            var tab= new HistorialClases();
            ViewData = tab.Retornar_Tabla(3);
            return View();
            */
            ViewData["Message"] = "Welcome to ASP.NET MVC!";
            DataTable dt = new DataTable("MyTable");
            dt.Columns.Add(new DataColumn("Col1", typeof(string)));
            dt.Columns.Add(new DataColumn("Col2", typeof(string)));
            dt.Columns.Add(new DataColumn("Col3", typeof(string)));

            for (int i = 0; i < 3; i++)
            {
                DataRow row = dt.NewRow();
                row["Col1"] = "col 1, row " + i;
                row["Col2"] = "col 2, row " + i;
                row["Col3"] = "col 3, row " + i;
                dt.Rows.Add(row);
            }

            return View(dt); //passing the DataTable as my Model



        }

        //
        // GET: /HistorialClases/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /HistorialClases/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /HistorialClases/Create
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
        // GET: /HistorialClases/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /HistorialClases/Edit/5
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
        // GET: /HistorialClases/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /HistorialClases/Delete/5
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
