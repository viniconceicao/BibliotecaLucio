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
            Console.WriteLine("5 - Listar Livros de um Leitor");
            Console.WriteLine("6 - Adicionar Livro a um Leitor");
            Console.WriteLine("7 - Remover Livro de um Leitor");
            Console.WriteLine("8 - Doar Livro");
            Console.WriteLine("9 - Pesquisar Livro por Leitor");
            Console.WriteLine("0 - Sair");
            Console.Write("Escolha uma opção: ");

            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    CriarLeitor();
                    break;
            }

        }

        static void CriarLeitor()
        {
            Console.Write("Digite o nome do leitor: ");
            string nome = Console.ReadLine();
            Console.Write("Digite a idade do leitor: ");
            int idade = int.Parse(Console.ReadLine());
            Console.Write("Digite o CPF do leitor: ");
            int cpf = int.Parse(Console.ReadLine());

            Leitor leitor = new Leitor(nome, idade, cpf);
            Leitor.leitores.Add(leitor);

            Console.WriteLine("Leitor cadastrado com sucesso!");
        }
    }
}

// Criar um CRUD do leitor (CADASTRAR, LISTAR, EDITAR e EXCLUIR)
// Incluir os livros do leitor
// Editar um livro específico do leitor
// Remover um livro, por exemplo, que foi perdido
// Doar um livro para outro leitor
// Listar todos os leitores e seus respectivos livros
// Listar um leitor específico e seus respectivos livros
// Pesquisar por um livro específico, e mostrar os dados do leitor

// Nas classes devem ser utilizados construtores
// Os dados cadastrados devem ser digitados pelo usuário

// No leitor incluir um atributo para o CPF, garantido assim um identificador único para o leitor
// - Ao cadastro novo um novo leitor, validar se o CPF informado já não está em uso
// - Ver método Exists de List
// A busca pelo leitor deve ser realizado através do seu CPF
// O usuário deve poder cadastrar quantos leitores ou livros ele desejar

/* Alunos:
    - Alisson Rafael da Cruz Velho (testando, testando, testando
)
    - Marcos Vinicius Arruda Vandresen
    - Rodrigo Vaisam Bastos
    - Vinicius de Liz da Conceição
*/