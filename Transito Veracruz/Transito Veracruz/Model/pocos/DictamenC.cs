using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transito_Veracruz.Model.pocos
{
    public class DictamenC
    {
        private Int32 idDictamen;
        private String folio;
        private String descripcion;
        private DateTime fechaDictamen;
        private String numeroPersonal;

        public int IdDictamen { get => idDictamen; set => idDictamen = value; }
        public string Folio { get => folio; set => folio = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public DateTime FechaDictamen { get => fechaDictamen; set => fechaDictamen = value; }
        public string NumeroPersonal { get => numeroPersonal; set => numeroPersonal = value; }
    }
}
