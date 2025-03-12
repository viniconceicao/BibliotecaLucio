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

    public void ListarLeitores()
    {
        foreach (Leitor leitor in leitores) // Cada leitor na lista de leitores
        {
            Console.WriteLine($"Nome: {leitor.Nome}, Idade: {leitor.Idade}, CPF: {leitor.CPF}");
            // Mostrando o nome, idade e CPF do leitor
        }
    }

    public void EditarLeitor(int cpf)
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

    public void ExcluirLeitor(int cpf)
    {
        Leitor leitor = leitores.Find(leitor => leitor.CPF == cpf);
        // Procurando o leitor na lista de leitores pelo CPF
        leitores.Remove(leitor);
        // Removendo o leitor da lista de leitores
    }

    // Incluir os livros do leitor
    public void ListarLivrosLeitor(int cpf)
    {
        Leitor leitor = leitores.Find(leitor => leitor.CPF == cpf);
        // Procurando o leitor na lista de leitores pelo CPF
        foreach (Livro livro in leitor.LivrosLeitor)

            List<string> cpfsUsados = new List<string>();
        
            Console.Write("Digite o CPF do leitor: ");
            if (!int.TryParse(Console.ReadLine(), out int cpf))
    {
            Console.WriteLine("CPF inválido!");
            return;
    }

            if (leitores.Exists(l => l.CPF == cpf))
    {
            Console.WriteLine("Erro: Este CPF já está em uso.");
            return;
    }

Leitor novoLeitor = new Leitor(nome, idade, cpf);
leitores.Add(novoLeitor);
Console.WriteLine("Leitor cadastrado com sucesso!");
        {
            Console.WriteLine($"Título: {livro.Titulo}, Escritor: {livro.Escritor}, Editora: {livro.Editora}");
            // Mostrando o título, escritor e editora do livro
        }
    }

    // Editar um livro específico do leitor
    public void EditarLivroLeitor(int cpf, string tituloLivro)
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
    public void RemoverLivroLeitor(int cpf, string tituloLivro)
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
    public void DoarLivroLeitor(int cpfDoacao, int cpfDestino, string tituloLivro)
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
    public void ListarLeitorLivros(int cpf)
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
