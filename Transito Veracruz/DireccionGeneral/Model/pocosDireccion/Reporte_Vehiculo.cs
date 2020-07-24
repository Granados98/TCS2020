using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DireccionGeneral.Model.pocosDireccion
{
    class Reporte_Vehiculo
    {
        private Int32 idReporte_Vehiculo;
        private Int32 idVehiculo;
        private Int32 numeroReporte;

        public int IdReporte_Vehiculo { get => idReporte_Vehiculo; set => idReporte_Vehiculo = value; }
        public int IdVehiculo { get => idVehiculo; set => idVehiculo = value; }
        public int NumeroReporte { get => numeroReporte; set => numeroReporte = value; }
    }
}
