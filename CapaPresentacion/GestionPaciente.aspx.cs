using CapaEntidad;
using CapaLogicaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;

namespace CapaPresentacion
{
    public partial class GestionPaciente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) 
            {
           
            }
        }
       
        private Paciente GetValues()
        {
            Paciente objPaciente = new Paciente();
            objPaciente.IdPaciente = 0;
            objPaciente.Nombres = txtNombre.Text;
            objPaciente.ApPaterno = txtApPaterno.Text;
            objPaciente.ApMaterno = txtApMaterno.Text;
            objPaciente.Edad = Convert.ToInt32(txtEdad.Text);
            objPaciente.Sexo = (ddlSexo.SelectedValue=="Femenino")?'F':'M';
            objPaciente.NroDocumento = txtNroDocumento.Text;
            objPaciente.Direccion = txtDireccion.Text;
            objPaciente.Telefono = txtTelefono.Text;
            objPaciente.Estado = true;
            return objPaciente;
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            Paciente objPaciente = GetValues();
            bool response = PacienteLN.getInstance().RegistrarPaciente(objPaciente);
            if (response == true)
            {
                Response.Write("<script>alert('REGISTRO CORRECTO')</script>");
                
            }
            else
            {
                Response.Write("<script>alert('ERROR AL REGISTRAR')</script>");
                Response.Write("<script>alert('POR FAVOR VERIFIQUE')</script>");
            }
        }

        [WebMethod]
        public static List<Paciente> ListarPaciente()
        {
            List<Paciente> Lista = null;
            try
            {
                Lista = PacienteLN.getInstance().ListarPacientes();
            }
            catch (Exception ex)
            {
                Lista = null;
               
            }
            return Lista;
        }
        [WebMethod]
        public static Paciente ObtenerPaciente(int ? id)
        {            
            try
            {
                
                if (id == null || id == 0)
                {
                    return null;
                }
                Paciente paciente = PacienteLN.getInstance().ObtenerPaciente(id.Value);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return null;
        }
    }
}