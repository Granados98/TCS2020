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
        private Int32 folio;
        private String descripcion;
        private DateTime fechaDictamen;
        private Int32 idPersonal;

        public int IdDictamen { get => idDictamen; set => idDictamen = value; }
        public int Folio { get => folio; set => folio = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public DateTime FechaDictamen { get => fechaDictamen; set => fechaDictamen = value; }
        public int IdPersonal { get => idPersonal; set => idPersonal = value; }
    }
}