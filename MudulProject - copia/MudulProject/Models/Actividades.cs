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
        private double ponderacion;

        public Actividades()
        {
        }

        public Actividades(int newid, int idsection, DateTime initialhour, DateTime limithour, string title, string description, double weighting)
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
                return this.horainicio;
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
                return this.horalimite;
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

        public double Ponderacion
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