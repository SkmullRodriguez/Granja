//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GranjaSystem.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblVacunas
    {
        public int IdVacuna { get; set; }
        public int IdCerda { get; set; }
        public System.DateTime FechaRegistro { get; set; }
        public string FechaInyeccion { get; set; }
        public string Vacuna { get; set; }
        public string Descripcion { get; set; }
    
        public virtual tblCerdas tblCerdas { get; set; }
    }
}
