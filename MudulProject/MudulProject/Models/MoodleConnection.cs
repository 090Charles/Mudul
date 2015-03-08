using System;
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
    }
}