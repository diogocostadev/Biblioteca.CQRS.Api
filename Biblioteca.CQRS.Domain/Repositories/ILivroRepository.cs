using Biblioteca.CQRS.Domain.Entities;

namespace Biblioteca.CQRS.Domain.Repositories;

public interface ILivroRepository
{
    Task AdicionarAsync(Livro livro);
    Task<Livro> ObterPorIdAsync(Guid id);
}