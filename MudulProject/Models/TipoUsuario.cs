using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MudulProject.Models
{
    public class TipoUsuario
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }

        public TipoUsuario()
        {
        }

        public TipoUsuario(int idtyp, string desc)
        {
            Id = idtyp;
            Description = desc;
        }
    }
}