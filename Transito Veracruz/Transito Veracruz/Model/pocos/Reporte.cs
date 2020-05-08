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
        private String numeroReporte;
        private String lugarPercance;
        private String imagen;
        private String estatus;
        private String folioDictamen;

        public int IdReporte { get => idReporte; set => idReporte = value; }
        public string NumeroReporte { get => numeroReporte; set => numeroReporte = value; }
        public string LugarPercance { get => lugarPercance; set => lugarPercance = value; }
        public string Imagen { get => imagen; set => imagen = value; }
        public string Estatus { get => estatus; set => estatus = value; }
        public string FolioDictamen { get => folioDictamen; set => folioDictamen = value; }
    }
}
