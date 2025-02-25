using BookApp.Services;
using BookDomain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BookApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivroController : ControllerBase
    {
        private readonly ILivroAppService _livroAppService;

        public LivroController(ILivroAppService livroAppService)
        {
            _livroAppService = livroAppService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Livro>>> ObterTodos()
        {
            var livros = await _livroAppService.ObterTodosAsync();
            return Ok(livros);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Livro>> ObterPorId(int id)
        {
            var livro = await _livroAppService.ObterPorIdAsync(id);
            if (livro == null)
                return NotFound("Livro não encontrado.");

            return Ok(livro);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Adicionar([FromBody] Livro livro)
        {
            if (livro == null)
                return BadRequest("Dados inválidos.");

            var id = await _livroAppService.AdicionarAsync(livro);
            return CreatedAtAction(nameof(ObterPorId), new { id }, livro);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(int id, [FromBody] Livro livro)
        {
            if (livro == null || id != livro.Codl)
                return BadRequest("Dados inválidos.");

            var atualizado = await _livroAppService.AtualizarAsync(livro);
            if (!atualizado)
                return NotFound("Livro não encontrado.");

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletar(int id)
        {
            var deletado = await _livroAppService.DeletarAsync(id);
            if (!deletado)
                return NotFound("Livro não encontrado.");

            return NoContent();
        }
    }
}
