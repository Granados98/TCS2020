using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transito_Veracruz.Model.interfaz
{
    public interface InterfaceMenu
    {
        void actualizar(int numeroReporte, string estatus, string nombreDelegacion, string direccion);
    }
}
