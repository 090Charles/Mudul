using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MudulProject.Models
{
    public class Campus
    {
        private int id;
        private string description;
        private string lugar;

        public Campus(int idcamp, string descrip, string place)
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

        public string Description {
            get
            {
                return this.description;
            }
            set
            {
                this.description = value;
            }
        }

        public string Lugar {
            get
            {
                return this.lugar;
            }
            set
            {
                this.lugar = value;
            }
        }
    }
}