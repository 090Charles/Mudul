using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MudulProject.Models
{
    public class Horarios
    {
        private int id;
        private DateTime hora = DateTime.Now;

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
        //[DisplayFormat(DataFormatString = "{0:t}")]
        public DateTime Hora {
            get
            {
                return this.hora;
            }
            set
            {
                this.hora = value;
                this.hora.AddYears(2015);
                this.hora.AddMonths(01);
                this.hora.AddDays(01);
            }
        }

        public String HoraFormateada
        {
            get { return String.Format("{0:t}", Hora); }
        }

        /*public int soloHora
        {
            get
            {
                return 0;
            }
            set
            {
                DateTime fechadefault = DateTime.Now;
                fechadefault.AddHours(value);
                Hora = fechadefault;
            }
        }*/
    }
}