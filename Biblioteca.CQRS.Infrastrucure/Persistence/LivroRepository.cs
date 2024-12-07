using System.Data;
using Biblioteca.CQRS.Domain.Entities;
using Biblioteca.CQRS.Domain.Repositories;
using Dapper;

namespace Biblioteca.CQRS.Infrastrucure.Persistence;

public class LivroRepository : ILivroRepository
{
    private readonly DapperDbContext _dbContext;

    public LivroRepository(DapperDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AdicionarAsync(Livro livro)
    {
        var query = "INSERT INTO Livros (Id, Titulo, Autor, Categoria, Disponivel) VALUES (@Id, @Titulo, @Autor, @Categoria, @Disponivel)";
        using var connection = _dbContext.CreateConnection();
        await connection.ExecuteAsync(query, livro);
    }

    public async Task<Livro> ObterPorIdAsync(Guid id)
    {
        var query = "SELECT * FROM Livros WHERE Id = @Id";
        using var connection = _dbContext.CreateConnection();
        return await connection.QuerySingleOrDefaultAsync<Livro>(query, new { Id = id });
    }
}