using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DireccionGeneral.Model.pocosDireccion
{
    public class Delegacion
    {
        private Int32 idDelegacion;
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
            return String.Format("idDelegacion: {0}, nombre: {1}, colonia: {2}, " +
                  "codigoPostal: {3}, municipio:{4}, telefono: {5}, correoElectronico: {6}, calle: {7}, numeroDireccion:{8}", idDelegacion, nombre, colonia, codigoPostal, municipio, telefono, correoElectronico, calle, numeroDireccion);
        }
        public int IdDelegacion { get => idDelegacion; set => idDelegacion = value; }
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
