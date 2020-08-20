using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transito_Veracruz.Model.pocos
{
    class Imagen
    {
        private Int32 idImagen;
        private String ruta;
        private byte[] dato;
        private Int32 idReporte;

        public int IdImagen { get => idImagen; set => idImagen = value; }
        public byte[] Dato { get => dato; set => dato = value; }
        public int IdReporte { get => idReporte; set => idReporte = value; }
        public string Ruta { get => ruta; set => ruta = value; }
    }
}
