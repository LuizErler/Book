using BookApp.Services;
using BookDomain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BookApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private readonly IAutorAppService _autorAppService;

        public AutorController(IAutorAppService autorAppService)
        {
            _autorAppService = autorAppService;
        }

        // GET: api/autor
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Autor>>> GetTodosAutores()
        {
            var autores = await _autorAppService.ObterTodosAutoresAsync();
            return Ok(autores);
        }

        // GET: api/autor/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Autor>> GetAutorPorId(int id)
        {
            var autor = await _autorAppService.ObterAutorPorIdAsync(id);
            if (autor == null)
            {
                return NotFound();
            }
            return Ok(autor);
        }

        // POST: api/autor
        [HttpPost]
        public async Task<ActionResult<Autor>> PostAutor(Autor autor)
        {
            var id = await _autorAppService.AdicionarAutorAsync(autor);
            return CreatedAtAction(nameof(GetAutorPorId), new { id = id }, autor);
        }

        // PUT: api/autor/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAutor(int id, Autor autor)
        {
            if (id != autor.CodAu)
            {
                return BadRequest();
            }

            var resultado = await _autorAppService.AtualizarAutorAsync(autor);
            if (!resultado)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE: api/autor/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAutor(int id)
        {
            var resultado = await _autorAppService.DeletarAutorAsync(id);
            if (!resultado)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
