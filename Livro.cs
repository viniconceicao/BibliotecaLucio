namespace Biblioteca;

internal class Livro
{
    internal string Titulo { get; set; }
    internal string SubTitulo { get; set; }
    internal string Escritor { get; set; }
    internal string Editora { get; set; }
    internal string Genero { get; set; }
    internal int AnoPublicacao { get; set; }
    internal string TipoDaCapa { get; set; }
    internal int NumeroDePaginas { get; set; }

    internal Livro(string titulo, string subTitulo, string escritor, string editora, string genero, int anoPublicacao, string tipoDaCapa, int numeroDePaginas)
    {
        Titulo = titulo;
        SubTitulo = subTitulo;
        Escritor = escritor;
        Editora = editora;
        Genero = genero;
        AnoPublicacao = anoPublicacao;
        TipoDaCapa = tipoDaCapa;
        NumeroDePaginas = numeroDePaginas;
    }
}