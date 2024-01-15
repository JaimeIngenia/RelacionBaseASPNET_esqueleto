using System;
using System.Collections.Generic;

namespace DBRELACIONV2.Models
{
    public class TipoDocumento
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }




        public ICollection<Usuario> Usuarios { get; set; }   // Navigation property
    }
}
