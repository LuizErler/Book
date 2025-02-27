using BookApp.Services;
using BookDomain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BookApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssuntoController : ControllerBase
    {
        private readonly IAssuntoAppService _assuntoAppService;

        public AssuntoController(IAssuntoAppService assuntoAppService)
        {
            _assuntoAppService = assuntoAppService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Assunto>>> GetAssuntos()
        {
            var assuntos = await _assuntoAppService.ObterTodosAssuntosAsync();
            return Ok(assuntos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Assunto>> GetAssunto(int id)
        {
            var assunto = await _assuntoAppService.ObterAssuntoPorIdAsync(id);
            if (assunto == null)
            {
                return NotFound();
            }
            return Ok(assunto);
        }

        [HttpPost]
        public async Task<ActionResult<Assunto>> PostAssunto(Assunto assunto)
        {
            var id = await _assuntoAppService.AdicionarAssuntoAsync(assunto);
            return CreatedAtAction("GetAssunto", new { id = id }, assunto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAssunto(int id, Assunto assunto)
        {
            if (id != assunto.CodAs)
            {
                return BadRequest();
            }

            var sucesso = await _assuntoAppService.AtualizarAssuntoAsync(assunto);
            if (!sucesso)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAssunto(int id)
        {
            var sucesso = await _assuntoAppService.DeletarAssuntoAsync(id);
            if (!sucesso)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
