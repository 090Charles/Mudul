using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MudulProject.Models
{
    public class Secciones
    {
        private int id;
        private int id_aulas;
        private int id_asignaturas;
        private int id_periodo;

        public Secciones()
        {

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
        public int Id_Aulas
        {
            get
            {
                return this.id_aulas;
            }
            set
            {
                this.id_aulas = value;
            }
        }

        public int Id_Asignaturas
        {
            get
            {
                return this.id_asignaturas;
            }
            set
            {
                this.id_asignaturas = value;
            }
        }

        public int Id_Periodo
        {
            get
            {
                return this.id_periodo;
            }
            set
            {
                this.id_periodo = value;
            }
        }
       

        public int getSeccionById(string idsec)
        {
            return Id;
        }
    }
}