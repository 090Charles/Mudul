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
    public class RevisarCalificacionesController : Controller
    {
        private MoodleConnection db = new MoodleConnection();
        int idtipo = 1;
        int idusuario = 3;

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

        // GET: /RevisarCalificaciones/
        public ActionResult Index()
        {
            llenarMapasDB();
            var query = new SQLQuery();
            string qstring = @"Select axa.Id, ac.Description as Actividad, u.Nombre, axa.HoraSubida as [Hora Subida], axa.HoraCalificacion as [Hora Calificacion], axa.Nota
                            from ActividadXAlumno axa 
                            join Actividades ac on axa.Id_actividad=ac.Id
                            join Usuarios u on axa.Id_alumno=u.NumberAccountId";
            DataTable lista = query.getTable(qstring);
            ViewBag.Tabla = lista;
            ViewBag.Formatear = new Func<DateTime?, string>(HoraFormateada);
            return View();
        }

        public ActionResult IndexAlumno(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            if (idtipo == 1)
            {
                var query = new SQLQuery();
                string qstring = @"Select axa.Id, ac.Description as Actividad, u.Nombre, axa.HoraSubida as [Hora Subida], axa.Nota
                            from ActividadXAlumno axa 
                            join Actividades ac on axa.Id_actividad=ac.Id
                            join Usuarios u on axa.Id_alumno=u.NumberAccountId
                            where axa.Id_alumno=" + idusuario.ToString();
                DataTable lista = query.getTable(qstring);
                ViewBag.Tabla = lista;
                ViewBag.Formatear = new Func<DateTime?, string>(HoraFormateada);
                ViewBag.IdActividad = id.Value;
                return View();
            }
            else
                return RedirectToAction("Participaciones", "Actividades", new { id = id.Value });
        }

        // GET: /RevisarCalificaciones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //ActividadXAlumno actividadxalumno = db.ActividadXAlumno.Find(id);
            var query = new SQLQuery();
            string qstring = string.Format("SELECT * FROM dbo.ActividadXAlumno axa WHERE axa.Id={0};", id);
            DataTable datos = query.getTable(qstring);
            ActividadXAlumno actividadxalumno = new ActividadXAlumno();
            foreach (DataRow row in datos.Rows)
            {
                actividadxalumno.Id = (int)row["Id"];
                actividadxalumno.Id_actividad = (int)row["Id_actividad"];
                actividadxalumno.Id_alumno = (int)row["Id_alumno"];
                actividadxalumno.HoraSubida = (DateTime)row["HoraSubida"];
                actividadxalumno.HoraCalificacion = (DateTime)row["HoraCalificacion"];
                actividadxalumno.Nota = (decimal)row["Nota"];
                actividadxalumno.Archivo = row["Archivo"].ToString();
                actividadxalumno.Comentario = row["Comentario"].ToString();
            }

            if (actividadxalumno == null)
            {
                return HttpNotFound();
            }
            llenarMapasDB();
            ViewBag.Formatear = new Func<DateTime?, string>(HoraFormateada);
            ViewBag.IdAXA = actividadxalumno.Id_actividad;
            return View(actividadxalumno);
        }

        // GET: /RevisarCalificaciones/Create
        public ActionResult Create(int? id)
        {
            if (id == null)
                return HttpNotFound();

            ViewBag.IdActividad = id.Value;
            llenarActividadDB(id.Value);
            llenarListaDB();
            return View();
        }

        // POST: /RevisarCalificaciones/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Id_actividad,Id_alumno,HoraSubida,HoraCalificacion,Nota,Archivo,Comentario")] ActividadXAlumno actividadxalumno)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int idact = actividadxalumno.Id_actividad;
                    var query = new SQLQuery();
                    string qstring = "";
                    if (actividadxalumno.HoraSubida == null && actividadxalumno.HoraCalificacion == null && actividadxalumno.Nota==null)
                    {
                        qstring = string.Format(@"INSERT INTO dbo.ActividadXAlumno VALUES({0},{1},{2},{3},null,'{4}','{5}');"
                            , actividadxalumno.Id_actividad, actividadxalumno.Id_alumno
                            , actividadxalumno.HoraFormateada(actividadxalumno.HoraSubida)
                            , actividadxalumno.HoraFormateada(actividadxalumno.HoraCalificacion)
                            , actividadxalumno.Archivo, actividadxalumno.Comentario);
                    }
                    else if (actividadxalumno.HoraSubida == null && actividadxalumno.HoraCalificacion == null && actividadxalumno.Nota != null)
                    {
                        qstring = string.Format(@"INSERT INTO dbo.ActividadXAlumno VALUES({0},{1},{2},{3},{4},'{5}','{6}');"
                            , actividadxalumno.Id_actividad, actividadxalumno.Id_alumno
                            , actividadxalumno.HoraFormateada(actividadxalumno.HoraSubida)
                            , actividadxalumno.HoraFormateada(actividadxalumno.HoraCalificacion)
                            , actividadxalumno.Nota, actividadxalumno.Archivo, actividadxalumno.Comentario);
                    }
                    else if (actividadxalumno.HoraSubida != null && actividadxalumno.HoraCalificacion == null && actividadxalumno.Nota == null)
                    {
                        qstring = string.Format(@"INSERT INTO dbo.ActividadXAlumno VALUES({0},{1},'{2}',{3},null,'{4}','{5}');"
                            , actividadxalumno.Id_actividad, actividadxalumno.Id_alumno
                            , actividadxalumno.HoraFormateada(actividadxalumno.HoraSubida)
                            , actividadxalumno.HoraFormateada(actividadxalumno.HoraCalificacion)
                            , actividadxalumno.Archivo, actividadxalumno.Comentario);
                    }
                    else if (actividadxalumno.HoraSubida != null && actividadxalumno.HoraCalificacion == null && actividadxalumno.Nota != null)
                    {
                        qstring = string.Format(@"INSERT INTO dbo.ActividadXAlumno VALUES({0},{1},'{2}',{3},{4},'{5}','{6}');"
                            , actividadxalumno.Id_actividad, actividadxalumno.Id_alumno
                            , actividadxalumno.HoraFormateada(actividadxalumno.HoraSubida)
                            , actividadxalumno.HoraFormateada(actividadxalumno.HoraCalificacion)
                            , actividadxalumno.Nota, actividadxalumno.Archivo, actividadxalumno.Comentario);
                    }
                    else if (actividadxalumno.HoraSubida == null && actividadxalumno.HoraCalificacion != null && actividadxalumno.Nota == null)
                    {
                        qstring = string.Format(@"INSERT INTO dbo.ActividadXAlumno VALUES({0},{1},{2},'{3}',null,'{4}','{5}');"
                            , actividadxalumno.Id_actividad, actividadxalumno.Id_alumno
                            , actividadxalumno.HoraFormateada(actividadxalumno.HoraSubida)
                            , actividadxalumno.HoraFormateada(actividadxalumno.HoraCalificacion)
                            , actividadxalumno.Archivo, actividadxalumno.Comentario);
                    }
                    else if (actividadxalumno.HoraSubida == null && actividadxalumno.HoraCalificacion != null && actividadxalumno.Nota != null)
                    {
                        qstring = string.Format(@"INSERT INTO dbo.ActividadXAlumno VALUES({0},{1},{2},'{3}',{4},'{5}','{6}');"
                            , actividadxalumno.Id_actividad, actividadxalumno.Id_alumno
                            , actividadxalumno.HoraFormateada(actividadxalumno.HoraSubida)
                            , actividadxalumno.HoraFormateada(actividadxalumno.HoraCalificacion)
                            , actividadxalumno.Nota, actividadxalumno.Archivo, actividadxalumno.Comentario);
                    }
                    else if (actividadxalumno.HoraSubida != null && actividadxalumno.HoraCalificacion != null && actividadxalumno.Nota == null)
                    {
                        qstring = string.Format(@"INSERT INTO dbo.ActividadXAlumno VALUES({0},{1},'{2}','{3}',null,'{4}','{5}');"
                            , actividadxalumno.Id_actividad, actividadxalumno.Id_alumno
                            , actividadxalumno.HoraFormateada(actividadxalumno.HoraSubida)
                            , actividadxalumno.HoraFormateada(actividadxalumno.HoraCalificacion)
                            , actividadxalumno.Archivo, actividadxalumno.Comentario);
                    }
                    else
                    {
                        qstring = string.Format(@"INSERT INTO dbo.ActividadXAlumno VALUES({0},{1},'{2}','{3}',{4},'{5}','{6}');"
                            , actividadxalumno.Id_actividad, actividadxalumno.Id_alumno
                            , actividadxalumno.HoraFormateada(actividadxalumno.HoraSubida)
                            , actividadxalumno.HoraFormateada(actividadxalumno.HoraCalificacion)
                            , actividadxalumno.Nota, actividadxalumno.Archivo, actividadxalumno.Comentario);
                    }
                    ViewBag.ERROR = qstring;
                    int result = query.execute(qstring);
                   /* db.ActividadXAlumno.Add(actividadxalumno);
                    db.SaveChanges();*/
                    if (result == 0)
                    {
                        llenarActividadDB(actividadxalumno.Id_actividad);
                        llenarListaDB();
                        return View(actividadxalumno);
                    }    
                    else
                        return RedirectToAction("Participaciones", "Actividades", new { id=idact });
                    
                }

                return View(actividadxalumno);
            }
            catch (Exception err)
            {
                ViewBag.ERROR = err.Message +"\n" +err.InnerException;
                llenarListaDB();
                return View();
            }
        }

        // GET: /RevisarCalificaciones/Edit/5
        public ActionResult Edit(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                //ActividadXAlumno actividadxalumno = db.ActividadXAlumno.Find(id);
                var query = new SQLQuery();
                string qstring = string.Format("SELECT * FROM dbo.ActividadXAlumno axa WHERE axa.Id={0};", id.Value);
                DataTable datos = query.getTable(qstring);
                if (datos == null)
                {
                    return HttpNotFound();
                }
                ActividadXAlumno actividadxalumno = new ActividadXAlumno();
                foreach (DataRow row in datos.Rows)
                {
                    actividadxalumno.Id = (int)row["Id"];
                    actividadxalumno.Id_actividad = (int)row["Id_actividad"];
                    actividadxalumno.Id_alumno = (int)row["Id_alumno"];

                    if (row["HoraSubida"].ToString() == "")
                        actividadxalumno.HoraSubida = null;
                    else
                        actividadxalumno.HoraSubida = (DateTime)row["HoraSubida"];

                    if (row["HoraCalificacion"].ToString() == "")
                        actividadxalumno.HoraCalificacion = null;
                    else
                        actividadxalumno.HoraCalificacion = DateTime.Parse(row["HoraCalificacion"].ToString());

                    if (row["Nota"].ToString() == "")
                        actividadxalumno.Nota = null;
                    else
                        actividadxalumno.Nota = (decimal)row["Nota"];
                    actividadxalumno.Archivo = row["Archivo"].ToString();
                    actividadxalumno.Comentario = row["Comentario"].ToString();
                }
                if (actividadxalumno == null)
                {
                    return HttpNotFound();
                }
                llenarListaDB();
                ViewBag.IdAXA = actividadxalumno.Id_actividad;
                return View(actividadxalumno);
            }
            catch(Exception err)
            {
                ViewBag.ERROR = err.Message + "\n" + err.InnerException;
                llenarListaDB();
                if (id != null)
                    ViewBag.IdAXA = id.Value;
                return View();
            }
        }

        // POST: /RevisarCalificaciones/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Id_actividad,Id_alumno,HoraSubida,HoraCalificacion,Nota,Archivo,Comentario")] ActividadXAlumno actividadxalumno)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    /*db.Entry(actividadxalumno).State = EntityState.Modified;
                    db.SaveChanges();*/
                    var query = new SQLQuery();
                    string qstring = "";
                    if (actividadxalumno.HoraCalificacion == null && actividadxalumno.Nota==null)
                    {
                        qstring = string.Format(@"UPDATE dbo.ActividadXAlumno SET HoraCalificacion={0},Nota=null,Comentario='{1}' WHERE Id={2};"
                             , actividadxalumno.HoraFormateada(actividadxalumno.HoraCalificacion)
                             , actividadxalumno.Comentario, actividadxalumno.Id);
                    }
                    else if (actividadxalumno.HoraCalificacion != null && actividadxalumno.Nota == null)
                    {
                        qstring = string.Format(@"UPDATE dbo.ActividadXAlumno SET HoraCalificacion='{0}',Nota=null,Comentario='{1}' WHERE Id={2};"
                             , actividadxalumno.HoraFormateada(actividadxalumno.HoraCalificacion)
                             , actividadxalumno.Comentario, actividadxalumno.Id);
                    }
                    else
                    {
                        qstring = string.Format(@"UPDATE dbo.ActividadXAlumno SET HoraCalificacion='{0}',Nota={1},Comentario='{2}' WHERE Id={3};"
                             , actividadxalumno.HoraFormateada(actividadxalumno.HoraCalificacion)
                             , actividadxalumno.Nota, actividadxalumno.Comentario, actividadxalumno.Id);
                    }
                    ViewBag.ERROR = qstring;
                    int result = query.execute(qstring);
                    if (result == 0)
                    {
                        llenarListaDB();
                        return View();
                    }
                    else
                    {
                        qstring = string.Format("select Id_actividad from ActividadXAlumno where Id={0}", actividadxalumno.Id);
                        DataTable resultado = query.getTable(qstring);
                        if (resultado == null)
                            return RedirectToAction("Index", "VerClasesMaestro");
                        else
                        {
                            int idact = 0;
                            foreach (DataRow row in resultado.Rows)
                            {
                                idact = int.Parse(row["Id_actividad"].ToString());
                            }
                            return RedirectToAction("Participaciones", "Actividades", new { id = idact });
                        }
                    }
                }
                return View(actividadxalumno);
            }
            catch (Exception err)
            {
                ViewBag.ERROR = err.Message + "\n" + err.InnerException;
                llenarListaDB();
                return View();
            }
        }

        // GET: /RevisarCalificaciones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //ActividadXAlumno actividadxalumno = db.ActividadXAlumno.Find(id);
            var query = new SQLQuery();
            string qstring = string.Format("SELECT * FROM dbo.ActividadXAlumno axa WHERE axa.Id={0};", id);
            DataTable datos = query.getTable(qstring);
            ActividadXAlumno actividadxalumno = new ActividadXAlumno();
            foreach (DataRow row in datos.Rows)
            {
                actividadxalumno.Id = (int)row["Id"];
                actividadxalumno.Id_actividad = (int)row["Id_actividad"];
                actividadxalumno.Id_alumno = (int)row["Id_alumno"];
                if (row["HoraSubida"].ToString() == "")
                    actividadxalumno.HoraSubida = null;
                else
                    actividadxalumno.HoraSubida = (DateTime)row["HoraSubida"];
                if (row["HoraCalificacion"].ToString() == "")
                    actividadxalumno.HoraCalificacion = null;
                else
                    actividadxalumno.HoraCalificacion = (DateTime)row["HoraCalificacion"];
                if (row["Nota"].ToString() == null)
                    actividadxalumno.Nota = null;
                else
                    actividadxalumno.Nota = (decimal)row["Nota"];
                actividadxalumno.Archivo = row["Archivo"].ToString();
                actividadxalumno.Comentario = row["Comentario"].ToString();
            }

            if (actividadxalumno == null)
            {
                return HttpNotFound();
            }
            llenarMapasDB();
            ViewBag.Formatear = new Func<DateTime?, string>(HoraFormateada);
            ViewBag.IdActividad = actividadxalumno.Id_actividad;
            return View(actividadxalumno);
        }

        // POST: /RevisarCalificaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            /*ActividadXAlumno actividadxalumno = db.ActividadXAlumno.Find(id);
            db.ActividadXAlumno.Remove(actividadxalumno);
            db.SaveChanges();*/
            try
            {
                var query = new SQLQuery();
                string qstring = string.Format("SELECT Id_actividad FROM dbo.ActividadXAlumno axa WHERE axa.Id={0};", id);
                DataTable datos = query.getTable(qstring);
                if (datos == null)
                {
                    llenarMapasDB();
                    return View(id);
                }
                int actividadxalumno = 0;
                foreach (DataRow row in datos.Rows)
                {
                    actividadxalumno = (int)row["Id_alumno"];
                }

                query = new SQLQuery();
                qstring = string.Format("DELETE FROM dbo.ActividadXAlumno WHERE Id={0};",id);
                int result = query.execute(qstring);
                if (result == 0)
                {
                    llenarMapasDB();
                    return View(id);
                }
                else
                {
                    return RedirectToAction("Participaciones", "Actividades", new { id = actividadxalumno });
                }
            }
            catch (Exception err)
            {
                ViewBag.ERROR = err.Message + "\n" + err.InnerException;
                llenarMapasDB();
                return View(id);
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

        private void llenarListaDB()
        {
            var lista = db.Usuarios.ToList();
            List<Usuarios> alumnos = new List<Usuarios>();
            foreach (Usuarios user in lista)
            {
                if (user.Id_TipoUsuario == 1)
                    alumnos.Add(user);
            }
            ViewBag.ListaAlumnos = alumnos;
        }
        private void llenarMapasDB()
        {
            ViewBag.MapaActividades = db.getActividadesMap();
            ViewBag.MapaAlumnos = db.getAlumnosMap();
            ViewBag.MapaActividadesDescr = db.getActividadesDescripcionMap();
        }

        private void llenarActividadDB(int id)
        {
            var lista = db.Actividades.ToList();
            List<Actividades> actividades = new List<Actividades>();
            foreach (Actividades act in lista)
            {
                if (act.Id == id)
                {
                    actividades.Add(act);
                }
            }
            ViewBag.ListaActividades = actividades;
        }
    }
}
