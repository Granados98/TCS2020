using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transito_Veracruz.Model.interfaz
{
    public interface InterfaceMenu
    {
        void actualizar(int idReporte,int numeroReporte, string estatus, string nombreDelegacion, string direccion);
        void actualizar(int idConductor, string numeroLicencia, string apellidos, string nombre, DateTime fechaNacimiento, string telefono);
        void actualizar(int idVehiculo, string numeroPLacas, string marca, string modelo, string anio, string color, string nombreAseguradora, string numeroPoliza);
    }
}
