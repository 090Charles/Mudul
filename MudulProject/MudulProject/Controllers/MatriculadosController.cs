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
    public class MatriculadosController : Controller
    {
        private MoodleConnection db = new MoodleConnection();
        SqlConnection myConnection = new SqlConnection("user id=yhntegtlbtlwbuez;" +
                                                       "password=MNGvonjT5dVR55SSVKNV4cgJxfNtrSaPpGVENBnShVZfAcEgcQhziwbJG77hGYAk;server=ac970e83-6c66-4005-aa62-a4450024e8ae.sqlserver.sequelizer.com;" +
                                                       "database=dbac970e836c664005aa62a4450024e8ae; " +
                                                       "connection timeout=30");
        // GET: /Matriculados/
        public ActionResult Index()
        {

            var  list1 = Matriculas();
            ViewData["matriculas"] = list1;
            return View();
        }

        public List<_matriculas> Matriculas()
        {
            var list = new List<_matriculas>();

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
                    var item = new _matriculas()
                    {
                        Id = myReader["Id"].ToString(),
                        Fecha = myReader["fecha"].ToString(),
                        Cuenta = myReader["cuenta"].ToString(),
                        Nombre = myReader["nombre"].ToString(),
                        TipoMatricula = myReader["tipoMatricula"].ToString(),
                        Campus = myReader["campus"].ToString(),
                        LugarCampus = myReader["lugarCampus"].ToString()

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

        // GET: /Matriculados/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Matriculas matricula = db.Matriculas.Find(id);
            if (matricula == null)
            {
                return HttpNotFound();
            }
            return View(matricula);
        }

        // GET: /Matriculados/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Matriculados/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,FechaMatricula,NumberAccountId_Usuarios,Id_TipoMatricula,Id_MetodosDePago,Id_Campus,Total")] Matriculas matricula)
        {
            if (ModelState.IsValid)
            {
                db.Matriculas.Add(matricula);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(matricula);
        }

        // GET: /Matriculados/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Matriculas matricula = db.Matriculas.Find(id);
            if (matricula == null)
            {
                return HttpNotFound();
            }
            return View(matricula);
        }

        // POST: /Matriculados/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,FechaMatricula,NumberAccountId_Usuarios,Id_TipoMatricula,Id_MetodosDePago,Id_Campus,Total")] Matriculas matricula)
        {
            if (ModelState.IsValid)
            {
                db.Entry(matricula).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(matricula);
        }

        // GET: /Matriculados/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Matriculas matricula = db.Matriculas.Find(id);
            if (matricula == null)
            {
                return HttpNotFound();
            }
            return View(matricula);
        }

        // POST: /Matriculados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Matriculas matricula = db.Matriculas.Find(id);
            db.Matriculas.Remove(matricula);
            db.SaveChanges();
            return RedirectToAction("Index");
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
