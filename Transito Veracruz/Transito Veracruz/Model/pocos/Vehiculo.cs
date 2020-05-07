using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transito_Veracruz.Model.pocos
{
    class Vehiculo
    {
        private Int32 idVehiculo;
        private String numeroPLacas;
        private String marca;
        private String modelo;
        private String anio;
        private String color;
        private String nombreAseguradora;
        private String numeroPolizaSeguro;
        private String numeroLicencia;

        public int IdVehiculo { get => idVehiculo; set => idVehiculo = value; }
        public string NumeroPLacas { get => numeroPLacas; set => numeroPLacas = value; }
        public string Marca { get => marca; set => marca = value; }
        public string Modelo { get => modelo; set => modelo = value; }
        public string Anio { get => anio; set => anio = value; }
        public string Color { get => color; set => color = value; }
        public string NombreAseguradora { get => nombreAseguradora; set => nombreAseguradora = value; }
        public string NumeroPolizaSeguro { get => numeroPolizaSeguro; set => numeroPolizaSeguro = value; }
        public string NumeroLicencia { get => numeroLicencia; set => numeroLicencia = value; }
    }
}
