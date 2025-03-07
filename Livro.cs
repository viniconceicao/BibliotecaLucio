namespace Biblioteca;

public class Livro
{
    public string Titulo;
    public string SubTitulo;
    public string Escritor;
    public string Editora;
    public string Genero;
    public int AnoPublicacao;
    public string TipoDaCapa;
    public int NumeroDePaginas;


public Livro()
    {
        Titulo = "";
        SubTitulo = "";
        Escritor = "";
        Editora = "";
        Genero = "";
        AnoPublicacao = 0;
        TipoDaCapa = "";
        NumeroDePaginas = 0;
    }
    public Livro(string titulo, string subTitulo, string escritor, string editora, string genero, int anoPublicacao, string tipoDaCapa, int
    numeroDePaginas)
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