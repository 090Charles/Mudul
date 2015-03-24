using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MudulProject.Models
{
    [Table("AsignaturasXMaestro")]
    public class AsignaturasXMaestro
    {
        private int id;
        private int id_asig;
        private int num_id;

        public AsignaturasXMaestro()
        {
        }

        public AsignaturasXMaestro(int idaxm, int id_asign, int numerid)
        {
            Id = idaxm;
            Id_Asignaturas = id_asign;
            NumberAccountId = numerid;
        }
        
        [Key]
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