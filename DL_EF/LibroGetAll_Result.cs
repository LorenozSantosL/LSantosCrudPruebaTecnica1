//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DL_EF
{
    using System;
    
    public partial class LibroGetAll_Result
    {
        public int IdLibro { get; set; }
        public string Nombre { get; set; }
        public Nullable<int> IdAutor { get; set; }
        public string NombreAutor { get; set; }
        public Nullable<int> NumeroPaginas { get; set; }
        public Nullable<System.DateTime> FechaPublicacion { get; set; }
        public Nullable<int> IdEditorial { get; set; }
        public string NombreEditorial { get; set; }
        public string Edicion { get; set; }
        public Nullable<int> IdGenero { get; set; }
        public string NombreGenero { get; set; }
    }
}
