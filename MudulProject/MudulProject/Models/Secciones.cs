using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MudulProject.Models
{
    public class Secciones
    {
        private string id;
        private string descripcion;
        private int cantidad;

        public Secciones(string idsec, string desc, int cant)
        {
            Id = idsec;
            Description = desc;
            Quantity = cant;
        }

        public string Id
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

        public int Quantity
        {
            get
            {
                return this.cantidad;
            }
            set
            {
                this.cantidad = value;
            }
        }

        public string getSeccionById(string idsec)
        {
            return Id;
        }
    }
}