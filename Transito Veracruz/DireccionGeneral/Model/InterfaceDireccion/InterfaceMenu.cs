using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DireccionGeneral.Model.InterfaceDireccion
{
    public interface InterfaceMenu
    {
        void actualizar(int idPersonal, string numeroPersonal, string tipoPersonal, string apellidos, string nombre, string cargo, string usuario, string contrasena, string nombreDelegacion);
        void actualizar(int idDelegacion, int numeroDelegacion, string nombre, string colonia, string codigoPostal,string municipio, string telefono, string correo,string calle,string numeroDireccion );
        void actualizar(int idReporte, int numeroReporte, string estatus, string nombreDelegacion, int folio, string direccion, DateTime fechaCreacion);
    }
}
