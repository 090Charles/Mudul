using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MudulProject.Models
{
    public class Horarios
    {
        private int id;
        private DateTime hora;

        public Horarios()
        {
        }

        public Horarios(int idhora, DateTime hour)
        {
            Id = idhora;
            Hora = hour;
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

        public DateTime Hora {
            get
            {
                return this.hora;
            }
            set
            {
                this.hora = value;
            }
        }

        public String HoraFormateada
        {
            get { return this.hora.ToString("hh:mm tt"); }
        }
    }
}