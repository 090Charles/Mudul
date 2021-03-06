﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MudulProject.Models
{
    public class Matriculas
    {
        private int id;
        private DateTime fechamatricula;
        private char comentario;


        [Display(Name = "Usuarios")]
        private int numberAccountId_Usuarios;

        [Display(Name = "Tipo de Matricula")]
        private int id_TipoMatricula;

        [Display(Name = "Metodo de Pago")]
        private int id_MetodosDePago;

        [Display(Name = "Campus")]
        private int id_Campus;
        private decimal total;

        public Matriculas()
        {
        }

        public Matriculas(int newid, DateTime date, char comment, int idu,int idtm, int idmp,int idc, decimal tot)
        {
            Id = newid;
            FechaMatricula = date;
            Comentario = comment;
            NumberAccountId_Usuarios = idu;
            Id_TipoMatricula = idtm;
            Id_MetodosDePago = idmp;
            Id_Campus = idc;
            Total = tot;
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