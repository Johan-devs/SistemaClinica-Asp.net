using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Configuration;

namespace CapaDato
{
    public class Conexion
    {
        #region Patron Singleton
        private static Conexion conexion = null;
        SqlConnection connection;
        string dbName = ConfigurationManager.AppSettings["DBName"];
        string user = ConfigurationManager.AppSettings["UserDB"];
        string password = ConfigurationManager.AppSettings["Password"];

        private Conexion()
        {
            connection = new SqlConnection();
            connection.ConnectionString = $"Data Source=.; Initial Catalog={dbName}; User ID={user}; Password={password}";
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
