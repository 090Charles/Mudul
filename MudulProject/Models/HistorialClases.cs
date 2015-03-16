using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MudulProject.Models;
using System.Data;
using BibliotecaApp;
//using BibliotecaApp;

namespace MudulProject.Models
{
    public class HistorialClases
    {
        public DataTable tabla { get; set; }
        public DataTable Retornar_Tabla(int IdAlum)
        {
            
            var sqlQuery = new SQLQuery();
            string queryString = @" SELECT L.id,L.Description,L.Id_Carrera
                                    FROM Matriculas M JOIN AsignaturasMatriculadas A 
                                    ON M.Id=A.Id_Matricula JOIN Asignaturas L 
                                    ON A.Id_Asignaturas=L.Id
                                    WHERE M.NumberAccountId_Usuarios=3";

            DataTable lista = sqlQuery.getTable(queryString);
            return lista;
        }
    }
}