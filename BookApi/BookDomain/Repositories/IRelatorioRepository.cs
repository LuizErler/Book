using BookDomain.Entities;
using Stimulsoft.Report;

namespace BookDomain.Repositories
{
    public interface IRelatorioRepository
    {
        Task<StiReport> GerarRelatorioAutoresAsync();
    }
}
