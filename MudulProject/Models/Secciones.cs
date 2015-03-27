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
        private int id_horarios;
        private int? idmaestro;

        public Secciones()
        {

        }

        public Secciones(int newid,int idau,int idasig,int idp,int idh, int? idum)
        {
            Id = newid;
            Id_Aulas = idau;
            Id_Asignaturas = idasig;
            Id_Periodo = idp;
            Id_Horarios = idh;
            idusuariomaestro = idum;
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
        public int Id_Horarios
        {
            get
            {
                return this.id_horarios;
            }
            set
            {
                this.id_horarios = value;
            }
        }

        public int? idusuariomaestro
        {
            get
            {
                if (this.idmaestro == null)
                    return null;
                else
                    return this.idmaestro;
            }
            set
            {
                if (value == null)
                    this.idmaestro = null;
                else
                    this.idmaestro = value.Value;
            }
        }

        public int getSeccionById(string idsec)
        {
            return Id;
        }

    }
}