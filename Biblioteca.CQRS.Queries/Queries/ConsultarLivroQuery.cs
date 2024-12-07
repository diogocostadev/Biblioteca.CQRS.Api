namespace Biblioteca.CQRS.Queries.Queries;

public class ConsultarLivroQuery
{
    public Guid Id { get; set; }

    public ConsultarLivroQuery(Guid id)
    {
        Id = id;
    }
}