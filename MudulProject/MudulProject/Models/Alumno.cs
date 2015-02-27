using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MudulProject.Models
{
    public class Alumno
    {
        private int numberid;

        public Alumno(int id)
        {
            NumberAccountId = id;
        }

        public int NumberAccountId {
            get
            {
                return this.numberid;
            }
            set
            {
                this.numberid = value;
            }
        }

        public int GetAlumnoByNoCuenta(int id)
        {
            return NumberAccountId;
        }
    }
}