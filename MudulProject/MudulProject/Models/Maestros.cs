using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MudulProject.Models
{
    public class Maestros
    {
        private int idmaestro;
        private int tipo;

        public Maestros(int id, int type)
        {
            IdMaestro = id;
            Tipo = type;
        }

        public int IdMaestro {
            get
            {
                return this.idmaestro;
            }
            set
            {
                this.idmaestro = value;
            }
        }

        public int Tipo{
            get
            {
                return this.tipo;
            }
            set
            {
                this.tipo = value;
            }
        }

        public int Getinf(int id)
        {
            return IdMaestro;
        }
    }
}