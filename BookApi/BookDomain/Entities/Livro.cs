namespace BookDomain.Entities
{
    public class Livro
    {
        public int Codl { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string? Editora { get; set; }
        public int? Edicao { get; set; }
        public string? AnoPublicacao { get; set; }
        public decimal Valor { get; set; }
        public int? AutorId { get; set; }
        public int? AssuntoId { get; set; }
    }
}
