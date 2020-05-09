using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transito_Veracruz.Model.pocos
{
    public class Personal
    {
        private Int32 idPersonal;
        private String numeroPersonal;
        private String tipoPersonal;
        private String apellidos;
        private String nombre;
        private String cargo;
        private String usuario;
        private String contrasenia;

        public override string ToString()
        {
            return String.Format("idPersonal: {0}, numeroPersonal: {1}, tipoPersonal: {2}, apellidos: {3}, " +
                "nombre: {4}, cargo:{5}, usuario: {6}, contrasenia: {7}", idPersonal, numeroPersonal, tipoPersonal, apellidos, nombre, cargo, usuario, contrasenia);
        }
        public int IdPersonal { get => idPersonal; set => idPersonal = value; }
        public string NumeroPersonal { get => numeroPersonal; set => numeroPersonal = value; }
        public string TipoPersonal { get => tipoPersonal; set => tipoPersonal = value; }
        public string Apellidos { get => apellidos; set => apellidos = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Cargo { get => cargo; set => cargo = value; }
        public string Usuario { get => usuario; set => usuario = value; }
        public string Contrasenia { get => contrasenia; set => contrasenia = value; }
    }
}
