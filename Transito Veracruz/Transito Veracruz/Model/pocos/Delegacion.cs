using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transito_Veracruz.Model.pocos
{
    class Delegacion
    {
        private Int32 idDelegacion;
        private String nombre;
        private String calle;
        private String numero;
        private String colonia;
        private String codigoPostal;
        private String municipio;
        private String telefono;
        private String correo;

        public int IdDelegacion { get => idDelegacion; set => idDelegacion = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Calle { get => calle; set => calle = value; }
        public string Numero { get => numero; set => numero = value; }
        public string Colonia { get => colonia; set => colonia = value; }
        public string CodigoPostal { get => codigoPostal; set => codigoPostal = value; }
        public string Municipio { get => municipio; set => municipio = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Correo { get => correo; set => correo = value; }
    }
}
