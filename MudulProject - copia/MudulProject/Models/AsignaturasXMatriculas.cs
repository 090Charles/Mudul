using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MudulProject.Models
{
    public class AsignaturasXMatriculas
    {
        private int idasig;
        private int idmat;

        public AsignaturasXMatriculas()
        {
        }

        public AsignaturasXMatriculas(int ida, int idm)
        {
            Id_Asignaturas = ida;
            Id_Matricula = idm;
        }

        public int Id_Asignaturas
        {
            get
            {
                return this.idasig;
            }
            set
            {
                this.idasig = value;
            }
        }

        public int Id_Matricula
        {
            get
            {
                return this.idmat;
            }
            set
            {
                this.idmat = value;
            }
        }
    }
}