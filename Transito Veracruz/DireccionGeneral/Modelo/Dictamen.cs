//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DireccionGeneral.Modelo
{
    using System;
    using System.Collections.Generic;
    
    public partial class Dictamen
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Dictamen()
        {
            this.Reporte = new HashSet<Reporte>();
        }
    
        public int idDictamen { get; set; }
        public int folio { get; set; }
        public string descripcion { get; set; }
        public System.DateTime fechaDictamen { get; set; }
        public System.TimeSpan horaDictamen { get; set; }
        public Nullable<int> idPersonal { get; set; }
    
        public virtual Personal Personal { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Reporte> Reporte { get; set; }
    }
}