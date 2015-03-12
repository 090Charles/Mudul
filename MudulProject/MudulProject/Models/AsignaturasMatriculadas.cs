using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MudulProject.Models
{
    class AsignaturasMatriculadas
    {

        private int id;
        private int idasig;
        private int idmat;


        public AsignaturasMatriculadas(int id, int idasig, int idmat)
        {
            Id = id;
            Id_Asignaturas = idasig;
            Id_Matricula = idmat;

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
