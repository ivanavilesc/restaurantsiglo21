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
    
    public partial class INGREDIENTE
    {
        public int IDINGREDIENTE { get; set; }
        public string DESCINGREDIENTE { get; set; }
        public Nullable<short> CADUCIDAD { get; set; }
        public Nullable<short> STOCK { get; set; }
        public string MEDIDA { get; set; }
        public Nullable<decimal> PORCMERMA { get; set; }
        public int PRODPREPARACION_IDPRODPREPAR { get; set; }
    
        public virtual PRODPREPARACION PRODPREPARACION { get; set; }
    }
}
