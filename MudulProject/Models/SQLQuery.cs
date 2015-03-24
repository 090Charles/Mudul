using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace BibliotecaApp
{
    public class SQLQuery
    {
        //establece una conexion para hacer una consulta y devuelve una tabla llena con el resultado de la consulta
        public DataTable getTable(string Sql)
        {
           //string connectionString = @"Data Source=ac970e83-6c66-4005-aa62-a4450024e8ae.sqlserver.sequelizer.com;Initial Catalog=dbac970e836c664005aa62a4450024e8ae;Persist Security Info=True;User ID=yhntegtlbtlwbuez";
            string connectionString = @"Data Source=ac970e83-6c66-4005-aa62-a4450024e8ae.sqlserver.sequelizer.com;Initial Catalog=dbac970e836c664005aa62a4450024e8ae;Persist Security Info=True;User ID=yhntegtlbtlwbuez;Password=MNGvonjT5dVR55SSVKNV4cgJxfNtrSaPpGVENBnShVZfAcEgcQhziwbJG77hGYAk;Network Library=dbmssocn";
            SqlConnection conexionSQL = new SqlConnection(connectionString);
            SqlCommand sqlCommand = null;
            SqlDataReader sqlDataReader = null;
            try
            {
                conexionSQL.Open();
                sqlCommand = new SqlCommand(Sql, conexionSQL);
                sqlDataReader = sqlCommand.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(sqlDataReader);
                return dt;
            }
            catch (Exception err)
            {
                //MessageBox.Show(err.Message);
            }
            finally
            {
                if (sqlDataReader != null)
                    sqlDataReader.Close();
                if (conexionSQL.State == ConnectionState.Open)
                    conexionSQL.Close();
            }
            return null;
        }

        //establece una conexion para hacer un query y devuelve la cantidad de filas afectadas
        public int execute(string Sql)
        {
            //string connectionString = @"Data Source=ac970e83-6c66-4005-aa62-a4450024e8ae.sqlserver.sequelizer.com;Initial Catalog=dbac970e836c664005aa62a4450024e8ae;Persist Security Info=True;User ID=yhntegtlbtlwbuez";
            string connectionString = @"Data Source=ac970e83-6c66-4005-aa62-a4450024e8ae.sqlserver.sequelizer.com;Initial Catalog=dbac970e836c664005aa62a4450024e8ae;Persist Security Info=True;User ID=yhntegtlbtlwbuez;Password=MNGvonjT5dVR55SSVKNV4cgJxfNtrSaPpGVENBnShVZfAcEgcQhziwbJG77hGYAk;Network Library=dbmssocn";
            SqlConnection conexionSQL = new SqlConnection(connectionString);
            SqlCommand sqlCommand = null;
            try
            {
                conexionSQL.Open();
                sqlCommand = new SqlCommand(Sql, conexionSQL);
                return sqlCommand.ExecuteNonQuery(); // devuelve el numero de filas afectadas
            }
            catch (Exception err)
            {
                //MessageBox.Show(err.Message);
            }
            finally
            {
                if (conexionSQL.State == ConnectionState.Open)
                    conexionSQL.Close();
            }
            return 0; //devuelve 0 si no se hizo nada
        }
    }
}
