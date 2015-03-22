using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MudulProject.Models
{
    public class MoodleConnection : DbContext
    {

        public DbSet<Actividades> Actividades { get; set; }
        public DbSet<Asignaturas> Asignaturas { get; set; }
        public DbSet<Aula> Aulas { get; set; }
        public DbSet<Carreras> Carreras { get; set; }
        public DbSet<Horarios> Horarios { get; set; }
        public DbSet<Secciones> Secciones { get; set; }
        public System.Data.Entity.DbSet<Asignaturasmatriculadas> Asignaturasmatriculadas { get; set; }
        public System.Data.Entity.DbSet<AsignaturasXMaestro> AsignaturasXMaestro { get; set; }
        public System.Data.Entity.DbSet<Matriculas> Matriculas { get; set; }
        public System.Data.Entity.DbSet<MudulProject.Models.ActividadXAlumno> ActividadXAlumno { get; set; }
        public System.Data.Entity.DbSet<MudulProject.Models.Periodos> Periodos { get; set; }
        public System.Data.Entity.DbSet<MudulProject.Models.TipoUsuario> TipoUsuarios { get; set; }
        public System.Data.Entity.DbSet<MudulProject.Models.Usuarios> Usuarios { get; set; }

        // - - - -  mapas para dropdown - - - - 
        public Dictionary<int, string> getCarrerasMap()
        {
            Dictionary<int, string> returnMap = new Dictionary<int, string>();
            foreach (Carreras carrera in Carreras.ToList())
            {
                returnMap.Add(carrera.Id, carrera.Description);
            }
            return returnMap;
        }
        public Dictionary<int, string> getAulasMap()
        {
            Dictionary<int, string> returnMap = new Dictionary<int, string>();
            foreach (Aula aula in Aulas.ToList())
            {
                returnMap.Add(aula.Id,aula.Description);
            }
            return returnMap;
        }
        public Dictionary<int, string> getTipoUsuariosMap()
        {
            Dictionary<int, string> returnMap = new Dictionary<int, string>();
            foreach (TipoUsuario tipo in TipoUsuarios.ToList())
            {
                returnMap.Add(tipo.Id, tipo.Description);
            }
            return returnMap;
        }

        public Dictionary<int, string> getAulasMap2()
        {
            Dictionary<int, string> returnMap = new Dictionary<int, string>();
            foreach (Aula aula in Aulas.ToList())
            {
                returnMap.Add(aula.Id, aula.ToString());
            }
            return returnMap;
        }

        public Dictionary<int, String> getPeriodos()
        {
            Dictionary<int, String> returnMap = new Dictionary<int, String>();
            foreach (Periodos periodo in Periodos.ToList())
            {
                returnMap.Add(periodo.Id, periodo.Periodo +" - " + periodo.Anio);
            }
            return returnMap;
        }
        public Dictionary<int, string> getAsignaturas()
        {
            Dictionary<int, string> returnMap = new Dictionary<int, string>();
            foreach (Asignaturas asignatura in Asignaturas.ToList())
            {
                returnMap.Add(asignatura.Id,asignatura.Description);
            }
            return returnMap;
        }
        public Dictionary<int, string> getHorariosMap()
        {
            Dictionary<int, string> returnMap = new Dictionary<int, string>();
            foreach (Horarios horario in Horarios.ToList())
            {
                returnMap.Add(horario.Id, horario.HoraFormateada);
            }
            return returnMap;
        }


        public Dictionary<int, string> getActividadesMap()
        {
            Dictionary<int, string> returnMap = new Dictionary<int, string>();
            foreach (Actividades act in Actividades.ToList())
            {
                returnMap.Add(act.Id, act.Description);
            }
            return returnMap;
        }

        public Dictionary<int, string> getAlumnosMap()
        {
            Dictionary<int, string> returnMap = new Dictionary<int, string>();
            foreach (Usuarios user in Usuarios.ToList())
            {
                if (user.Id_TipoUsuario == 1)
                    returnMap.Add(user.NumberAccountId, user.Nombre);
            }
            return returnMap;
        }

        public Dictionary<int, string> getMaestrosMap()
        {
            Dictionary<int, string> returnMap = new Dictionary<int, string>();
            foreach (Usuarios user in Usuarios.ToList())
            {
                if (user.Id_TipoUsuario == 2)
                    returnMap.Add(user.NumberAccountId, user.Nombre);
            }
            return returnMap;
        }
    }
}