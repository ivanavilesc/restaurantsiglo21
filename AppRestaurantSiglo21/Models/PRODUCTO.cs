
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
    
public partial class PRODUCTO
{

    public decimal IDPRODUCTO { get; set; }

    public string DESCPRODUCTO { get; set; }

    public Nullable<decimal> PRECIOPRODUCTO { get; set; }

    public decimal IDRECPRODUCTO { get; set; }

    public decimal IDPRODPREPARACION { get; set; }

    public decimal IDESTADOPRODUCTO { get; set; }

    public decimal IDTIPOPRODUCTO { get; set; }



    public virtual ESTADOPRODUCTO ESTADOPRODUCTO { get; set; }

    public virtual TIPOPRODUCTO TIPOPRODUCTO { get; set; }

    public virtual PRODUCTOPREPARACION PRODUCTOPREPARACION { get; set; }

    public virtual RECETAPRODUCTO RECETAPRODUCTO { get; set; }

}

}