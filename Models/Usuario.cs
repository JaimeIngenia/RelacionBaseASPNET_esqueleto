using System;
using System.Collections.Generic;

namespace DBRELACIONV2.Models
{
    public class Usuario
    {

        public int Id { get; set; }
        public string Nombre { get; set; }



        public int IdTipoDocumento { get; set; }  // Foreign key
        public virtual TipoDocumento? IdTipoDocumentoNavigation { get; set; }  // Navigation property


    }
}
