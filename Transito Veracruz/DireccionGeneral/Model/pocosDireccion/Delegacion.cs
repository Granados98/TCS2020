using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DireccionGeneral.Model.pocosDireccion
{
    class Delegacion
    {
        private Int32 idDelegacion;
        private Int32 numeroDelegacion;
        private String nombre;
        private String colonia;
        private String codigoPostal;
        private String municipio;
        private String telefono;
        private String correoElectronico;
        private String calle;
        private String numeroDireccion;

        public int IdDelegacion { get => idDelegacion; set => idDelegacion = value; }
        public int NumeroDelegacion { get => numeroDelegacion; set => numeroDelegacion = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Colonia { get => colonia; set => colonia = value; }
        public string CodigoPostal { get => codigoPostal; set => codigoPostal = value; }
        public string Municipio { get => municipio; set => municipio = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string CorreoElectronico { get => correoElectronico; set => correoElectronico = value; }
        public string Calle { get => calle; set => calle = value; }
        public string NumeroDireccion { get => numeroDireccion; set => numeroDireccion = value; }
    }
}
