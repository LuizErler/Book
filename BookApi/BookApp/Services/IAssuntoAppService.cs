﻿using BookDomain.Entities;

namespace BookApp.Services
{
    public interface IAssuntoAppService
    {
        Task<int> AdicionarAssuntoAsync(Assunto assunto);
        Task<bool> AtualizarAssuntoAsync(Assunto assunto);
        Task<bool> DeletarAssuntoAsync(int id);
        Task<Assunto> ObterAssuntoPorIdAsync(int id);
        Task<IEnumerable<Assunto>> ObterTodosAssuntosAsync();
    }
}
