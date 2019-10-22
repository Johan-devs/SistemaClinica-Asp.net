using CapaDato;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogicaNegocio
{
    public class EmpleadoLN
    {
        #region Patron Singleton
        private static EmpleadoLN objEmpleadoLN = null;
        private EmpleadoLN()
        {

        }
        public static EmpleadoLN getInstance()
        {
            if (objEmpleadoLN == null)
            {
                objEmpleadoLN = new EmpleadoLN();
            }
            return objEmpleadoLN;
        }

        #endregion

        public Empleado getAccess(string user, string password)
        {
            try
            {
                return EmpleadoDAO.getInstance().getAccess(user, password);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
