using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MudulProject.Models
{
    public class Usuarios
    {
        private string nombre;
        private string apellido;
        private int edad;
        private DateTime fechanacimiento;
        private string telefono;
        private string direccion;

        public Usuarios(string name, string surname, int age, DateTime birthdate, string phone, string dir)
        {
            Nombre = name;
            Apellido = surname;
            Edad = age;
            FechaNacimiento = birthdate;
            Telefono = phone;
            Direccion = dir;
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

        public int Edad
        {
            get
            {
                return this.edad;
            }
            set
            {
                this.edad = value;
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