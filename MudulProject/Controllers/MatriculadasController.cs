using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MudulProject.Models;
using System.Data.SqlClient;
namespace MudulProject.Controllers
{
    public class MatriculadasController : Controller
    {


        private MoodleConnection db = new MoodleConnection();

        SqlConnection myConnection = new SqlConnection("user id=yhntegtlbtlwbuez;" +
           "password=MNGvonjT5dVR55SSVKNV4cgJxfNtrSaPpGVENBnShVZfAcEgcQhziwbJG77hGYAk;server=ac970e83-6c66-4005-aa62-a4450024e8ae.sqlserver.sequelizer.com;" +
           "database=dbac970e836c664005aa62a4450024e8ae; " +
           "connection timeout=30");

        //
        // GET: /Matriculadas/
        public ActionResult Index()
        {



            List<Array> list1 = Matriculas();
            ViewBag.Matriculas(list1);
            return View(db.Asignaturasmatriculadas.ToList());
        }


        public List<Array> Matriculas()
        {
            List<Array> list = new List<Array>();
            string id = "";
            string fecha = "";
            string cuenta = "";
            string nombre = "";
            string tipoMatricula = "";
            string campus = "";
            string lugarCampus = "";
            
            try
            {
                myConnection.Open();
                string query = @"select  M.Id id,
		                                M.FechaMatricula fecha,
		                                U.NumberAccountId cuenta,
		                                U.Nombre nombre,
		                                TM.Description tipoMatricula, 
		                                C.Description campus,
		                                C.Lugar lugarCampus
                                from Matriculas as M 
	                                inner join Usuarios as U
			                                on M.NumberAccountId_Usuarios = U.NumberAccountId
	                                inner join TipoMatriculas as TM
			                                on M.Id_TipoMatricula = TM.Id
	                                inner join Campus as C
			                                on M.Id_Campus = C.Id;";
                SqlCommand myCommand = new SqlCommand(query, myConnection);

                SqlDataReader myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    id = myReader["Id"].ToString();
                    fecha = myReader["fecha"].ToString();
                    cuenta = myReader["cuenta"].ToString();
                    nombre = myReader["nombre"].ToString();
                    tipoMatricula = myReader["tipoMatricula"].ToString();
                    campus = myReader["campus"].ToString();
                    lugarCampus = myReader["lugarCampus"].ToString();
                    string[] a = {id,fecha,cuenta,nombre,tipoMatricula,campus,lugarCampus}; 
                    list.Add(a);
                    
                }
                    
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            return list;

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
