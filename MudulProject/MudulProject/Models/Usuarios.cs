using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MudulProject.Models
{
    public class Usuarios
    {
        private int id;
        private string nombre;
        private string apellido;
        private string correo;
        private DateTime fechanacimiento;
        private string telefono;
        private string direccion;


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

        public string Nombre {
            get
            {
                return this.nombre;
            }
            set
            {
                this.nombre = value;
            }
        }

        public string Apellido { 
            get{
                return this.apellido;
            }
            set
            {
                this.apellido = value;
            }
        }

        public string Correo
        {
            get { return this.correo; }
            set { this.correo = value; }
        }

        public int Edad
        {
            get
            {
                DateTime start = new DateTime(1, 1, 1);
                DateTime birth = FechaNacimiento;
                DateTime now = DateTime.Today;

                TimeSpan span = now - birth;
                int years = (start + span).Year - 1;

                return years;
            }
        }

        public DateTime FechaNacimiento {
            get
            {
                return this.fechanacimiento;
            }
            set
            {
                this.fechanacimiento = value;
            }
        }

        public string Telefono {
            get
            {
                return this.telefono;
            }
            set
            {
                this.telefono = value;
            }
        }

        public string Direccion
        {
            get
            {
                return this.direccion;
            }
            set
            {
                this.direccion = value;
            }
        }

    }
}