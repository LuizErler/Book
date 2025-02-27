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
        public List<int?> AutorIds { get; set; } = new List<int?>();
        public List<int?> AssuntoIds { get; set; } = new List<int?>();
        public string? IdsAutores { get; set; }
        public string? IdsAssuntos { get; set; }
    }
}
