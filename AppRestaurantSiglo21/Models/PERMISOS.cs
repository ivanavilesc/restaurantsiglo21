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
    
    public partial class PERMISOS
    {
        public decimal IDPERMISO { get; set; }
        public Nullable<System.DateTime> FECHAMODIFICACION { get; set; }
        public int IDROL { get; set; }
        public short IDFUNCIONALIDAD { get; set; }
    
        public virtual FUNCIONALIDAD FUNCIONALIDAD { get; set; }
        public virtual ROL ROL { get; set; }
    }
}
