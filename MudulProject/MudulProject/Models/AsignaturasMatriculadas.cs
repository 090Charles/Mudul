using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MudulProject.Models
{
    public class Asignaturasmatriculadas
    {


        [Key]
        public int Id { get; set; }
        public int Id_Asignaturas { get; set; }
        public int Id_Matricula { get; set; }
        
    }
}
