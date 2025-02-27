using BookDomain.Models;
using BookDomain.Repositories;
using Dapper;
using DesafioBackEndInfra;
using FastMember;
using Npgsql;
using Stimulsoft.Report;
using System.Data;

namespace BookInfra.Repositories
{
    public class RelatorioRepository : IRelatorioRepository
    {
        private readonly BaseDb _baseDb;

        public RelatorioRepository(BaseDb baseDb)
        {
            _baseDb = baseDb;
        }

        public async Task<StiReport> GerarRelatorioAutoresAsync()
        {
            using var connection = new NpgsqlConnection(_baseDb.GetConnectionString());
            await connection.OpenAsync();

            string query = "SELECT * FROM vw_relatorio_autores";
            var dados = await connection.QueryAsync<RelatorioAutor>(query);

            if (dados == null || !dados.Any())
            {
                throw new Exception("Nenhum dado encontrado para o relatório.");
            }

            var report = new StiReport();

            var dataTable = new DataTable("RelatorioAutores");
            dataTable.Columns.Add("AutorId", typeof(int));
            dataTable.Columns.Add("AutorNome", typeof(string));
            dataTable.Columns.Add("Assuntos", typeof(string));
            dataTable.Columns.Add("LivrosRelacionados", typeof(string));
            dataTable.Columns.Add("AnosPublicacao", typeof(string));

            foreach (var item in dados)
            {
                dataTable.Rows.Add(item.AutorId, item.AutorNome, item.Assuntos, item.LivrosRelacionados, item.AnosPublicacao);
            }

            var dataSet = new DataSet();
            dataSet.Tables.Add(dataTable);

            report.RegData("RelatorioAutores", dataSet);
            report.Dictionary.Synchronize();

            if (report.Pages.Count == 0)
            {
                var reportPage = new Stimulsoft.Report.Components.StiPage(report);  
                report.Pages.Add(reportPage);
            }

            var reportPageInstance = report.Pages[0]; 

            var dataBand = new Stimulsoft.Report.Components.StiDataBand
            {
                DataSourceName = "RelatorioAutores",
                Height = 30, 
                Name = "AutoresBand" 
            };
            reportPageInstance.Components.Add(dataBand);  

         
            var autorNomeTextBox = new Stimulsoft.Report.Components.StiText
            {
                Text = "{RelatorioAutores.AutorNome}", 
                Left = 10,
                Top = 10,
                Width = 200,
                Height = 20
            };
            dataBand.Components.Add(autorNomeTextBox); 

            return report;
        }



    }
}
