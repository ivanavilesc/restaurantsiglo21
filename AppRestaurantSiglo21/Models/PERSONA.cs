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
    
    public partial class PERSONA
    {
        public int IDPERSONA { get; set; }
        public int RUT { get; set; }
        public string DV { get; set; }
        public string NOMBRE { get; set; }
        public string APELLIDOPATERNO { get; set; }
        public string APELLIDOMATERNO { get; set; }
        public string DIRECCION { get; set; }
        public string FONO { get; set; }
        public Nullable<System.DateTime> FECHAINGRESO { get; set; }
        public string EMAIL { get; set; }
    
        public virtual CLIENTE CLIENTE { get; set; }
        public virtual USUARIO USUARIO { get; set; }
    }
}
