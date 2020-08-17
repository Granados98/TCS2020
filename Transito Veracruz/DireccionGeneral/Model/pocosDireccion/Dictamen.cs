using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DireccionGeneral.Model.pocosDireccion
{
    class Dictamen
    {
        private Int32 idDictamen;
        private String descripcion;
        private DateTime fechaDictamen;
        private Int32 idPersonal;

        public int IdDictamen { get => idDictamen; set => idDictamen = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public DateTime FechaDictamen { get => fechaDictamen; set => fechaDictamen = value; }
        public int IdPersonal { get => idPersonal; set => idPersonal = value; }
    }
}
