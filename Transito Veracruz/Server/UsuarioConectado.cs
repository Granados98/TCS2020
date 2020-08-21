using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class UsuarioConectado
    {
        public List<string> usuarioConectado = new List<string>();
        public bool isReporte { get; set; }
        public bool isMensaje { get; set; }

        public UsuarioConectado()
        {

        }
        public UsuarioConectado(List<string> usuarioConectado)
        {
            this.usuarioConectado = usuarioConectado;
        }
    }
}
