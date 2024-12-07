namespace Biblioteca.CQRS.Command.Commands;

public class CadastrarLivroCommand
{
    public string Titulo { get; set; }
    public string Autor { get; set; }
    public string Categoria { get; set; }

    public CadastrarLivroCommand(string titulo, string autor, string categoria)
    {
        Titulo = titulo;
        Autor = autor;
        Categoria = categoria;
    }
}