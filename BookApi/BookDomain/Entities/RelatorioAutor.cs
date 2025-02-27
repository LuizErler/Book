namespace BookDomain.Models
{
    public class RelatorioAutor
    {
        public int AutorId { get; set; }
        public string AutorNome { get; set; }
        public string Assuntos { get; set; } 
        public string LivrosRelacionados { get; set; } 
        public string AnosPublicacao { get; set; } 
    }
}
