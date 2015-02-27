using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MudulProject.Models
{
    public class Aula
    {
        private int id;
        private string descripcion;
        private int piso;

        public Aula(int idaula, string desc, int floor)
        {
            Id = idaula;
            Description = desc;
            Florr = floor;
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

        public int Florr {
            get
            {
                return this.piso;
            }
            set
            {
                this.piso = value;
            }
        }

        public int getAula()
        {
            return Id;
        }
    }
}