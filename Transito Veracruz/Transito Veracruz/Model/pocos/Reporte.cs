using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transito_Veracruz.Model.pocos
{
    class Reporte
    {
        private Int32 idReporte;
        private Int32 numeroReporte;
        private String nombreDelegacion;
        private String estatus;
        private Int32 folioDictamen;
        private String direccion;

        public int IdReporte { get => idReporte; set => idReporte = value; }
        public Int32 NumeroReporte { get => numeroReporte; set => numeroReporte = value; }
        public string Estatus { get => estatus; set => estatus = value; }
        public Int32 FolioDictamen { get => folioDictamen; set => folioDictamen = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string NombreDelegacion { get => nombreDelegacion; set => nombreDelegacion = value; }
    }
}
