using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MudulProject.Controllers
{
    public class SubirArchivoController : Controller
    {

        SqlConnection myConnection = new SqlConnection("user id=yhntegtlbtlwbuez;" +
            "password=MNGvonjT5dVR55SSVKNV4cgJxfNtrSaPpGVENBnShVZfAcEgcQhziwbJG77hGYAk;server=ac970e83-6c66-4005-aa62-a4450024e8ae.sqlserver.sequelizer.com;" +
            "database=dbac970e836c664005aa62a4450024e8ae; " +
            "connection timeout=30");
        //
        // GET: /SubirArchivo/
        public ActionResult Index(int id)
        {
            ViewData["idActividad"] = id; 
            return View();
        }

        //
        // GET: /SubirArchivo/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /SubirArchivo/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /SubirArchivo/Create
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


        [HttpPost]
        public object SubirArchivo()
        {
            
            string query ="";
            string nombreArchivo = "";




            if (Request.Files.Count > 0)
            {
                var file = Request.Files[0];
                if (file != null && file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var path = Path.Combine(Server.MapPath("~/Images/"), actividad+"-"+fileName); 
                    file.SaveAs(path);

                    nombreArchivo = actividad+"-"+fileName;
                    query = @"update ActividadXAlumno 
                                        set Archivo = '" + actividad + "-" + fileName + "' where Id ="+actividad;

                    

                }
            }


            ViewData["estadoArchivo"] = actualizarActividad(query);
            ViewData["nombreArchivo"] = nombreArchivo;


            return View("Actividad");
        }



        public string actualizarActividad(string query)
        {
            try
            {
                myConnection.Open();
                SqlCommand myCommand = new SqlCommand(query, myConnection);
                SqlDataReader myReader = myCommand.ExecuteReader();
                //return RedirectToAction("Clases/" + idMatricula, "ClasesMatriculadas");
                return "1";
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            return "0";
        }
        //
        // GET: /SubirArchivo/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /SubirArchivo/Edit/5
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
        // GET: /SubirArchivo/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /SubirArchivo/Delete/5
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
