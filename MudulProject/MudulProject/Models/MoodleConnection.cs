﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MudulProject.Models
{
    public class MoodleConnection : DbContext
    {
        public DbSet<Asignaturas> Asignaturas { get; set; }
        public DbSet<Carreras> Carreras { get; set; }

        public System.Data.Entity.DbSet<MudulProject.Models.Usuarios> Usuarios { get; set; }

        public System.Data.Entity.DbSet<MudulProject.Models.TipoUsuario> TipoUsuarios { get; set; }

        public System.Data.Entity.DbSet<MudulProject.Models.Periodos> Periodos { get; set; }

        public DbSet<Secciones> Secciones { get; set; }

        public DbSet<Aula> Aulas { get; set; }

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

        public Dictionary<int, int> getPeriodos()
        {
            Dictionary<int, int> returnMap = new Dictionary<int, int>();
            foreach (Periodos periodo in Periodos.ToList())
            {
                returnMap.Add(periodo.Id, periodo.Periodo);
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
    }
}