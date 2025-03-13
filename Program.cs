using System;
using System.Linq;

namespace Biblioteca
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                // Exibe o menu de opções para o usuário
                Console.WriteLine("\nEscolha uma opção:\n");
                // CRUD do Leitor
                Console.WriteLine("1. Cadastrar Leitor");
                Console.WriteLine("2. Listar Leitores"); // Listar todos os leitores e seus respectivos livros
                Console.WriteLine("3. Editar Leitor");
                Console.WriteLine("4. Excluir Leitor");
                // CRUD do Livro
                Console.WriteLine("\n-----------------------------\n");
                Console.WriteLine("5. Adicionar Livro");
                Console.WriteLine("6. Editar Livro");
                Console.WriteLine("7. Remover Livro");
                Console.WriteLine("8. Doar Livro");
                Console.WriteLine("\n-----------------------------\n");
                // O que falta
                Console.WriteLine("9. Listar um leitor específico e seus respectivos livros");
                Console.WriteLine("10. Pesquisar por um livro específico e mostrar os dados do leitor\n");

                Console.WriteLine("0. Sair");

                var opcao = Console.ReadLine();

                // Executa a ação correspondente à opção escolhida
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
                        RemoverLivroLeitor();
                        break;
                    case "8":
                        DoarLivroLeitor();
                        break;
                    case "9":
                        ListarLeitorEspecifico();
                        break;
                    case "10":
                        PesquisarLivro();
                        break;
                    case "0":
                        return;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Opção inválida!");
                        Console.ResetColor();
                        break;
                }
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey();
                Console.ResetColor();
            }
        }

        // Método para criar um novo leitor
        static void CriarLeitor()
        {
            Console.Clear();
            Console.Write("Digite o nome do leitor: ");
            string nome = Console.ReadLine();
            Console.Write("Digite a idade do leitor: ");
            int idade = int.Parse(Console.ReadLine());
            Console.Write("Digite o CPF do leitor (11 dígitos): ");
            string cpf = Console.ReadLine();

            if (cpf.Length != 11 || !cpf.All(char.IsDigit))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("CPF inválido! Deve conter exatamente 11 NÚMEROS.");
                Console.ResetColor();
                return;
            }

            if (Leitor.CriarLeitor(nome, idade, cpf))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Leitor cadastrado com sucesso!");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Erro: Este CPF já está em uso.");
            }
            Console.ResetColor();
        }

        // Método para listar todos os leitores e seus respectivos livros
        static void ListarLeitores()
        {
            Console.Clear();
            var leitores = Leitor.ListarLeitores();
            if (leitores.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Nenhum leitor cadastrado!");
                Console.ResetColor();
                return;
            }

            Console.WriteLine("\nLista de Leitores:");
            foreach (var leitor in leitores)
            {
                Console.WriteLine($"Nome: {leitor.Nome}, Idade: {leitor.Idade}, CPF: {leitor.CPF}");
                Console.WriteLine("Livros:");
                foreach (var livro in leitor.LivrosLeitor)
                {
                    Console.WriteLine($"  - {livro.Titulo} por {livro.Escritor}");
                }
            }
        }

        // Método para listar um leitor específico e seus respectivos livros
        static void ListarLeitorEspecifico()
        {
            Console.Clear();
            Console.Write("Digite o CPF do leitor que deseja listar: ");
            string cpf = Console.ReadLine();
            Leitor leitor = Leitor.leitores.Find(l => l.CPF == cpf);
            if (leitor == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Leitor não encontrado!");
                Console.ResetColor();
                return;
            }

            Console.WriteLine($"Nome: {leitor.Nome}, Idade: {leitor.Idade}, CPF: {leitor.CPF}");
            Console.WriteLine("Livros:");
            foreach (var livro in leitor.LivrosLeitor)
            {
                Console.WriteLine($"  - {livro.Titulo} por {livro.Escritor}");
            }
        }

        // Método para pesquisar por um livro específico e mostrar os dados do leitor
        static void PesquisarLivro()
        {
            Console.Clear();
            Console.Write("Digite o título do livro que deseja pesquisar: ");
            string titulo = Console.ReadLine();
            foreach (var leitor in Leitor.leitores)
            {
                var livro = leitor.LivrosLeitor.Find(l => l.Titulo == titulo);
                if (livro != null)
                {
                    Console.WriteLine($"Livro encontrado!");
                    Console.WriteLine($"Título: {livro.Titulo}, Escritor: {livro.Escritor}");
                    Console.WriteLine($"Leitor: {leitor.Nome}, CPF: {leitor.CPF}");
                    return;
                }
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Livro não encontrado!");
            Console.ResetColor();
        }

        // Método para editar um leitor existente
        static void EditarLeitor()
        {
            Console.Clear();
            Console.Write("Digite o CPF do leitor que deseja editar: ");
            string cpf = Console.ReadLine();
            Leitor leitor = Leitor.leitores.Find(l => l.CPF == cpf);
            if (leitor == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Leitor não encontrado!");
                Console.ResetColor();
                return;
            }

            Console.Write("Digite o novo nome do leitor: ");
            string novoNome = Console.ReadLine();
            Console.Write("Digite a nova idade do leitor: ");
            int novaIdade = int.Parse(Console.ReadLine());

            if (leitor.EditarLeitor(novoNome, novaIdade))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Leitor editado com sucesso!");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Erro ao editar leitor.");
            }
            Console.ResetColor();
        }

        // Método para excluir um leitor
        static void ExcluirLeitor()
        {
            Console.Clear();
            Console.Write("Digite o CPF do leitor que deseja excluir: ");
            string cpf = Console.ReadLine();

            if (Leitor.ExcluirLeitor(cpf))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Leitor excluído com sucesso!");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Erro: Leitor não encontrado.");
            }
            Console.ResetColor();
        }

        // Método para adicionar um livro a um leitor
        static void AdicionarLivro()
        {
            Console.Clear();
            Console.Write("Digite o CPF do leitor que deseja adicionar um livro: ");
            string cpf = Console.ReadLine();
            Leitor leitor = Leitor.leitores.Find(l => l.CPF == cpf);
            if (leitor == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Leitor não encontrado!");
                Console.ResetColor();
                return;
            }

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
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Livro adicionado com sucesso!");
            Console.ResetColor();
        }

        // Método para editar um livro de um leitor
        static void EditarLivro()
        {
            Console.Clear();
            Console.Write("Digite o CPF do leitor que deseja editar um livro: ");
            string cpf = Console.ReadLine();
            Leitor leitor = Leitor.leitores.Find(l => l.CPF == cpf);
            if (leitor == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Leitor não encontrado!");
                Console.ResetColor();
                return;
            }

            Console.Write("Digite o título do livro que deseja editar: ");
            string titulo = Console.ReadLine();
            Livro livro = leitor.LivrosLeitor.Find(l => l.Titulo == titulo);
            if (livro == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Livro não encontrado!");
                Console.ResetColor();
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

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Livro editado com sucesso!");
            Console.ResetColor();
        }

        // Método para remover um livro de um leitor
        static void RemoverLivroLeitor()
        {
            Console.Clear();
            Console.Write("Digite o CPF do leitor que deseja remover um livro: ");
            string cpf = Console.ReadLine();
            Leitor leitor = Leitor.leitores.Find(l => l.CPF == cpf);
            if (leitor == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Leitor não encontrado!");
                Console.ResetColor();
                return;
            }

            Console.Write("Digite o título do livro que deseja remover: ");
            string titulo = Console.ReadLine();
            Livro livro = leitor.LivrosLeitor.Find(l => l.Titulo == titulo);
            if (livro == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Livro não encontrado!");
                Console.ResetColor();
                return;
            }

            if (leitor.RemoverLivro(livro))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Livro removido com sucesso!");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Livro não encontrado!");
            }
            Console.ResetColor();
        }

        // Método para doar um livro de um leitor para outro
        static void DoarLivroLeitor()
        {
            Console.Clear();
            Console.Write("Digite o CPF do leitor que deseja doar um livro: ");
            string cpf = Console.ReadLine();
            Leitor leitor = Leitor.leitores.Find(l => l.CPF == cpf);
            if (leitor == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Leitor não encontrado!");
                Console.ResetColor();
                return;
            }

            Console.Write("Digite o CPF do leitor que receberá o livro: ");
            string cpfDestino = Console.ReadLine();
            Leitor leitorDestino = Leitor.leitores.Find(l => l.CPF == cpfDestino);
            if (leitorDestino == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Leitor destino não encontrado!");
                Console.ResetColor();
                return;
            }

            Console.Write("Digite o título do livro que deseja doar: ");
            string titulo = Console.ReadLine();
            Livro livro = leitor.LivrosLeitor.Find(l => l.Titulo == titulo);
            if (livro == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Livro não encontrado!");
                Console.ResetColor();
                return;
            }

            if (leitor.DoarLivroLeitor(cpfDestino, titulo))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Livro doado com sucesso!");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Erro ao doar livro.");
            }
            Console.ResetColor();
        }
    }
}
