﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transito_Veracruz.Model.pocos
{
    class Imagen
    {
        private Int32 idImagen;
        private byte[] dato;
        private Int32 numeroReporte;

        public int IdImagen { get => idImagen; set => idImagen = value; }
        public byte[] Dato { get => dato; set => dato = value; }
        public int NumeroReporte { get => numeroReporte; set => numeroReporte = value; }
    }
}