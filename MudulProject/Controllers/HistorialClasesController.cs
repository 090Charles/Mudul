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
            HistorialClases history = new HistorialClases();
            var sqlQuery = new SQLQuery();
            string queryString = @" SELECT N.Description as Asignatura, S.Id as Seccion ,Sum(X.nota) as Total_Nota 
				                    FROM Matriculas M JOIN AsignaturasMatriculadas AM 
                                    ON M.Id=AM.Id_Matricula JOIN Asignaturas N 
				                    ON AM.Id_Asignaturas=N.Id JOIN Secciones S
				                    ON N.Id=S.Id_Asignaturas  JOIN Actividades A 
				                    ON S.Id=A.Id_seccion  JOIN ActividadXAlumno X
				                    ON A.Id=X.Id_actividad  
				                    WHERE M.NumberAccountId_Usuarios=3 GROUP BY N.Description , S.Id";

            DataTable lista = sqlQuery.getTable(queryString);
            history.tabla = lista;
            ViewBag.Tabla = lista;                
            return View(); 
            
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
