using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MudulProject.Models
{
    public class Roles
    {
        private int id;
        private string descripcion;

        public Roles()
        {
        }

        public Roles(int idrol, string desc)
        {
            Id = idrol;
            Description = desc;
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
                this.descripcion = value;
            }
        }

        public int GetRoles()
        {
            return Id;
        }
    }
}