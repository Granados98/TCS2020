using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DireccionGeneral.Model.InterfaceDireccion
{
    public interface InterfaceMenu
    {
        void actualizar(int idPersonal, string tipoPersonal, string apellidos, string nombre, string cargo, string usuario, string contrasena, string nombreDelegacion);
        void actualizar(int idDelegacion, string nombre, string colonia, string codigoPostal,string municipio, string telefono, string correo,string calle,string numeroDireccion );
        void actualizar(int idReporte, string estatus, string nombreDelegacion, int idDictamen, string direccion, DateTime fechaCreacion);
    }
}
