using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDato
{
    public class EmpleadoDAO
    {
        #region Patron Singleton

        private static EmpleadoDAO empleadoDAO = null;
        private EmpleadoDAO()
        {

        }
        public static EmpleadoDAO getInstance()
        {
            if (empleadoDAO == null)
            {
                empleadoDAO = new EmpleadoDAO();
            }
            return empleadoDAO;
        }

        #endregion

        public Empleado getAccess(string user, string password)
        {
            SqlConnection connection = null;
            SqlCommand cmd = null;
            Empleado objEmpleado = null;
            SqlDataReader dataReader = null;
            try
            {
                connection = Conexion.getInstance().getConnection();
                connection.Open();
                cmd = new SqlCommand("spAccesoSistema", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmUser", user);
                cmd.Parameters.AddWithValue("@prmPass", password);
                dataReader = cmd.ExecuteReader();
                if (dataReader.Read())
                {
                    objEmpleado = new Empleado();
                    objEmpleado.ID = Convert.ToInt32(dataReader["idEmpleado"].ToString());
                    objEmpleado.Usuario = dataReader["usuario"].ToString();
                    objEmpleado.Clave = dataReader["clave"].ToString();
                    //objEmpleado.Nombre = dataReader["nombres"].ToString();
                    //objEmpleado.ApPaterno = dataReader["apPaterno"].ToString();
                    //objEmpleado.ApMaterno = dataReader["apMaterno"].ToString();
                    //objEmpleado.NroDocumento = dataReader["nroDocumento"].ToString();
                    //objEmpleado.Estado = true;
                }
            }
            catch (Exception)
            {

                objEmpleado = null;
                throw;
            }
            finally
            {
                connection.Close();
            }
            return objEmpleado;
        }

    }
}
