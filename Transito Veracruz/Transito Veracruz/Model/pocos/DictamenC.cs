﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transito_Veracruz.Model.pocos
{
    public class DictamenC
    {
        private Int32 idDictamen;
        private String descripcion;
        private String fechaDictamen;
        private Int32 idPersonal;

        public int IdDictamen { get => idDictamen; set => idDictamen = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public string FechaDictamen { get => fechaDictamen; set => fechaDictamen = value; }
        public int IdPersonal { get => idPersonal; set => idPersonal = value; }
    }
}
