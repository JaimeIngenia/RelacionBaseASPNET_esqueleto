using DBRELACIONV2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DBRELACIONV2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoDocumentoController : ControllerBase
    {
        private readonly DBRELACIONContext _context;

        public TipoDocumentoController(DBRELACIONContext context)
        {
            _context = context;
        }

        //[HttpGet]
        //[Route("VerTiposDocumentos")]
        //public async Task<IActionResult> VerTiposDocumentos()
        //{
        //    try
        //    {
        //        var tiposDocumentos = await _context.TipoDocumentos.Include(t => t.Usuarios).ToListAsync();

        //        if (tiposDocumentos == null || tiposDocumentos.Count == 0)
        //        {
        //            return NotFound("No se encontraron tipos de documentos.");
        //        }

        //        return Ok(tiposDocumentos);
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError, $"Error al recuperar tipos de documentos: {ex.Message}");
        //    }
        //}

        [HttpGet]
        [Route("VerTipoDocumento")]
        public async Task<IActionResult> VerTipoDocumento()
        {
            List<TipoDocumento> lista = _context.TipoDocumentos.ToList();
            return StatusCode(StatusCodes.Status200OK, lista);
        }


        [HttpPost]
        [Route("GuardarTipoDocumento")]
        public async Task<IActionResult> GuardarTipoDocumento([FromBody] TipoDocumento tipoDocumento)
        {
            try
            {
                if (tipoDocumento == null)
                {
                    return BadRequest("Datos de tipo de documento no válidos.");
                }

                _context.TipoDocumentos.Add(tipoDocumento);
                await _context.SaveChangesAsync();

                return StatusCode(StatusCodes.Status201Created, tipoDocumento);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al guardar el tipo de documento: {ex.Message}");
            }
        }
    }
}
