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
}
