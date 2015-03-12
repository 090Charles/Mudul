using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MudulProject.Models
{
    public class AsignaturasXMaestro
    {
        private int id_asig;
        private int num_id;

        public AsignaturasXMaestro()
        {
        }

        public AsignaturasXMaestro(int id_asign, int numerid)
        {
            Id_Asignaturas = id_asign;
            NumberAccountId = numerid;
        }

        public int Id_Asignaturas
        {
            get
            {
                return this.id_asig;
            }
            set
            {
                this.id_asig = value;
            }
        }

        public int NumberAccountId
        {
            get
            {
                return this.num_id;
            }
            set
            {
                this.num_id = value;
            }
        }
    }
}