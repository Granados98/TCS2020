using System;
using System.Collections.Generic;
using System.Text;

namespace Servidor
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
