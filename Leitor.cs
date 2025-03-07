namespace Biblioteca;

public class Leitor
{
    public string Nome;
    public int Idade;
    public List<Livro> LivrosLeitor = new List<Livro>();

    public Leitor(string nome, int idade)
    {
        Nome = nome;
        Idade = idade;
    }

    public void AdicionarLivro(Livro livro)
    {
        this.LivrosLeitor.Add(livro);
    }

    public void RemoverLivro(Livro livro)
    {
        this.LivrosLeitor.Remove(livro);
    }

    public void DoarLivro(Livro livroDoado, Leitor leitorDestino){
        leitorDestino.LivrosLeitor.Add(livroDoado);
        this.LivrosLeitor.Remove(livroDoado);
    }
}
// Depois resolver