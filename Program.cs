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
                // Exibe o menu de opções para o usuário
                Console.WriteLine("\nEscolha uma opção:");
                Console.WriteLine("1. Criar Leitor");
                Console.WriteLine("2. Listar Leitores");
                Console.WriteLine("3. Editar Leitor");
                Console.WriteLine("4. Excluir Leitor");
                Console.WriteLine("5. Adicionar Livro");
                Console.WriteLine("6. Editar Livro");
                Console.WriteLine("7. Remover Livro");
                Console.WriteLine("8. Doar Livro");
                Console.WriteLine("9. Listar Todos os Leitores");
                Console.WriteLine("10. Listar Leitor Específico");
                Console.WriteLine("11. Pesquisar Livro Específico");
                Console.WriteLine("12. Pesquisar Leitor Específico");
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
                        ListarTodosLeitores();
                        break;
                    case "10":
                        ListarLeitorEspecifico();
                        break;
                    case "11":
                        PesquisarLivroEspecifico();
                        break;
                    case "12":
                        PesquisarLeitorEspecifico();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }
            }
        }

        // Método para criar um novo leitor
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

        // Método para listar todos os leitores
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

        // Método para editar um leitor existente
        static void EditarLeitor()
        {
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

        // Método para excluir um leitor
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

        // Método para adicionar um livro a um leitor
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

        // Método para editar um livro de um leitor
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

        // Método para remover um livro de um leitor
        static void RemoverLivroLeitor()
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
            Livro livro = leitor.LivrosLeitor.Find(l => l.Titulo == titulo);
            if (livro == null)
            {
                Console.WriteLine("Livro não encontrado!");
                return;
            }

            if (leitor.RemoverLivro(livro))
            {
                Console.WriteLine("Livro removido com sucesso!");
            }
            else
            {
                Console.WriteLine("Livro não encontrado!");
            }
        }

        // Método para doar um livro de um leitor para outro
        static void DoarLivroLeitor()
        {
            Console.Write("Digite o CPF do leitor que deseja doar um livro: ");
            string cpf = Console.ReadLine();
            Leitor leitor = Leitor.leitores.Find(l => l.CPF == cpf);
            if (leitor == null)
            {
                Console.WriteLine("Leitor não encontrado!");
                return;
            }

            Console.Write("Digite o CPF do leitor que receberá o livro: ");
            string cpfDestino = Console.ReadLine();
            Leitor leitorDestino = Leitor.leitores.Find(l => l.CPF == cpfDestino);
            if (leitorDestino == null)
            {
                Console.WriteLine("Leitor destino não encontrado!");
                return;
            }

            Console.Write("Digite o título do livro que deseja doar: ");
            string titulo = Console.ReadLine();
            Livro livro = leitor.LivrosLeitor.Find(l => l.Titulo == titulo);
            if (livro == null)
            {
                Console.WriteLine("Livro não encontrado!");
                return;
            }

            if (leitor.DoarLivroLeitor(cpfDestino, titulo))
            {
                Console.WriteLine("Livro doado com sucesso!");
            }
            else
            {
                Console.WriteLine("Erro ao doar livro.");
            }
        }

        // Método para listar todos os leitores e seus respectivos livros
        static void ListarTodosLeitores()
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
                foreach (var livro in leitor.LivrosLeitor)
                {
                    Console.WriteLine($"Título: {livro.Titulo}, Escritor: {livro.Escritor}, Editora: {livro.Editora}");
                }
            }
        }

        // Método para listar um leitor específico e seus respectivos livros
        static void ListarLeitorEspecifico()
        {
            Console.Write("Digite o CPF do leitor que deseja listar: ");
            string cpf = Console.ReadLine();
            Leitor leitor = Leitor.leitores.Find(l => l.CPF == cpf);
            if (leitor == null)
            {
                Console.WriteLine("Leitor não encontrado!");
                return;
            }

            Console.WriteLine($"Nome: {leitor.Nome}, Idade: {leitor.Idade}, CPF: {leitor.CPF}");
            foreach (var livro in leitor.LivrosLeitor)
            {
                Console.WriteLine($"Título: {livro.Titulo}, Escritor: {livro.Escritor}, Editora: {livro.Editora}");
            }
        }

        // Método para pesquisar um livro específico e mostrar os dados do leitor
        static void PesquisarLivroEspecifico()
        {
            Console.Write("Digite o título do livro que deseja pesquisar: ");
            string titulo = Console.ReadLine();
            Leitor leitor = Leitor.leitores.Find(l => l.LivrosLeitor.Exists(l => l.Titulo == titulo));
            if (leitor == null)
            {
                Console.WriteLine("Livro não encontrado!");
                return;
            }

            Console.WriteLine($"Nome: {leitor.Nome}, Idade: {leitor.Idade}, CPF: {leitor.CPF}");
            foreach (var livro in leitor.LivrosLeitor)
            {
                if (livro.Titulo == titulo)
                {
                    Console.WriteLine($"Título: {livro.Titulo}, Escritor: {livro.Escritor}, Editora: {livro.Editora}");
                }
            }
        }

        // Método para pesquisar um leitor específico pelo CPF
        static void PesquisarLeitorEspecifico()
        {
            Console.Write("Digite o CPF do leitor que deseja pesquisar: ");
            string cpf = Console.ReadLine();
            Leitor leitor = Leitor.leitores.Find(l => l.CPF == cpf);
            if (leitor == null)
            {
                Console.WriteLine("Leitor não encontrado!");
                return;
            }

            Console.WriteLine($"Nome: {leitor.Nome}, Idade: {leitor.Idade}, CPF: {leitor.CPF}");
            foreach (var livro in leitor.LivrosLeitor)
            {
                Console.WriteLine($"Título: {livro.Titulo}, Escritor: {livro.Escritor}, Editora: {livro.Editora}");
            }
        }
    }
}

// O programa deve possuir um menu que permita ao usuário escolher a operação desejada, como:  
// • CRUD de leitor (cadastrar, listar, editar, excluir)  
// • Incluir livros para um leitor  
// • Editar um livro específico de um leitor  
// • Remover um livro (por exemplo, em caso de perda)  
// • Doar um livro para outro leitor  
// • Listar todos os leitores e seus respectivos livros  
// • Listar um leitor específico e seus respectivos livros  
// • Pesquisar por um livro específico e mostrar os dados do leitor associado  

// Requisitos:  
// • As classes devem utilizar construtores.  
// • Os dados cadastrados devem ser digitados pelo usuário.  
// • O leitor deve possuir um atributo CPF, garantindo um identificador único.  
// • No cadastro de um novo leitor, deve-se validar se o CPF informado já está em uso (ver método Exists de List).  
// • A busca pelo leitor deve ser realizada através do seu CPF.  
// • O usuário deve poder cadastrar quantos leitores e livros desejar.  
