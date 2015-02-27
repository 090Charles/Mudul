using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MudulProject.Models
{
    public class Matricula
    {
        private int id;
        private DateTime fechamatricula;
        private string comentario;

        public Matricula(int idmat,DateTime date,string comment)
        {
            Id = idmat;
            FechaMatricula = date;
            Comentario = comment;
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

        public DateTime FechaMatricula { 
            get { 
                return this.fechamatricula; 
            } 
            set { 
                this.fechamatricula=value;
            } 
        }

        public string Comentario {
            get
            {
                return this.comentario;
            }
            set
            {
                this.comentario = value;
            }
        }

        public void GenerarMatricula()
        {
            this.ToString();
        }

        public void ModificarMatricula(int editid)
        {
            Id = editid;
        }

        public void CancelarMatricula(int cancelid)
        {
            Comentario = "cancelado";
        }
    }
}