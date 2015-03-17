using BibliotecaApp;
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


            HistorialClases history = new HistorialClases();
            var sqlQuery = new SQLQuery();
            string queryString = @" SELECT L.id,L.Description,L.Id_Carrera
                                    FROM Matriculas M JOIN AsignaturasMatriculadas A 
                                    ON M.Id=A.Id_Matricula JOIN Asignaturas L 
                                    ON A.Id_Asignaturas=L.Id
                                    WHERE M.NumberAccountId_Usuarios=3";

            DataTable lista = sqlQuery.getTable(queryString);
            history.tabla = lista;
            ViewBag.Tabla = lista;
                

            return View(); //passing the DataTable as my Model



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
