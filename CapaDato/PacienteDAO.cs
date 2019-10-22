using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace CapaDato
{
    public class PacienteDAO
    {
        #region Patron Singleton
        private static PacienteDAO objPacienteDAO = null;
        private PacienteDAO()
        {

        }
        public static PacienteDAO getInstance()
        {
            if (objPacienteDAO == null)
            {
                objPacienteDAO = new PacienteDAO();
            }
            return objPacienteDAO;
        }
        #endregion

        public bool RegistrarPaciente(Paciente objPaciente)
        {
            SqlConnection con = null;
            SqlCommand cmd = null;
            bool excuted = false;
            try
            {
                con = Conexion.getInstance().getConnection();
                cmd = new SqlCommand("spRegistrarPaciente", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmNombres", objPaciente.Nombres);
                cmd.Parameters.AddWithValue("@prmApPaterno", objPaciente.ApPaterno);
                cmd.Parameters.AddWithValue("@prmApMaterno", objPaciente.ApMaterno);
                cmd.Parameters.AddWithValue("@prmEdad", objPaciente.Edad);
                cmd.Parameters.AddWithValue("@prmSexo", objPaciente.Sexo);
                cmd.Parameters.AddWithValue("@prmNroDocumento", objPaciente.NroDocumento);
                cmd.Parameters.AddWithValue("@prmDireccion", objPaciente.Direccion);
                cmd.Parameters.AddWithValue("@prmTelefono", objPaciente.Telefono);
                cmd.Parameters.AddWithValue("@prmEstado", objPaciente.Estado);
                con.Open();
                int filas = cmd.ExecuteNonQuery();
                if (filas > 0) excuted = true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                con.Close();
            }
            return excuted;
        }

        public Paciente ObtenerPaciente(int id)
        {
            var con = Conexion.getInstance().getConnection();
            try
            {
                
                var cmd = new SqlCommand($"Select idPaciente,nombres,apPaterno,apMaterno,direccion from dbo.Paciente Where idPaciente = {id}", con);
                cmd.CommandType = CommandType.Text;
                con.Open();
                var reader = cmd.ExecuteReader();
                return new Paciente
                {
                    IdPaciente = Convert.ToInt32(reader["idPaciente"].ToString()),
                    Nombres = reader["nombres"].ToString(),
                    ApPaterno = reader["apPaterno"].ToString(),
                    ApMaterno = reader["apMaterno"].ToString(),
                    Direccion = reader["direccion"].ToString()
                };
            }
            catch (Exception ex)
            {

                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public List<Paciente> ListaPacientes()
        {
            List<Paciente> Lista = new List<Paciente>();
            SqlConnection con = null;
            SqlCommand cmd = null;
            SqlDataReader reader = null;
            try
            {
                con = Conexion.getInstance().getConnection();
                con.Open();
                cmd = new SqlCommand("spListarPacientes", con);
                cmd.CommandType = CommandType.StoredProcedure;
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Paciente objPaciente = new Paciente();
                    objPaciente.IdPaciente = Convert.ToInt32(reader["idPaciente"].ToString());
                    objPaciente.Nombres = reader["nombres"].ToString();
                    objPaciente.ApPaterno = reader["apPaterno"].ToString();
                    objPaciente.ApMaterno = reader["apMaterno"].ToString();
                    objPaciente.Edad = Convert.ToInt32(reader["edad"].ToString());
                    objPaciente.Sexo = Convert.ToChar(reader["sexo"].ToString());
                    objPaciente.NroDocumento = reader["nroDocumento"].ToString();
                    objPaciente.Direccion = reader["direccion"].ToString();
                    objPaciente.Estado = true;
                    //Añadiendo a la lista
                    Lista.Add(objPaciente);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                con.Close();
            }
            return Lista;
        }

    }
}
