namespace Biblioteca;

public class Leitor
{
    public string Nome { get; set; }
    public int Idade { get; set; }
    
    public string CPF { get; set; } // Alterado para string, pois ele não funcionava, seja com ou sem pontos e traços

    public List<Livro> LivrosLeitor = new List<Livro>();

    public Leitor(string nome, int idade, string cpf) // Alterado para string
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

    public static void CriarLeitor(string nome, int idade, string cpf) // Alterado para string
    {
        if (leitores.Exists(l => l.CPF == cpf))
        {
            Console.WriteLine("Erro: Este CPF já está em uso.");
            return;
        }

        var novoLeitor = new Leitor(nome, idade, cpf);
        leitores.Add(novoLeitor);
        Console.WriteLine("Leitor cadastrado com sucesso!");
    }
    // Aqui começamos a criar o leitor, que vai ser nosso usuário do programa

    public static List<Leitor> ListarLeitores()
    {
        return leitores;
    }

    public void EditarLeitor(string cpf) // Alterado para string
    {
        Leitor leitor = leitores.Find(leitor => leitor.CPF == cpf);
        // Procurando o leitor na lista de leitores pelo CPF
        Console.WriteLine("Digite o novo nome do leitor: ");
        leitor.Nome = Console.ReadLine();
        // Pedindo o novo nome do leitor
        Console.WriteLine("Digite a nova idade do leitor: ");
        leitor.Idade = int.Parse(Console.ReadLine());
        // Pedindo a nova idade do leitor
    }

    public void ExcluirLeitor(string cpf) // Alterado para string
    {
        Leitor leitor = leitores.Find(leitor => leitor.CPF == cpf);
        // Procurando o leitor na lista de leitores pelo CPF
        leitores.Remove(leitor);
        // Removendo o leitor da lista de leitores
    }

    // Incluir os livros do leitor
    public void ListarLivrosLeitor(string cpf) // Alterado para string
    {
        Leitor leitor = leitores.Find(leitor => leitor.CPF == cpf);
        // Procurando o leitor na lista de leitores pelo CPF
        if (leitor != null)
        {
            foreach (Livro livro in leitor.LivrosLeitor)
            {
                Console.WriteLine($"Título: {livro.Titulo}, Escritor: {livro.Escritor}, Editora: {livro.Editora}");
                // Mostrando o título, escritor e editora do livro
            }
        }
        else
        {
            Console.WriteLine("Leitor não encontrado.");
        }
    }

    // Editar um livro específico do leitor
    public void EditarLivroLeitor(string cpf, string tituloLivro) // Alterado para string
    {
        Leitor leitor = leitores.Find(leitor => leitor.CPF == cpf);
        // Procurando o leitor na lista de leitores pelo CPF
        Livro livro = leitor.LivrosLeitor.Find(livro => livro.Titulo == tituloLivro);
        // Procurando o livro na lista de livros do leitor pelo título

        if (livro != null)
        {
            Console.WriteLine("Digite o novo título do livro: ");
            livro.Titulo = Console.ReadLine();
            // Pedindo o novo título do livro
            Console.WriteLine("Digite o novo escritor do livro: ");
            livro.Escritor = Console.ReadLine();
            // Pedindo o novo escritor do livro
            Console.WriteLine("Digite a nova editora do livro: ");
            livro.Editora = Console.ReadLine();
            // Pedindo a nova editora do livro
        }
        else
        {
            Console.WriteLine("Livro não encontrado.");
        }
    }

    // Remover um livro, por exemplo, que foi perdido
    public void RemoverLivroLeitor(string cpf, string tituloLivro) // Alterado para string
    {
        Leitor leitor = leitores.Find(leitor => leitor.CPF == cpf);
        // Procurando o leitor na lista de leitores pelo CPF
        Livro livro = leitor.LivrosLeitor.Find(livro => livro.Titulo == tituloLivro);
        // Procurando o livro na lista de livros do leitor pelo título

        if (livro != null)
        {
            leitor.LivrosLeitor.Remove(livro);
            // Removendo o livro da lista de livros do leitor
        }
        else
        {
            Console.WriteLine("Livro não encontrado.");
        }
    }

    // Doar um livro para outro leitor
    public void DoarLivroLeitor(string cpfDoacao, string cpfDestino, string tituloLivro) // Alterado para string
    {
        Leitor leitorDoacao = leitores.Find(leitor => leitor.CPF == cpfDoacao);
        // Procurando o leitor que vai doar o livro na lista de leitores pelo CPF
        Leitor leitorDestino = leitores.Find(leitor => leitor.CPF == cpfDestino);
        // Procurando o leitor que vai receber o livro na lista de leitores pelo CPF
        Livro livro = leitorDoacao.LivrosLeitor.Find(livro => livro.Titulo == tituloLivro);
        // Procurando o livro na lista de livros do leitor que vai doar o livro pelo título

        if (livro != null)
        {
            leitorDestino.LivrosLeitor.Add(livro);
            // Adicionando o livro na lista de livros do leitor que vai receber o livro
            leitorDoacao.LivrosLeitor.Remove(livro);
            // Removendo o livro da lista de livros do leitor que vai doar o livro
        }
        else
        {
            Console.WriteLine("Livro não encontrado.");
        }
    }

    // Listar todos os leitores e seus respectivos livros
    public void ListarLeitoresLivros()
    {
        foreach (Leitor leitor in leitores)
        {
            Console.WriteLine($"Nome: {leitor.Nome}, Idade: {leitor.Idade}, CPF: {leitor.CPF}");
            // Mostrando o nome, idade e CPF do leitor
            foreach (Livro livro in leitor.LivrosLeitor)
            {
                Console.WriteLine($"Título: {livro.Titulo}, Escritor: {livro.Escritor}, Editora: {livro.Editora}");
                // Mostrando o título, escritor e editora do livro
            }
        }
    }

    // Listar um leitor específico e seus respectivos livros
    public void ListarLeitorLivros(string cpf) // Alterado para string
    {
        Leitor leitor = leitores.Find(leitor => leitor.CPF == cpf);
        // Procurando o leitor na lista de leitores pelo CPF
        Console.WriteLine($"Nome: {leitor.Nome}, Idade: {leitor.Idade}, CPF: {leitor.CPF}");
        // Mostrando o nome, idade e CPF do leitor
        foreach (Livro livro in leitor.LivrosLeitor)
        {
            Console.WriteLine($"Título: {livro.Titulo}, Escritor: {livro.Escritor}, Editora: {livro.Editora}");
            // Mostrando o título, escritor e editora do livro
        }
    }

    // Pesquisar por um livro específico, e mostrar os dados do leitor
    public void PesquisarLivroLeitor(string tituloLivro)
    {
        foreach (Leitor leitor in leitores)
        {
            Livro livro = leitor.LivrosLeitor.Find(livro => livro.Titulo == tituloLivro);
            // Procurando o livro na lista de livros do leitor pelo título

            if (livro != null)
            {
                Console.WriteLine($"Nome: {leitor.Nome}, Idade: {leitor.Idade}, CPF: {leitor.CPF}");
                // Mostrando o nome, idade e CPF do leitor
                Console.WriteLine($"Título: {livro.Titulo}, Escritor: {livro.Escritor}, Editora: {livro.Editora}");
                // Mostrando o título, escritor e editora do livro
            }
        }
    }
}