using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transito_Veracruz.Model.pocos
{
    public class Conductor
    {
        private Int32 idConductor;
        private String numeroLicencia="";
        private String apellidos="";
        private String nombre="";
        private String fechaNacimiento;
        private String telefono="";
        private String usuario="";
        private String contrasenia="";
        private DateTime fechaRegistro;

        public override string ToString()
        {
            return String.Format("idConductor: {0}, numeroLicencia: {1}, apellidos: {2}, nombre: {3}, " +
                "fechaNacimiento: {4}, telefono:{5}, usuario: {6}, contrasenia: {7}", idConductor, numeroLicencia, apellidos, nombre, fechaNacimiento, telefono, usuario, contrasenia);
        }

        public int IdConductor { get => idConductor; set => idConductor = value; }
        public string NumeroLicencia { get => numeroLicencia; set => numeroLicencia = value; }
        public string Apellidos { get => apellidos; set => apellidos = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public String FechaNacimiento { get => fechaNacimiento; set => fechaNacimiento = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Usuario { get => usuario; set => usuario = value; }
        public string Contrasenia { get => contrasenia; set => contrasenia = value; }
        public DateTime FechaRegistro { get => fechaRegistro; set => fechaRegistro = value; }
    }
}
