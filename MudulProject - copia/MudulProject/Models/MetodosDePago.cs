using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MudulProject.Models
{
    public class MetodosDePago
    {
        private int id;
        private string descripcion;

        public MetodosDePago()
        {
        }

        public MetodosDePago(int idmetod, string desc)
        {
            Id = idmetod;
            Descripcion = desc;
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

        public string Descripcion
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

        public int getTipoPagoById(int id)
        {
            return Id;
        }
    }
}