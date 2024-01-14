using DBRELACIONV2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace DBRELACIONV2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly DBRELACIONContext _context;

        public UsuarioController(DBRELACIONContext context)
        {
            _context = context;
        }

        //[HttpGet]
        //[Route("VerUsuario")]
        //public async Task<IActionResult> VerUsuario()
        //{
        //    // Incluimos la propiedad de navegación TipoDocumento en la consulta
        //    List<Usuario> lista = await _context.Usuarios.Include(u => u.IdTipoDocumentoNavigation).ToListAsync();

        //    return StatusCode(StatusCodes.Status200OK, lista);
        //}

        //[HttpGet]
        //[Route("VerUsuario")]
        //public async Task<IActionResult> VerUsuario()
        //{
        //    // Incluimos la propiedad de navegación TipoDocumento en la consulta
        //    List<Usuario> lista = await _context.Usuarios.Include(u => u.IdTipoDocumentoNavigation).ToListAsync();

        //    var jsonOptions = new JsonSerializerOptions
        //    {
        //        ReferenceHandler = ReferenceHandler.Preserve,
        //        // Puedes agregar otras configuraciones si es necesario
        //    };

        //    return StatusCode(StatusCodes.Status200OK, JsonSerializer.Serialize(lista, jsonOptions));
        //}
        [HttpGet]
        [Route("VerUsuario")]
        public async Task<IActionResult> VerUsuario()
        {
            // Incluimos la propiedad de navegación TipoDocumento en la consulta
            List<Usuario> lista = await _context.Usuarios.Include(u => u.IdTipoDocumentoNavigation).ToListAsync();

            var jsonOptions = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve,
                WriteIndented = true, // Esta opción agrega formato con sangrías al JSON
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull, // Ignora propiedades nulas
                                                                              // Puedes agregar otras configuraciones si es necesario
            };

            string jsonResult = JsonSerializer.Serialize(lista, jsonOptions);

            return StatusCode(StatusCodes.Status200OK, jsonResult);
        }




        [HttpPost]
        [Route("GuardarUsuario")]
        public async Task<IActionResult> GuardarUsuario([FromBody] Usuario usuario)
        {
            try
            {
                if (usuario == null)
                {
                    return BadRequest("Datos de usuario no válidos.");
                }

                _context.Usuarios.Add(usuario);
                await _context.SaveChangesAsync();

                return StatusCode(StatusCodes.Status201Created, usuario);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al guardar el usuario: {ex.Message}");
            }
        }



    }
}
