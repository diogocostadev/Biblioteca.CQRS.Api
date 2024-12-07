using Biblioteca.CQRS.Command.Commands;
using Biblioteca.CQRS.Command.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.CQRS.Api.Controllers;

[ApiController]
[Route("api/livros/commands")]
public class LivroCommandController : ControllerBase
{
    private readonly CadastrarLivroCommandHandler _commandHandler;

    public LivroCommandController(CadastrarLivroCommandHandler commandHandler)
    {
        _commandHandler = commandHandler;
    }

    [HttpPost]
    public async Task<IActionResult> CadastrarLivro([FromBody] CadastrarLivroCommand command)
    {
        await _commandHandler.Handle(command);
        return Ok(new { Mensagem = "Livro cadastrado com sucesso." });
    }
}