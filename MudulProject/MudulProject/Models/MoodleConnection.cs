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
    }
}