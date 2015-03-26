using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MudulProject.Models;
using BibliotecaApp;

namespace MudulProject.Controllers
{
    public class ActividadesController : Controller
    {
        private MoodleConnection db = new MoodleConnection();
        public string HoraFormateada(DateTime? hora)
        {
            if (hora != null)
            {
                DateTime hour = hora.Value;
                return hour.ToString("t");
            }
            else
                return "No se pudo convertir la hora";
        }

        public string FechaFormateada(DateTime? fecha)
        {
            if (fecha != null)
            {
                DateTime date = fecha.Value;
                return string.Format("{0}-{1}-{2} {3}:{4}",date.Year,date.Month,date.Day,date.Hour,date.Minute);
            }
            else
                return "No se pudo convertir la fecha";
        }

        // GET: /Actividades/
        /*public ActionResult Index()
        {
            return View(db.Actividades.ToList());
        } */
        private void llenarListaDB(int id)
        {            
            var lista = db.Secciones.ToList();
            List<Secciones> secciones = new List<Secciones>();
            foreach (Secciones section in lista)
            {
                if (section.Id == id)
                    secciones.Add(section);
            }
            ViewBag.ListaSecciones = secciones;
        }

        public ActionResult Index(int? id)
        {
            if (id == null)
            {
                ViewBag.Mensaje = "Id no enviado";
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var query = new SQLQuery();
            string squery=string.Format(@"Select * from Actividades ac where ac.Id_seccion={0};",id.Value);
            DataTable actividades = query.getTable(squery);
            if (actividades == null)
            {
                return HttpNotFound();
            }
            ViewBag.Tabla = actividades;
            ViewBag.HoraFormat = new Func<DateTime?, string>(HoraFormateada);

            //buscar id_asignaturas para el boton regresar
            squery = string.Format(@"Select Id_Asignaturas from Secciones sec where sec.Id={0};", id.Value);
            DataTable id_asignaturas = query.getTable(squery);
            if (id_asignaturas != null)
            {
                int? idasig = 0;
                foreach (DataRow row in id_asignaturas.Rows)
                {
                    foreach (DataColumn col in id_asignaturas.Columns)
                    {
                        idasig = int.Parse(row[col.ColumnName].ToString());
                    }
                }
                if(idasig!=null)
                    ViewBag.Id_Asignaturas = idasig;
            }
            //Idsecciones para el boton regresar de create
            ViewBag.IdSeccion = id.Value;
            return View();
        }

        // GET: /Actividades/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Actividades actividades = db.Actividades.Find(id);
            if (actividades == null)
            {
                return HttpNotFound();
            }
            return View(actividades);
        }

        // GET: /Actividades/Create
        public ActionResult Create(int? id)
        {
            if (id != null)
            {
                ViewBag.IdSeccion = id.Value;
                llenarListaDB(id.Value);
            }
            return View();
        }

        // POST: /Actividades/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Id_seccion,HoraInicio,HoraLimite,Titulo,Description,Ponderacion")] Actividades actividades)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Actividades.Add(actividades);
                    db.SaveChanges();
                    return RedirectToAction("Index", new { id = actividades.Id_seccion });
                }
            }
            catch (Exception err)
            {
                ViewBag.ERROR = err.Message + "\n" + err.InnerException;                
            }
            return View(actividades);
        }

        // GET: /Actividades/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Actividades actividades = db.Actividades.Find(id);
            if (actividades == null)
            {
                return HttpNotFound();
            }
            ViewBag.FechaFormat = new Func<DateTime?, string>(FechaFormateada);
            return View(actividades);
        }

        // POST: /Actividades/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Id_seccion,HoraInicio,HoraLimite,Titulo,Description,Ponderacion")] Actividades actividades)
        {
            if (ModelState.IsValid)
            {
                /*db.Entry(actividades).State = EntityState.Modified;
                db.SaveChanges();*/
                string fecha1=FechaFormateada(actividades.HoraInicio);
                string fecha2=FechaFormateada(actividades.HoraLimite);

                var query = new SQLQuery();
                string squery = string.Format(@"Update dbo.Actividades Set HoraInicio='{0}',HoraLimite='{1}'
,Titulo='{2}',Description='{3}',Ponderacion={4} where Id={5};"
, fecha1, fecha2, actividades.Titulo, actividades.Description, actividades.Ponderacion, actividades.Id);
                int result = query.execute(squery);
                ViewBag.Query = squery;
                if (result == 0)
                    return View(actividades);
                else
                    return RedirectToAction("Index", new { id= actividades.Id_seccion});
            }
            return View(actividades);
        }

        // GET: /Actividades/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Actividades actividades = db.Actividades.Find(id);
            if (actividades == null)
            {
                return HttpNotFound();
            }
            return View(actividades);
        }

        // POST: /Actividades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Actividades actividades = db.Actividades.Find(id);
            db.Actividades.Remove(actividades);
            db.SaveChanges();
            return RedirectToAction("Index", new { id=id });
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
