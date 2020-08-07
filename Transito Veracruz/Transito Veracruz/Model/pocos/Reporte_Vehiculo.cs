using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transito_Veracruz.Model.pocos
{
    public class Reporte_Vehiculo
    {
        private Int32 idReporte_Vehiculo;
        private Int32 idVehiculo;
        private Int32 idReporte;

        public int IdReporte_Vehiculo { get => idReporte_Vehiculo; set => idReporte_Vehiculo = value; }
        public int IdVehiculo { get => idVehiculo; set => idVehiculo = value; }
        public int IdReporte { get => idReporte; set => idReporte = value; }
    }
}
