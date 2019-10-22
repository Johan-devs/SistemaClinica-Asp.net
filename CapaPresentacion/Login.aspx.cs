using CapaEntidad;
using CapaLogicaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace CapaPresentacion
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            var Empleado = EmpleadoLN.getInstance().getAccess(txtUsuario.Text,txtPassword.Text);
            if (Empleado != null)
            {
                Response.Write("<script>alert('Usuario Correcto') </script>");
                Response.Redirect("PanelGeneral.aspx");
            }
            else
            {
                Response.Write("<script>alert('Usuario Incorrecto') </script>");
            }
        }
      
    }
}