using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MudulProject.Models
{
    public class ActividadXAlumno
    {
        private int id;
        private int idactividad;
        private int idalumno;
        private DateTime horasubida;
        private DateTime horacalificacion;
        private decimal nota;
        private string archivo;
        private string comentario;

        public ActividadXAlumno()
        {
        }

        public ActividadXAlumno(int newid, int idactivity, int idstudent, DateTime uploadtime, DateTime calificationtime, decimal note, string file, string commentary)
        {
            Id = newid;
            Id_actividad = idactivity;
            Id_alumno = idstudent;
            HoraSubida = uploadtime;
            HoraCalificacion = calificationtime;
            Nota = note;
            Archivo = file;
            Comentario = commentary;
        }

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

        public int Id_actividad
        {
            get
            {
                return this.idactividad;
            }
            set
            {
                this.idactividad = value;
            }
        }

        public int Id_alumno
        {
            get
            {
                return this.idalumno;
            }
            set
            {
                this.idalumno = value;
            }
        }

        public DateTime HoraSubida
        {
            get
            {
                return this.horasubida;
            }
            set
            {
                this.horasubida = value;
            }
        }

        public DateTime HoraCalificacion
        {
            get
            {
                return this.horacalificacion;
            }
            set
            {
                this.horacalificacion = value;
            }
        }

        public decimal Nota
        {
            get
            {
                return this.nota;
            }
            set
            {
                this.nota = value;
            }
        }

        public string Archivo
        {
            get
            {
                return this.archivo;
            }
            set
            {
                this.archivo = value;
            }
        }

        public string Comentario
        {
            get
            {
                return this.comentario;
            }
            set
            {
                this.comentario = value;
            }
        }

        public string HoraFormateada(DateTime hora)
        {
            return string.Format("{0}-{1}-{2} {3}:{4}",hora.Year,hora.Month,hora.Day,hora.Hour,hora.Second);
        }

        public string HoraSubidaFormateada
        {
            get
            {
                return string.Format("{0}-{1}-{2} {3}:{4}0", HoraSubida.Year, HoraSubida.Month, HoraSubida.Day, HoraSubida.Hour, HoraSubida.Second);
            }
        }
        
        public string HoraCalificacionFormateada
        {
            get
            {
                return string.Format("{0}-{1}-{2} {3}:{4}0", HoraCalificacion.Year, HoraCalificacion.Month, HoraCalificacion.Day, HoraCalificacion.Hour, HoraCalificacion.Second);
            }
        }
    }
}