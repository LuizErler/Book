﻿using BookDomain.Entities;

namespace BookDomain.Repositories
{
    public interface IAutorRepository
    {
        Task<int> AdicionarAsync(Autor autor);
        Task<bool> AtualizarAsync(Autor autor);
        Task<bool> DeletarAsync(int id);
        Task<Autor> ObterPorIdAsync(int id);
        Task<IEnumerable<Autor>> ObterTodosAsync();
        Task<IEnumerable<LivroAutor>> ObterLivroAutorPorIdAsync(int id);
        Task<bool> DeletarLivroAutorAsync(int id);
        Task AdicionarLivroAutorAsync(int CodLivro, int CodAutor);
    }
}
