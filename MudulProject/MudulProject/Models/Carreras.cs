using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MudulProject.Models
{
    public class Carreras
    {
        private int id;
        private string descripcion;

        public Carreras(int idcarr, string desc)
        {
            Id = idcarr;
            Description = desc;
        }

        public int Id
        {
            get
            {
                return this.id;
            }
            set
            {
                this.id = value;
            }
        }

        public string Description
        {
            get
            {
                return this.descripcion;
            }
            set
            {
                this.descripcion = value;
            }
        }

        public int GetCarrera()
        {
            return Id;
        }
    }
}