using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace CapaDato
{
    public class Conexion
    {
        #region Patron Singleton
        private static Conexion conexion = null;
        SqlConnection connection;
       

        private Conexion()
        {
            connection = new SqlConnection();
            connection.ConnectionString = $"Data Source=.; Initial Catalog=ClinicaDB; User ID=sa; Password=123456";
        }
        public static Conexion getInstance()
        {
            if (conexion == null)
            {
                conexion = new Conexion();
            }
            return conexion;
        }
        #endregion

        public SqlConnection getConnection()
        {
            return connection;
        }
    }
}
