using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MudulProject.Models;
using System.Data;
using System.Data.SqlClient;
namespace MudulProject.Controllers
{
    public class ClasesMatriculadasController : Controller
    {
        SqlConnection myConnection = new SqlConnection("user id=yhntegtlbtlwbuez;" +
                    "password=MNGvonjT5dVR55SSVKNV4cgJxfNtrSaPpGVENBnShVZfAcEgcQhziwbJG77hGYAk;server=ac970e83-6c66-4005-aa62-a4450024e8ae.sqlserver.sequelizer.com;" +
                    "database=dbac970e836c664005aa62a4450024e8ae; " +
                    "connection timeout=30");

        //
        // GET: /ClasesMatriculadas/
        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /ClasesMatriculadas/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /ClasesMatriculadas/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /ClasesMatriculadas/Create
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
        // GET: /ClasesMatriculadas/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        public ActionResult Clases(int id)
        {

            var List1 = ClasesMatriculadas(id);
            ViewData["clasesMatriculadas"] = List1;
            ViewData["matricula"] = id;
            return View();
        }


        public List<ClasesMatriculadas> ClasesMatriculadas(int id)
        {

            
            var List1 = new List<ClasesMatriculadas>();

            string query = @"SELECT  AM.Id id,
		                                        A.Description descripcion
                                          FROM Asignaturasmatriculadas AM
                                                inner join Asignaturas A
                                                     on AM.Id_Asignaturas = A.Id
                                                 where AM.Id_Matricula =" + id.ToString();


            try
            {
                myConnection.Open();
                SqlCommand myCommand = new SqlCommand(query, myConnection);
                SqlDataReader myReader = myCommand.ExecuteReader();

                while (myReader.Read())
                {
                    var item = new ClasesMatriculadas()
                    {
                        Id = (int)(myReader["id"]),
                        Descripcion = myReader["descripcion"].ToString(),


                    };


                    List1.Add(item);

                }


            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            return List1;

        }
        //
        // POST: /ClasesMatriculadas/Edit/5
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
        // GET: /ClasesMatriculadas/Delete/5
        public ActionResult Delete(int id,int idMatricula)
        {
            string query = @"delete from Asignaturasmatriculadas 
	                            where Id = " + id.ToString();


            try
            {
                myConnection.Open();
                SqlCommand myCommand = new SqlCommand(query, myConnection);
                SqlDataReader myReader = myCommand.ExecuteReader();
                return RedirectToAction("Clases/" + idMatricula, "ClasesMatriculadas");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }


            return View();
        }


        public ActionResult VistaAdicionar(int id,int idMatricula,int cuenta)
        {

            var clases = clasesDisponibles(id);
            ViewData["clases"] = clases;
            ViewData["idMatricula"] = idMatricula;
            ViewData["cuenta"] = cuenta;
            return View();
        }

        public List<Asignaturas1> clasesDisponibles(int id)
        {
            var list = new List<Asignaturas1>();
            string query = @"select 
	                              *	 
                            from
	                            Asignaturas
	                            where Id not in (select 
		                            A.Id_Asignaturas
                            from 
		                            Asignaturasmatriculadas A
			                            inner join Matriculas M
		                            on A.Id_Matricula = M.Id
		                            where M.NumberAccountId_Usuarios =" + id + "); ";

            try
            {
                myConnection.Open();
                SqlCommand myCommand = new SqlCommand(query, myConnection);
                SqlDataReader myReader = myCommand.ExecuteReader();

                while (myReader.Read())
                {
                    var item = new Asignaturas1()
                    {
                        Id = (int)(myReader["Id"]),
                        Descripcion = myReader["Description"].ToString(),         
                    };
                    list.Add(item);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            return list;
        }

        public ActionResult Adicionar(int idClase,int idMatricula,int cuenta)
        {
            string query = @"insert into Asignaturasmatriculadas
                           (Id_Asignaturas,Id_Matricula) values ("+idClase+","+ idMatricula+");";

            try
            {
                myConnection.Open();
                SqlCommand myCommand = new SqlCommand(query, myConnection);
                SqlDataReader myReader = myCommand.ExecuteReader();
                return RedirectToAction("Clases/"+idMatricula,"ClasesMatriculadas");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            return null;

        }

        //
        // POST: /ClasesMatriculadas/Delete/5
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
