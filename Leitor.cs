namespace Biblioteca
{
    public class Leitor
    {
        public string Nome { get; set; }
        public int Idade { get; set; }
        public string CPF { get; set; }
        public List<Livro> LivrosLeitor { get; set; } = new List<Livro>();

        public Leitor(string nome, int idade, string cpf)
        {
            Nome = nome;
            Idade = idade;
            CPF = cpf;
        }

        public void AdicionarLivro(Livro livro)
        {
            LivrosLeitor.Add(livro);
        }

        public void RemoverLivro(Livro livro)
        {
            LivrosLeitor.Remove(livro);
        }

        public void DoarLivro(Livro livroDoado, Leitor leitorDestino)
        {
            leitorDestino.LivrosLeitor.Add(livroDoado);
            LivrosLeitor.Remove(livroDoado);
        }

        public static List<Leitor> leitores = new List<Leitor>();

        public static bool CriarLeitor(string nome, int idade, string cpf)
        {
            if (leitores.Exists(l => l.CPF == cpf))
            {
                return false;
            }

            var novoLeitor = new Leitor(nome, idade, cpf);
            leitores.Add(novoLeitor);
            return true;
        }

        public static List<Leitor> ListarLeitores()
        {
            return leitores;
        }

        public bool EditarLeitor(string novoNome, int novaIdade)
        {
            Nome = novoNome;
            Idade = novaIdade;
            return true;
        }

        public static bool ExcluirLeitor(string cpf)
        {
            Leitor leitor = leitores.Find(l => l.CPF == cpf);
            if (leitor != null)
            {
                leitores.Remove(leitor);
                return true;
            }
            return false;
        }

        public List<Livro> ListarLivrosLeitor()
        {
            return LivrosLeitor;
        }

        public bool EditarLivroLeitor(string tituloLivro, string novoTitulo, string novoEscritor, string novaEditora)
        {
            Livro livro = LivrosLeitor.Find(l => l.Titulo == tituloLivro);
            if (livro != null)
            {
                livro.Titulo = novoTitulo;
                livro.Escritor = novoEscritor;
                livro.Editora = novaEditora;
                return true;
            }
            return false;
        }

        public bool RemoverLivroLeitor(string tituloLivro)
        {
            Livro livro = LivrosLeitor.Find(l => l.Titulo == tituloLivro);
            if (livro != null)
            {
                LivrosLeitor.Remove(livro);
                return true;
            }
            return false;
        }

        public bool DoarLivroLeitor(string cpfDestino, string tituloLivro)
        {
            Leitor leitorDestino = leitores.Find(l => l.CPF == cpfDestino);
            Livro livro = LivrosLeitor.Find(l => l.Titulo == tituloLivro);
            if (leitorDestino != null && livro != null)
            {
                leitorDestino.LivrosLeitor.Add(livro);
                LivrosLeitor.Remove(livro);
                return true;
            }
            return false;
        }

        public static Leitor ListarLeitorLivros(string cpf)
        {
            return leitores.Find(l => l.CPF == cpf);
        }

        public static Leitor PesquisarLivroLeitor(string tituloLivro)
        {
            foreach (Leitor leitor in leitores)
            {
                Livro livro = leitor.LivrosLeitor.Find(l => l.Titulo == tituloLivro);
                if (livro != null)
                {
                    return leitor;
                }
            }
            return null;
        }
    }
}
