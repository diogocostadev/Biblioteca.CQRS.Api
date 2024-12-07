using Biblioteca.CQRS.Queries.Handlers;
using Biblioteca.CQRS.Queries.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.CQRS.Api.Controllers;

[ApiController]
[Route("api/livros/queries")]
public class LivroQueryController : ControllerBase
{
    private readonly ConsultarLivroQueryHandler _queryHandler;

    public LivroQueryController(ConsultarLivroQueryHandler queryHandler)
    {
        _queryHandler = queryHandler;
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> ConsultarLivro(Guid id)
    {
        var query = new ConsultarLivroQuery(id);
        var livro = await _queryHandler.Handle(query);

        if (livro == null)
        {
            return NotFound(new { Mensagem = "Livro não encontrado." });
        }

        return Ok(livro);
    }
}