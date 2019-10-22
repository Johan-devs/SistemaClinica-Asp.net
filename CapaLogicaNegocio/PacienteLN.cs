using CapaDato;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogicaNegocio
{
    public class PacienteLN
    {
        #region Patron Singleton
        private static PacienteLN objPacienteLN = null;
        private PacienteLN()
        {

        }
        public static PacienteLN getInstance()
        {
            if (objPacienteLN == null)
            {
                objPacienteLN = new PacienteLN();
            }
            return objPacienteLN;
        }
        #endregion

        public bool RegistrarPaciente(Paciente objPacientes)
        {
            try
            {
                return PacienteDAO.getInstance().RegistrarPaciente(objPacientes);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }
        public List<Paciente> ListarPacientes()
        {
            try
            {
                return PacienteDAO.getInstance().ListaPacientes();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public Paciente ObtenerPaciente(int id)
        {
            try
            {
               return PacienteDAO.getInstance().ObtenerPaciente(id);
            }
            catch (Exception ex) 
            {

                throw ex;
            }
        }
    }
}
