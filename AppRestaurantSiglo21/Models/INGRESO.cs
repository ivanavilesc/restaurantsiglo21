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
    
    public partial class INGRESO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public INGRESO()
        {
            this.BANCOMOVIMIENTO = new HashSet<BANCOMOVIMIENTO>();
        }
    
        public int IDINGRESO { get; set; }
        public Nullable<int> MONTO { get; set; }
        public string DESCINGRESO { get; set; }
        public Nullable<System.DateTime> FECHAMOVIMIENTO { get; set; }
        public int IDCAJAOPERACION { get; set; }
    
        public virtual CAJAOPERACION CAJAOPERACION { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BANCOMOVIMIENTO> BANCOMOVIMIENTO { get; set; }
    }
}
