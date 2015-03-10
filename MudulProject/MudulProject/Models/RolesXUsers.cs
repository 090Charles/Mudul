using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MudulProject.Models
{
    public class RolesXUsers
    {
        private int numid;
        private int idrol;

        public RolesXUsers()
        {
        }

        public RolesXUsers(int nai, int idr)
        {
            NumberAccountId_Usuarios = nai;
            Id_Roles = idr;
        }

        public int NumberAccountId_Usuarios
        {
            get
            {
                return this.numid;
            }
            set
            {
                this.numid = value;
            }
        }

        public int Id_Roles
        {
            get
            {
                return this.idrol;
            }
            set
            {
                this.idrol = value;
            }
        }
    }
}