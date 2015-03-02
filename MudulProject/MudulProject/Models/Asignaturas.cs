using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MudulProject.Models
{
    public class Asignaturas
    {
        private int id;
        private string descripcion;
        private int id_carrera;

        public Asignaturas()
        {

        }

        public Asignaturas(int idasig, string desc)
        {
            Id = idasig;
            Description = desc;
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

        public string Description {
            get
            {
                return this.descripcion;
            }
            set
            {
                this.descripcion = value;
            }
        }

        public int Id_Carrera
        {
            get
            {
                return this.id_carrera;
            }
            set
            {
                this.id_carrera = value;
            }
        }

        public string getSeccionByAsignaturaId(int idasig)
        {
            return Description;
        }
    }

}