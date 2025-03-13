namespace Biblioteca;

public class Livro
{
    public string Titulo { get; set; }
    public string SubTitulo { get; set; }
    public string Escritor { get; set; }
    public string Editora { get; set; }
    public string Genero { get; set; }
    public int AnoPublicacao { get; set; }
    public string TipoDaCapa { get; set; }
    public int NumeroDePaginas { get; set; }

    public Livro(string titulo, string subTitulo, string escritor, string editora, string genero, int anoPublicacao, string tipoDaCapa, int numeroDePaginas)
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