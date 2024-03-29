﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transito_Veracruz.Model.pocos
{
    public class Vehiculo
    {
        private Int32 idVehiculo;
        private String numeroPlacas="";
        private String marca="";
        private String modelo="";
        private String anio="";
        private String color="";
        private String nombreAseguradora="";
        private String numeroPolizaSeguro="";
        private Int32 idConductor;
        private DateTime fechaCreacion;

        public int IdVehiculo { get => idVehiculo; set => idVehiculo = value; }
        public string NumeroPlacas { get => numeroPlacas; set => numeroPlacas = value; }
        public string Marca { get => marca; set => marca = value; }
        public string Modelo { get => modelo; set => modelo = value; }
        public string Anio { get => anio; set => anio = value; }
        public string Color { get => color; set => color = value; }
        public string NombreAseguradora { get => nombreAseguradora; set => nombreAseguradora = value; }
        public string NumeroPolizaSeguro { get => numeroPolizaSeguro; set => numeroPolizaSeguro = value; }
        public int IdConductor { get => idConductor; set => idConductor = value; }
        public DateTime FechaCreacion { get => fechaCreacion; set => fechaCreacion = value; }
    }
}
