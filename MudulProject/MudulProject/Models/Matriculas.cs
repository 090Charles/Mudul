using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MudulProject.Models
{
    public class Matriculas
    {




        private int id;
        private DateTime fechamatricula;
        private char comentario;
        private int numberAccountId_Usuarios;
        private int id_TipoMatricula;
        private int id_MetodosDePago;
        private int id_Campus;
        private Decimal total;




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



        public DateTime FechaMatricula
        {
            get
            {
                return this.fechamatricula;
            }
            set
            {
                this.fechamatricula = value;
            }
        }

        public char Comentario
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

        public int NumberAccountId_Usuarios
        {
            get
            {
                return this.numberAccountId_Usuarios;
            }
            set
            {
                this.numberAccountId_Usuarios = value;
            }
        }

        public int Id_TipoMatricula
        {
            get
            {
                return this.id_TipoMatricula;
            }
            set
            {
                this.id_TipoMatricula = value;
            }

        }
        public int Id_MetodosDePago
        {
            get
            {
                return this.id_MetodosDePago;
            }
            set
            {
                this.id_MetodosDePago = value;
            }
        }

        public int Id_Campus
        {
            get
            {
                return this.id_Campus;
            }
            set
            {
                this.id_Campus = value;
            }
        }

        public decimal Total
        {
            get
            {
                return this.total;
            }
            set
            {
                this.total = value;
            }
        }

    }
}