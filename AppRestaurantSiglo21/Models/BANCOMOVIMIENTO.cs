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
    
    public partial class BANCOMOVIMIENTO
    {
        public int IDBCOMOV { get; set; }
        public Nullable<int> MONTOMOV { get; set; }
        public Nullable<int> NUMCUENTA { get; set; }
        public Nullable<byte> IDTIPOMOVBCO { get; set; }
        public Nullable<byte> IDENTBANCARIA { get; set; }
    
        public virtual ENTIDADBANCARIA ENTIDADBANCARIA { get; set; }
        public virtual TIPOMOVBANCO TIPOMOVBANCO { get; set; }
    }
}
