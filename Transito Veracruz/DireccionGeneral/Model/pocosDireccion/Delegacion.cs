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

        public override string ToString()
        {
            return String.Format("idDelegacion: {0}, numeroDelegacion: {1}, nombre: {2}, colonia: {3}, " +
                  "codigoPostal: {4}, municipio:{5}, telefono: {6}, correoElectronico: {7}, calle: {8}, numeroDireccion:{9}", idDelegacion, numeroDelegacion, nombre, colonia, codigoPostal, municipio, telefono, correoElectronico, calle, numeroDireccion);
        }
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
