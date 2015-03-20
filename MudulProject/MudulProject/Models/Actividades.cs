using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MudulProject.Models
{
    public class Actividades
    {
        private int id;
        private int seccion;
        private DateTime horainicio;
        private DateTime horalimite;
        private string titulo;
        private string descripcion;
        private decimal ponderacion;

        public Actividades()
        {
        }

        public Actividades(int newid, int idsection, DateTime initialhour, DateTime limithour, string title, string description, decimal weighting)
        {
            Id = newid;
            Id_seccion = idsection;
            HoraInicio = initialhour;
            HoraLimite = limithour;
            Titulo = title;
            Description = description;
            Ponderacion = weighting;
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

        public int Id_seccion
        {
            get
            {
                return this.seccion;
            }
            set
            {
                this.seccion = value;
            }
        }

        public DateTime HoraInicio
        {
            get
            {
                return DateTime.Parse(this.horainicio.ToString("yyyy-MM-dd HH:mm"));
            }
            set
            {
                this.horainicio = value;
            }
        }

        public DateTime HoraLimite
        {
            get
            {
                return DateTime.Parse(this.horalimite.ToString("yyyy-MM-dd HH:mm"));
            }
            set
            {
                this.horalimite = value;
            }
        }

        public string Titulo
        {
            get
            {
                return this.titulo;
            }
            set
            {
                this.titulo = value;
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

        public decimal Ponderacion
        {
            get
            {
                return this.ponderacion;
            }
            set
            {
                this.ponderacion = value;
            }
        }
    }
}