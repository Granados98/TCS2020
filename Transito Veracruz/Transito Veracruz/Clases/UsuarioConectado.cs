using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transito_Veracruz.Clases
{
    class UsuarioConectado
    {
        public List<string> usuarioConectado = new List<string>();
        public bool isReporte { get; set; }
        public bool isMensaje { get; set; }

        public UsuarioConectado(List<string> usuarioConectado)
        {
            this.usuarioConectado = usuarioConectado;
        }


        public UsuarioConectado()
        {

        }
    }
}
