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
    
    public partial class MEDIOPAGOTX
    {
        public byte IDMEDIOPAGOTX { get; set; }
        public Nullable<int> RUT { get; set; }
        public string DVCLIENTETX { get; set; }
        public string DESCMEDIOPAGO { get; set; }
        public Nullable<decimal> MONTO { get; set; }
        public byte IDMEDIOPAGO { get; set; }
    
        public virtual MEDIOPAGO MEDIOPAGO { get; set; }
    }
}
