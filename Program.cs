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
                Console.WriteLine("2. Listar Leitores");
                Console.WriteLine("3. Editar Leitor");
                Console.WriteLine("4. Excluir Leitor");
                // CRUD do Livro
                Console.WriteLine("\n-----------------------------\n");
                Console.WriteLine("5. Adicionar Livro no Leitor");
                Console.WriteLine("6. Editar Livro no Leitor");
                Console.WriteLine("7. Remover Livro no Leitor");
                Console.WriteLine("8. Doar Livro ");
                Console.WriteLine("\n-----------------------------\n");
                // Outras funcionalidades
                Console.WriteLine("9. Listar um leitor específico e seus respectivos livros");
                Console.WriteLine("10. Pesquisar por um livro específico e mostrar os dados do leitor\n");
                Console.WriteLine("-----------------------------\n");
                Console.WriteLine("0. Sair");
                Console.WriteLine("\n-----------------------------\n");
                Console.WriteLine("Escolha uma opção: ");

                var opcao = Console.ReadLine(); // Lê a opção escolhida pelo usuário

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

        // Função para validar CPF
        static bool ValidarCPF(string cpf)
        {
            return cpf.Length == 11 && cpf.All(char.IsDigit);
        }

        // Método para criar um novo leitor
        static void CriarLeitor()
        {
            Console.Clear();
            Console.Write("Digite o nome do leitor ou '0' para sair: ");
            string nome = Console.ReadLine().Trim();
            if (nome == "0") return;

            Console.Write("Digite a idade do leitor ou '0' para sair: ");
            string idadeInput = Console.ReadLine().Trim();
            if (idadeInput == "0") return;
            int idade = int.Parse(idadeInput);

            string cpf;
            do
            {
            Console.Write("Digite o CPF do leitor (11 dígitos) ou '0' para sair: ");
            cpf = Console.ReadLine().Trim();
            if (cpf == "0") return;

            if (!ValidarCPF(cpf)) // Verifica se o CPF é válido
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("CPF inválido! Deve conter exatamente 11 NÚMEROS.");
                Console.ResetColor();
            }
            } while (!ValidarCPF(cpf));

            if (Leitor.CriarLeitor(nome, idade, cpf)) // Cria o leitor
            {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Leitor cadastrado com sucesso!");
            }
            else
            {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Erro: Este CPF já está em uso."); // Mensagem de erro caso o CPF já esteja em uso
            }
            Console.ResetColor();
        }

        // Método para listar todos os leitores e seus respectivos livros
        static void ListarLeitores() // 
        {
            Console.Clear();
            var leitores = Leitor.ListarLeitores(); // Lista todos os leitores
            if (leitores.Count == 0) // Verificando se existe leitores cadastrados
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Nenhum leitor cadastrado!");
                Console.ResetColor();
                return;
            }

            Console.WriteLine("\nLista de Leitores:");
            foreach (var leitor in leitores) // Exibe os dados de cada leitor
            {
                Console.WriteLine($"-----------------------------");
                Console.WriteLine($"Nome: {leitor.Nome}, Idade: {leitor.Idade}, CPF: {leitor.CPF}");
                Console.WriteLine("Livros:");
                foreach (var livro in leitor.LivrosLeitor) // Exibe os livros de cada leitor
                {
                    Console.WriteLine($"  - {livro.Titulo} por {livro.Escritor}");
                }
            }
        }

        // Método para listar um leitor específico e seus respectivos livros
        static void ListarLeitorEspecifico()
        {
            Console.Clear();
            string cpf;
            Leitor leitor = null;
            do
            {
            Console.Write("Digite o CPF do leitor que deseja listar ou '0' para sair: ");
            cpf = Console.ReadLine().Trim();
            if (cpf == "0") return;

            if (!ValidarCPF(cpf)) // Verifica se o CPF é válido
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("CPF inválido! Deve conter exatamente 11 NÚMEROS.");
                Console.ResetColor();
            }
            else
            {
                leitor = Leitor.leitores.Find(l => l.CPF == cpf); // Procura o leitor pelo CPF
                if (leitor == null) // Verifica se o leitor foi encontrado
                {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Leitor não encontrado!");
                Console.ResetColor();
                }
            }
            } while (!ValidarCPF(cpf) || leitor == null);

            Console.WriteLine($"\n");
            Console.WriteLine($"Nome: {leitor.Nome}, Idade: {leitor.Idade}, CPF: {leitor.CPF}");
            Console.WriteLine("Livros:");
            foreach (var livro in leitor.LivrosLeitor) // Exibe os livros do leitor
            {
            Console.WriteLine($"  - {livro.Titulo} por {livro.Escritor}");
            }
        }

        // Método para pesquisar por um livro específico e mostrar os dados do leitor
        static void PesquisarLivro()
        {
            Console.Clear();
            string titulo;
            bool livroEncontrado = false;
            do
            {
            Console.Write("Digite o título do livro que deseja pesquisar ou '0' para sair: ");
            titulo = Console.ReadLine().Trim();
            if (titulo == "0") return;

            foreach (var leitor in Leitor.leitores) // Procura o livro em todos os leitores
            {
                var livro = leitor.LivrosLeitor.Find(l => l.Titulo == titulo); // Procura o livro no leitor
                if (livro != null)
                {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\nLivro encontrado!");
                Console.ResetColor();
                Console.WriteLine($"-----------------------------");
                Console.WriteLine($"Título: {livro.Titulo}, Escritor: {livro.Escritor}");
                Console.WriteLine($"Leitor: {leitor.Nome}, CPF: {leitor.CPF}");
                Console.WriteLine($"-----------------------------");
                livroEncontrado = true;
                }
            }

            if (!livroEncontrado)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Livro não encontrado! Por favor, insira um título válido.");
                Console.ResetColor();
            }
            } while (!livroEncontrado);
        }

        // Método para editar um leitor existente
        static void EditarLeitor()
        {
            Console.Clear();
            Leitor leitor = null;
            string cpf;
            do
            {
            Console.Write("Digite o CPF do leitor que deseja editar ou '0' para sair: ");
            cpf = Console.ReadLine().Trim();
            if (cpf == "0") return;

            leitor = Leitor.leitores.Find(l => l.CPF == cpf); // Procura o leitor pelo CPF
            if (leitor == null) // Verifica se o leitor foi encontrado
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Leitor não encontrado! Digite um CPF que existe.");
                Console.ResetColor();
            }
            } while (leitor == null);

            Console.Write("Digite o novo nome do leitor ou '0' para sair: ");
            string novoNome = Console.ReadLine().Trim();
            if (novoNome == "0") return;

            string novaIdadeInput;
            int novaIdade;
            do
            {
            Console.Write("Digite a nova idade do leitor ou '0' para sair: ");
            novaIdadeInput = Console.ReadLine().Trim();
            if (novaIdadeInput == "0") return;
            } while (!int.TryParse(novaIdadeInput, out novaIdade));

            if (leitor.EditarLeitor(novoNome, novaIdade)) // Edita o leitor
            {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Leitor editado com sucesso!");
            }
            else // Mensagem de erro caso o CPF já esteja em uso
            {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Erro ao editar leitor.");
            }
            Console.ResetColor();
        }

        // Método para excluir um leitor
        static void ExcluirLeitor()
        {
            string cpf;
            do
            {
            Console.Clear();
            Console.Write("Digite o CPF do leitor que deseja excluir ou '0' para sair: ");
            cpf = Console.ReadLine().Trim();
            if (cpf == "0") return;

            if (!ValidarCPF(cpf)) // Verifica se o CPF é válido
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("CPF inválido! Deve conter exatamente 11 NÚMEROS.");
                Console.ResetColor();
            }
            } while (!ValidarCPF(cpf));

            if (Leitor.ExcluirLeitor(cpf)) // Exclui o leitor
            {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Leitor excluído com sucesso!");
            }
            else // Mensagem de erro caso o leitor não seja encontrado
            {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Erro: Leitor não encontrado. Por favor, insira um CPF cadastrado.");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Pressione qualquer tecla para tentar novamente...");
            Console.ReadKey();
            Console.ResetColor();
            ExcluirLeitor(); // Chama o método novamente para tentar excluir outro leitor
            }
            Console.ResetColor();
        }

        // Método para adicionar um livro a um leitor
        static void AdicionarLivro()
        {
            Console.Clear();
            string cpf;
            Leitor leitor = null;
            do
            {
            Console.Write("Digite o CPF do leitor que deseja adicionar um livro ou '0' para sair: ");
            cpf = Console.ReadLine().Trim();
            if (cpf == "0") return;

            if (!ValidarCPF(cpf)) // Verifica se o CPF é válido
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("CPF inválido! Deve conter exatamente 11 NÚMEROS.");
                Console.ResetColor();
            }
            else
            {
                leitor = Leitor.leitores.Find(l => l.CPF == cpf); // Procura o leitor pelo CPF
                if (leitor == null) // Verifica se o leitor foi encontrado
                {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Leitor não encontrado!");
                Console.ResetColor();
                }
            }
            } while (!ValidarCPF(cpf) || leitor == null);

            Console.Write("Digite o título do livro: ");
            string titulo = Console.ReadLine().Trim();
            Console.Write("Digite o subtitulo do livro: ");
            string subTitulo = Console.ReadLine().Trim();
            Console.Write("Digite o escritor do livro: ");
            string escritor = Console.ReadLine().Trim();
            Console.Write("Digite a editora do livro: ");
            string editora = Console.ReadLine().Trim();
            Console.Write("Digite o gênero do livro: ");
            string genero = Console.ReadLine().Trim();
            Console.Write("Digite o ano de publicação do livro: ");
            int anoPublicacao = int.Parse(Console.ReadLine().Trim());
            Console.Write("Digite o tipo da capa do livro: ");
            string tipoDaCapa = Console.ReadLine().Trim();
            Console.Write("Digite o número de páginas do livro: ");
            int numeroDePaginas = int.Parse(Console.ReadLine().Trim());

            Livro livro = new Livro(titulo, subTitulo, escritor, editora, genero, anoPublicacao, tipoDaCapa, numeroDePaginas); // Cria um novo livro
            leitor.AdicionarLivro(livro); // Adiciona o livro ao leitor
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Livro adicionado com sucesso!");
            Console.ResetColor();
        }

        // Método para editar um livro de um leitor
        static void EditarLivro()
        {
            Console.Clear();
            string cpf;
            Leitor leitor = null;
            do
            {
            Console.Write("Digite o CPF do leitor que deseja editar um livro ou '0' para sair: ");
            cpf = Console.ReadLine().Trim();
            if (cpf == "0") return;

            if (!ValidarCPF(cpf)) // Verifica se o CPF é válido
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("CPF inválido! Deve conter exatamente 11 NÚMEROS.");
                Console.ResetColor();
            }
            else
            {
                leitor = Leitor.leitores.Find(l => l.CPF == cpf); // Procura o leitor pelo CPF
                if (leitor == null) // Verifica se o leitor foi encontrado
                {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Leitor não encontrado!");
                Console.ResetColor();
                }
            }
            } while (!ValidarCPF(cpf) || leitor == null);

            Console.Write("Digite o título do livro que deseja editar: ");
            string titulo = Console.ReadLine().Trim();
            Livro livro = leitor.LivrosLeitor.Find(l => l.Titulo == titulo);
            if (livro == null) // Verifica se o livro foi encontrado
            {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Livro não encontrado!");
            Console.ResetColor();
            return;
            }

            Console.Write("Digite o novo título do livro: ");
            string novoTitulo = Console.ReadLine().Trim();
            Console.Write("Digite o novo subtitulo do livro: ");
            string novoSubTitulo = Console.ReadLine().Trim();
            Console.Write("Digite o novo escritor do livro: ");
            string novoEscritor = Console.ReadLine().Trim();
            Console.Write("Digite a nova editora do livro: ");
            string novaEditora = Console.ReadLine().Trim();
            Console.Write("Digite o novo gênero do livro: ");
            string novoGenero = Console.ReadLine().Trim();
            Console.Write("Digite o novo ano de publicação do livro: ");
            int novoAnoPublicacao = int.Parse(Console.ReadLine().Trim());
            Console.Write("Digite o novo tipo da capa do livro: ");
            string novoTipoDaCapa = Console.ReadLine().Trim();
            Console.Write("Digite o novo número de páginas do livro: ");
            int novoNumeroDePaginas = int.Parse(Console.ReadLine().Trim());

            // Edita o livro recebendo os novos dados com váriavel recebendo o novo valor
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
            string cpf;
            Leitor leitor = null;
            do
            {
            Console.Write("Digite o CPF do leitor que deseja remover um livro ou '0' para sair: ");
            cpf = Console.ReadLine().Trim();
            if (cpf == "0") return;

            if (!ValidarCPF(cpf)) // Verifica se o CPF é válido
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("CPF inválido! Deve conter exatamente 11 NÚMEROS.");
                Console.ResetColor();
            }
            else
            {
                leitor = Leitor.leitores.Find(l => l.CPF == cpf); // Procura o leitor pelo CPF
                if (leitor == null) // Verifica se o leitor foi encontrado
                {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Leitor não encontrado!");
                Console.ResetColor();
                }
            }
            } while (!ValidarCPF(cpf) || leitor == null);

            Console.Write("Digite o título do livro que deseja remover: ");
            string titulo = Console.ReadLine().Trim();
            Livro livro = leitor.LivrosLeitor.Find(l => l.Titulo == titulo); // Procura o livro no leitor
            if (livro == null) // Verifica se o livro foi encontrado
            {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Livro não encontrado!");
            Console.ResetColor();
            return;
            }

            if (leitor.RemoverLivro(livro)) // Remove o livro do leitor
            {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Livro removido com sucesso!");
            }
            else // Mensagem de erro caso o livro não seja encontrado
            {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Erro ao remover livro.");
            }
            Console.ResetColor();
        }

        // Método para doar um livro de um leitor para outro
        static void DoarLivroLeitor()
        {
            Console.Clear();
            string cpf;
            Leitor leitor = null;
            do
            {
            Console.Write("Digite o CPF do leitor que deseja doar um livro ou '0' para sair: ");
            cpf = Console.ReadLine().Trim();
            if (cpf == "0") return;

            if (!ValidarCPF(cpf)) // Verifica se o CPF é válido
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("CPF inválido! Deve conter exatamente 11 NÚMEROS.");
                Console.ResetColor();
            }
            else
            {
                leitor = Leitor.leitores.Find(l => l.CPF == cpf); // Procura o leitor pelo CPF
                if (leitor == null) // Verifica se o leitor foi encontrado
                {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Leitor não encontrado!");
                Console.ResetColor();
                }
            }
            } while (!ValidarCPF(cpf) || leitor == null);

            string cpfDestino;
            Leitor leitorDestino = null;
            do
            {
            Console.Write("Digite o CPF do leitor que receberá o livro ou '0' para sair: ");
            cpfDestino = Console.ReadLine().Trim();
            if (cpfDestino == "0") return;

            if (!ValidarCPF(cpfDestino)) // Verifica se o CPF é válido
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("CPF inválido! Deve conter exatamente 11 NÚMEROS.");
                Console.ResetColor();
            }
            else
            {
                leitorDestino = Leitor.leitores.Find(l => l.CPF == cpfDestino); // Procura o leitor destino pelo CPF
                if (leitorDestino == null) // Verifica se o leitor destino foi encontrado
                {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Leitor destino não encontrado!");
                Console.ResetColor();
                }
            }
            } while (!ValidarCPF(cpfDestino) || leitorDestino == null);

            Console.Write("Digite o título do livro que deseja doar: ");
            string titulo = Console.ReadLine().Trim();
            Livro livro = leitor.LivrosLeitor.Find(l => l.Titulo == titulo);
            if (livro == null) // Verifica se o livro foi encontrado
            {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Livro não encontrado!");
            Console.ResetColor();
            return;
            }

            if (leitor.DoarLivroLeitor(cpfDestino, titulo)) // Doa o livro
            {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Livro doado com sucesso!");
            }
            else // Mensagem de erro caso o livro não seja encontrado
            {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Erro ao doar livro.");
            }
            Console.ResetColor();
        }
    }
}

/* Alunos:
     - Alisson Rafael da Cruz Velho
     - Marcos Vinicius Arruda Vandresen
     - Rodrigo Vaisam Bastos
     - Vinicius de Liz da Conceição
 */