﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DireccionGeneral.Model.pocosDireccion
{
    public class Reporte
    {
        private Int32 idReporte;
        private String estatus;
        private String nombreDelegacion;
        private Int32 folioDictamen;
        private String direccion;
        private String fechaCreacion;

        public int IdReporte { get => idReporte; set => idReporte = value; }
        public string Estatus { get => estatus; set => estatus = value; }
        public string NombreDelegacion { get => nombreDelegacion; set => nombreDelegacion = value; }
        public int FolioDictamen { get => folioDictamen; set => folioDictamen = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string FechaCreacion { get => fechaCreacion; set => fechaCreacion = value; }
    }
}
