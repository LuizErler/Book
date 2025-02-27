using BookDomain.Repositories;
using Microsoft.AspNetCore.Mvc;
using Stimulsoft.Report;

namespace BookApi.Controllers
{
    [Route("api/relatorios")]
    [ApiController]
    public class RelatorioController : ControllerBase
    {
        private readonly IRelatorioRepository _relatorioRepository;

        public RelatorioController(IRelatorioRepository relatorioRepository)
        {
            _relatorioRepository = relatorioRepository;
        }

        [HttpGet("autores")]
        public async Task<IActionResult> GerarRelatorioAutores()
        {
            var report = await _relatorioRepository.GerarRelatorioAutoresAsync();

            var tempPath = Path.GetTempFileName() + ".pdf";
            report.ExportDocument(StiExportFormat.Pdf, tempPath);

            byte[] fileBytes = await System.IO.File.ReadAllBytesAsync(tempPath);

        
            Response.OnCompleted(() =>
            {

                System.IO.File.Delete(tempPath);
                return Task.CompletedTask;
            });


            return File(fileBytes, "application/pdf", "RelatorioAutores.pdf");
        }



    }
}
