using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DireccionGeneral.Model.pocosDireccion
{
    public class Reporte
    {
        private Int32 idReporte;
        private Int32 numeroReporte;
        private String estatus;
        private String nombreDelegacion;
        private Int32 folioDictamen;
        private String direccion;
        private DateTime fechaCreacion;

        public int IdReporte { get => idReporte; set => idReporte = value; }
        public int NumeroReporte { get => numeroReporte; set => numeroReporte = value; }
        public string Estatus { get => estatus; set => estatus = value; }
        public string NombreDelegacion { get => nombreDelegacion; set => nombreDelegacion = value; }
        public int FolioDictamen { get => folioDictamen; set => folioDictamen = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public DateTime FechaCreacion { get => fechaCreacion; set => fechaCreacion = value; }
    }
}
