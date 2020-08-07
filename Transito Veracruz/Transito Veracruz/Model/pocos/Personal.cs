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
        private String tipoPersonal;
        private String apellidos;
        private String nombre;
        private String cargo;
        private String usuario;
        private String contrasenia;
        private String estado;

        public override string ToString()
        {
            return String.Format("idPersonal: {0}, tipoPersonal: {1}, apellidos: {2}, " +
                "nombre: {3}, cargo:{4}, usuario: {5}, contrasenia: {6}, estado: {7}", idPersonal, tipoPersonal, apellidos, nombre, cargo, usuario, contrasenia, estado);
        }
        public int IdPersonal { get => idPersonal; set => idPersonal = value; }
        public string TipoPersonal { get => tipoPersonal; set => tipoPersonal = value; }
        public string Apellidos { get => apellidos; set => apellidos = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Cargo { get => cargo; set => cargo = value; }
        public string Usuario { get => usuario; set => usuario = value; }
        public string Contrasenia { get => contrasenia; set => contrasenia = value; }
        public string Estado { get => estado; set => estado = value; }
    }
}
