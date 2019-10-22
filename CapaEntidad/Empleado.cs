using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Empleado
    {
        public int ID { get; set; }
        public TipoEmpleado RTipoEmpleado { get; set; }
        public string Nombre { get; set; }
        public string ApPaterno { get; set; }
        public string ApMaterno { get; set; }
        public string NroDocumento { get; set; }
        public bool Estado { get; set; }
        public string Imagen { get; set; }
        public string Usuario { get; set; }
        public string Clave { get; set; }
        public Empleado()
        {

        }
        public Empleado(int id, TipoEmpleado rtipoEmpleado, string nombre, string apPaterno, string apMaterno, string nroDocumento, bool estado, string imagen, string usuario, string clave)
        {
            ID = id;
            RTipoEmpleado = rtipoEmpleado;
            Nombre = nombre;
            ApPaterno = apPaterno;
            ApMaterno = apMaterno;
            NroDocumento = nroDocumento;
            Estado = estado;
            Imagen = imagen;
            Usuario = usuario;
            Clave = clave;
        }
    }
}
