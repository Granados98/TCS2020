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
    
    public partial class Mensaje
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Mensaje()
        {
            this.Chat = new HashSet<Chat>();
        }
    
        public int idMensaje { get; set; }
        public string texto { get; set; }
        public System.DateTime fechaEnvio { get; set; }
        public System.TimeSpan horaEnvio { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Chat> Chat { get; set; }
    }
}