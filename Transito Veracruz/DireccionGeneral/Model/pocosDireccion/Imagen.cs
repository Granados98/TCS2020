using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DireccionGeneral.Model.pocosDireccion
{
    class Imagen
    {
        private Int32 idImagen;
        private String ruta;
        private byte[] datos;
        private Int32 idReporte;

        public int IdImagen { get => idImagen; set => idImagen = value; }
        public string Ruta { get => ruta; set => ruta = value; }
        public byte[] Datos { get => datos; set => datos = value; }
        public int IdReporte { get => idReporte; set => idReporte = value; }
    }
}
