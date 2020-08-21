using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DireccionGeneral.Clases
{
    class Mensaje
    {
        public string contenidoMensaje { get; set; }
        public string usuarioEmisor { get; set; }
        public bool isMensaje { get; set; }
        public bool isReporte { get; set; }

        public Mensaje()
        {

        }

        public Mensaje(string contenidoMensaje, string usuarioEmisor, bool isMensaje, bool isReporte)
        {
            this.contenidoMensaje = contenidoMensaje;
            this.usuarioEmisor = usuarioEmisor;
            this.isMensaje = isMensaje;
            this.isReporte = isReporte;
        }
    }
}
