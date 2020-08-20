using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transito_Veracruz.Model.interfaz
{
    public interface InterfaceMenu
    {
        void actualizar(int idReporte, string estatus, string nombreDelegacion, string direccion, int dictamen);
        void actualizar(string numeroLicencia, string apellidos, string nombre, string fechaNacimiento, string telefono);
        void actualizar(string numeroPLacas, string marca, string modelo, string anio, string color, string nombreAseguradora, string numeroPoliza);
    }
}
