using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MudulProject.Models
{
    public class TipoMatricula
    {
        private int id;
        private string desc;

        public TipoMatricula()
        {
        }

        public TipoMatricula(int idt, string descripcion)
        {
            Id = idt;
            Description = descripcion;
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
                return this.desc;
            }
            set
            {
                this.desc = value;
            }
        }
    }
}