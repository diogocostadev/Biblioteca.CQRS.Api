using Biblioteca.CQRS.Command.Commands;
using Biblioteca.CQRS.Domain.Entities;
using Biblioteca.CQRS.Domain.Repositories;

namespace Biblioteca.CQRS.Command.Handlers;

public class CadastrarLivroCommandHandler
{
    private readonly ILivroRepository _repository;

    public CadastrarLivroCommandHandler(ILivroRepository repository)
    {
        _repository = repository;
    }

    public async Task Handle(CadastrarLivroCommand command)
    {
        var livro = new Livro(command.Titulo, command.Autor, command.Categoria);
        await _repository.AdicionarAsync(livro);
    }
}