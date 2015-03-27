using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MudulProject.Models
{
    [Table("MetodosDePago")]
    public class MetodosDePago
    {
        private int id;
        private string description;

        public MetodosDePago()
        {
        }

        public MetodosDePago(int idmetod, string desc)
        {
            Id = idmetod;
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
                return this.description;
            }
            set
            {
                this.description = value;
            }
        }

        public int getTipoPagoById(int id)
        {
            return Id;
        }
    }
}