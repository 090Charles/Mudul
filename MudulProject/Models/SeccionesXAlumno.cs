using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MudulProject.Models
{
    public class SeccionesXAlumno
    {
        public int Id { get; set; }
        public int Idseccion { get; set; }
        public int Idalumno { get; set; }
        public int Idasignatura { get; set; }

        public SeccionesXAlumno()
        {
        }
        public SeccionesXAlumno(int newid, int ids, int idal, int idas)
        {
            Id = newid;
            Idseccion = ids;
            Idalumno = idal;
            Idasignatura = idas;
        }
    }
}