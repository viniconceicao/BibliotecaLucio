namespace Biblioteca;

public class Leitor
{
    public string Nome;
    public int Idade;
    
    public int CPF;

    public List<Livro> LivrosLeitor = new List<Livro>();

    public Leitor(string nome, int idade, int cpf)
    {
        Nome = nome;
        Idade = idade;
        CPF = cpf;

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

    public static List<Leitor> leitores = new List<Leitor>();
    // Criando uma nova lista chamada "leitores" para armazenar os leitores

    public void CriarLeitor(string nome, int idade, int cpf)
    {
        Leitor leitor = new Leitor(nome, idade, cpf); // Criando um novo leitor
        leitores.Add(leitor); // Adicionando o leitor na lista de leitores
    }
    // Aqui começamos a criar o leitor, que vai ser nosso usuário do programa
}
// Depois resolver