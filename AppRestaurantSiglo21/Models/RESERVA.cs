//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AppRestaurantSiglo21.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class RESERVA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RESERVA()
        {
            this.ORDEN = new HashSet<ORDEN>();
        }
    
        public int IDRESRVA { get; set; }
        public Nullable<System.DateTime> FECHARESERVA { get; set; }
        public Nullable<short> CANTIDADCLIENTE { get; set; }
        public byte IDESTADORESRVA { get; set; }
        public int IDPERSONA { get; set; }
        public short IDMESA { get; set; }
    
        public virtual CLIENTE CLIENTE { get; set; }
        public virtual ESTADORESERVA ESTADORESERVA { get; set; }
        public virtual MESA MESA { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ORDEN> ORDEN { get; set; }
    }
}
