using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MudulProject.Models {
    public class Usuarios {

        [Key]
        public int NumberAccountId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Correo { get; set; }
        public string Password { get; set; }

        [DataType(DataType.Date)]
        [Display(Name="Fecha de Nacimiento")]
        public DateTime FechaNacimiento { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        [Display(Name="Tipo de Usuario")]
        public int Id_TipoUsuario { get; set; }

        public int Edad {
            get {
                DateTime start = new DateTime(1, 1, 1);
                DateTime birth = FechaNacimiento;
                DateTime now = DateTime.Today;

                if (now < birth)
                {
                    DateTime swap = now;
                    now = birth;
                    birth = swap;
                }

                TimeSpan span = now - birth;
                int years = (start + span).Year - 1;

                return years;
            }
        }

        public Usuarios()
        {
        }

        public Usuarios(int idu, string name, string surname, DateTime bday, string phone, string dir, int idtu, string email, string pass)
        {
            NumberAccountId = idu;
            Nombre = name;
            Apellido = surname;
            FechaNacimiento = bday;
            Telefono = phone;
            Direccion = dir;
            Id_TipoUsuario = idtu;
            Correo = email;
            Password = pass;
        }
    }
}