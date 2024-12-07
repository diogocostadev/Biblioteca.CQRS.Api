namespace Biblioteca.CQRS.Domain.Entities;

public class Livro
{
    public Guid Id { get; private set; }
    public string Titulo { get; private set; }
    public string Autor { get; private set; }
    public string Categoria { get; private set; }
    public bool Disponivel { get; private set; }

    public Livro() { }
    public Livro(string titulo, string autor, string categoria)
    {
        Id = Guid.NewGuid();
        Titulo = titulo;
        Autor = autor;
        Categoria = categoria;
        Disponivel = true;
    }
}