using Biblioteca;

internal class Program
{
    private static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("\n===== MENU =====");
            Console.WriteLine("1 - Criar Leitor");
            Console.WriteLine("2 - Listar Leitores");
            Console.WriteLine("3 - Editar Leitor");
            Console.WriteLine("4 - Excluir Leitor");
            Console.WriteLine("5 - Adicionar Livro");
            Console.WriteLine("6 - Editar Livro");
            Console.WriteLine("7 - Remover Livro");
            Console.WriteLine("0 - Sair");
            Console.Write("Escolha uma opção: ");

            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    CriarLeitor();
                    break;
                case "2":
                    ListarLeitores();
                    break;
                case "3":
                    EditarLeitor();
                    break;
                case "4":
                    ExcluirLeitor();
                    break;  
                case "5":
                    AdicionarLivro();
                    break;
                case "6":
                    EditarLivro();
                    break;
                case "7":
                    RemoverLivro();
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Opção inválida!");
                    break;
            }
        }
    }

    static void CriarLeitor()
    {
        Console.Write("Digite o nome do leitor: ");
        string nome = Console.ReadLine();
        Console.Write("Digite a idade do leitor: ");
        int idade = int.Parse(Console.ReadLine());
        Console.Write("Digite o CPF do leitor (11 dígitos): ");
        string cpf = Console.ReadLine();

        if (cpf.Length != 11 || !cpf.All(char.IsDigit))
        {
            Console.WriteLine("CPF inválido! Deve conter exatamente 11 NÚMEROS.");
            return;
        }

        if (Leitor.CriarLeitor(nome, idade, cpf))
        {
            Console.WriteLine("Leitor cadastrado com sucesso!");
        }
        else
        {
            Console.WriteLine("Erro: Este CPF já está em uso.");
        }
    }

    static void ListarLeitores()
    {
        var leitores = Leitor.ListarLeitores();
        if (leitores.Count == 0)
        {
            Console.WriteLine("Nenhum leitor cadastrado!");
            return;
        }

        Console.WriteLine("\nLista de Leitores:");
        foreach (var leitor in leitores)
        {
            Console.WriteLine($"Nome: {leitor.Nome}, Idade: {leitor.Idade}, CPF: {leitor.CPF}");
        }
    }

    static void EditarLeitor() {
        Console.Write("Digite o CPF do leitor que deseja editar: ");
        string cpf = Console.ReadLine();
        Leitor leitor = Leitor.leitores.Find(l => l.CPF == cpf);
        if (leitor == null)
        {
            Console.WriteLine("Leitor não encontrado!");
            return;
        }

        Console.Write("Digite o novo nome do leitor: ");
        string novoNome = Console.ReadLine();
        Console.Write("Digite a nova idade do leitor: ");
        int novaIdade = int.Parse(Console.ReadLine());

        if (leitor.EditarLeitor(novoNome, novaIdade))
        {
            Console.WriteLine("Leitor editado com sucesso!");
        }
        else
        {
            Console.WriteLine("Erro ao editar leitor.");
        }
    }

    static void ExcluirLeitor()
    {
        Console.Write("Digite o CPF do leitor que deseja excluir: ");
        string cpf = Console.ReadLine();

        if (Leitor.ExcluirLeitor(cpf))
        {
            Console.WriteLine("Leitor excluído com sucesso!");
        }
        else
        {
            Console.WriteLine("Erro: Leitor não encontrado.");
        }
    }

    static void AdicionarLivro()
    {
        Console.Write("Digite o CPF do leitor que deseja adicionar um livro: ");
        string cpf = Console.ReadLine();
        Leitor leitor = Leitor.leitores.Find(l => l.CPF == cpf);
        if (leitor == null)
        {
            Console.WriteLine("Leitor não encontrado!");
            return;
        }

        // Ver se realmente precisa de todas essas informações do livro, subtítulo e pá (CONFERIR Livro.cs)
        Console.Write("Digite o título do livro: ");
        string titulo = Console.ReadLine();
        Console.Write("Digite o subtitulo do livro: ");
        string subTitulo = Console.ReadLine();
        Console.Write("Digite o escritor do livro: ");
        string escritor = Console.ReadLine();
        Console.Write("Digite a editora do livro: ");
        string editora = Console.ReadLine();
        Console.Write("Digite o gênero do livro: ");
        string genero = Console.ReadLine();
        Console.Write("Digite o ano de publicação do livro: ");
        int anoPublicacao = int.Parse(Console.ReadLine());
        Console.Write("Digite o tipo da capa do livro: ");
        string tipoDaCapa = Console.ReadLine();
        Console.Write("Digite o número de páginas do livro: ");
        int numeroDePaginas = int.Parse(Console.ReadLine());

        Livro livro = new Livro(titulo, subTitulo, escritor, editora, genero, anoPublicacao, tipoDaCapa, numeroDePaginas);
        leitor.AdicionarLivro(livro);
        Console.WriteLine("Livro adicionado com sucesso!");
    }

    static void EditarLivro()
    {
        Console.Write("Digite o CPF do leitor que deseja editar um livro: ");
        string cpf = Console.ReadLine();
        Leitor leitor = Leitor.leitores.Find(l => l.CPF == cpf);
        if (leitor == null)
        {
            Console.WriteLine("Leitor não encontrado!");
            return;
        }

        Console.Write("Digite o título do livro que deseja editar: ");
        string titulo = Console.ReadLine();
        Livro livro = leitor.LivrosLeitor.Find(l => l.Titulo == titulo);
        if (livro == null)
        {
            Console.WriteLine("Livro não encontrado!");
            return;
        }

        Console.Write("Digite o novo título do livro: ");
        string novoTitulo = Console.ReadLine();
        Console.Write("Digite o novo subtitulo do livro: ");
        string novoSubTitulo = Console.ReadLine();
        Console.Write("Digite o novo escritor do livro: ");
        string novoEscritor = Console.ReadLine();
        Console.Write("Digite a nova editora do livro: ");
        string novaEditora = Console.ReadLine();
        Console.Write("Digite o novo gênero do livro: ");
        string novoGenero = Console.ReadLine();
        Console.Write("Digite o novo ano de publicação do livro: ");
        int novoAnoPublicacao = int.Parse(Console.ReadLine());
        Console.Write("Digite o novo tipo da capa do livro: ");
        string novoTipoDaCapa = Console.ReadLine();
        Console.Write("Digite o novo número de páginas do livro: ");
        int novoNumeroDePaginas = int.Parse(Console.ReadLine());

        livro.Titulo = novoTitulo;
        livro.SubTitulo = novoSubTitulo;
        livro.Escritor = novoEscritor;
        livro.Editora = novaEditora;
        livro.Genero = novoGenero;
        livro.AnoPublicacao = novoAnoPublicacao;
        livro.TipoDaCapa = novoTipoDaCapa;
        livro.NumeroDePaginas = novoNumeroDePaginas;

        Console.WriteLine("Livro editado com sucesso!");
    }

    static void RemoverLivro()
    {
        Console.Write("Digite o CPF do leitor que deseja remover um livro: ");
        string cpf = Console.ReadLine();
        Leitor leitor = Leitor.leitores.Find(l => l.CPF == cpf);
        if (leitor == null)
        {
            Console.WriteLine("Leitor não encontrado!");
            return;
        }

        Console.Write("Digite o título do livro que deseja remover: ");
        string titulo = Console.ReadLine();
        if (leitor.RemoverLivro(titulo)) // RESOLVER ISSO
        {
            Console.WriteLine("Livro removido com sucesso!");
        }
        else
        {
            Console.WriteLine("Livro não encontrado!");
        }
    }
}

/* 

  (o “✓" Indica que já foi feito)

• Incluir os livros do leitor ✓
• Editar um livro especifico do leitor ✓
• Remover um livro, por exemplo, que foi perdido - FAZENDO
• Doar um livro para outro leitor
• Listar todos os leitores e seus respectivos livros
• Listar um leitor especifico e seus respectivos livros
• Pesquisar por um livro especifico, e mostrar os dados do leitor
 */



 // to começando a ficar com muito peso na consciência de dar tab no copilot...