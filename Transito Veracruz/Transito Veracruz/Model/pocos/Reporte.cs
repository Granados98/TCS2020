using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transito_Veracruz.Model.pocos
{
    public class Reporte
    {
        private Int32 idReporte;
        private String nombreDelegacion;
        private String estatus;
        private String direccion;
        private String fechaCreacion;
        private Int32 idDictamen;

        public int IdReporte { get => idReporte; set => idReporte = value; }
        public string Estatus { get => estatus; set => estatus = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string NombreDelegacion { get => nombreDelegacion; set => nombreDelegacion = value; }
        public string FechaCreacion { get => fechaCreacion; set => fechaCreacion = value; }
        public int IdDictamen { get => idDictamen; set => idDictamen = value; }
    }
}
