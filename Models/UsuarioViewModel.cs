namespace DBRELACIONV2.Models
{
    public class UsuarioViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public TipoDocumentoViewModel IdTipoDocumentoNavigation { get; set; }
    }
}
