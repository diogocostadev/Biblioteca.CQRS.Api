using Biblioteca.CQRS.Domain.Repositories;
using Biblioteca.CQRS.Queries.DTOs;
using Biblioteca.CQRS.Queries.Queries;

namespace Biblioteca.CQRS.Queries.Handlers;

public class ConsultarLivroQueryHandler
{
    private readonly ILivroRepository _repository;

    public ConsultarLivroQueryHandler(ILivroRepository repository)
    {
        _repository = repository;
    }

    public async Task<LivroDto> Handle(ConsultarLivroQuery query)
    {
        var livro = await _repository.ObterPorIdAsync(query.Id);

        if (livro == null) return null;

        return new LivroDto
        {
            Id = livro.Id,
            Titulo = livro.Titulo,
            Autor = livro.Autor,
            Categoria = livro.Categoria,
            Disponivel = livro.Disponivel
        };
    }
}