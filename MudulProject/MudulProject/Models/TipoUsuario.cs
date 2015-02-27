using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MudulProject.Models
{
    public class TipoUsuario
    {
        private int id;
        private string descripcion;

        public TipoUsuario(int idtype, string descrp)
        {
            Id = idtype;
            Description = descrp;
        }

        public int Id {
            get
            {
                return this.id;
            }
            set
            {
                this.id = value;
            }
        }

        public string Description {
            get
            {
                return this.descripcion;
            }
            set
            {
                this.descripcion=value;
            }
        }

        public int GetTipoUsuario()
        {
            return Id;
        }
    }
}