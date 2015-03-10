using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MudulProject.Models
{
    public class HorariosXAsignaturas
    {
        private int idhor;
        private int idasig;

        public HorariosXAsignaturas()
        {
        }

        public HorariosXAsignaturas(int idh, int ida)
        {
            Id_Horarios = idh;
            Id_Asignaturas = ida;
        }

        public int Id_Horarios
        {
            get
            {
                return this.idhor;
            }
            set
            {
                this.idhor = value;
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
    }
}