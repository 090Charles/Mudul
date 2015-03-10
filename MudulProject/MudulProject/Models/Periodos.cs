using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MudulProject.Models
{
    public class Periodos
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Año")]
        public int Anio { get; set; }
        
        public int Periodo { get; set; }

        public String FullPeriodoAnio
        {
            get { return Periodo + " - " + Anio; }
        }

        public Periodos()
        {
        }

        public Periodos(int newid, int year, int per)
        {
            Id = newid;
            Anio = year;
            Periodo = per;
        }
    }
}