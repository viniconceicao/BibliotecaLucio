namespace Biblioteca
{
    internal class Livro
    {
        internal string Isbn
        {
            get => _isbn;
            init
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("ISBN não pode ser nulo ou vazio.");
                }

                // Validação básica para o formato do ISBN (10 ou 13 caracteres)
                string isbn = value.Trim();
                if (isbn.Length != 10 && isbn.Length != 13)
                {
                    throw new ArgumentException("ISBN deve ter 10 ou 13 caracteres.");
                }

                _isbn = isbn;
            }
        }

        private string _isbn;
        internal string Titulo
        {
            get => _titulo;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Título não pode ser nulo ou vazio.");
                }
                _titulo = value.Trim();
            }
        }
        internal string SubTitulo
        {
            get => _subTitulo;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Subtítulo não pode ser nulo ou vazio.");
                }
                _subTitulo = value.Trim();
            }
        }
        internal string Escritor
        {
            get => _escritor;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Escritor não pode ser nulo ou vazio.");
                }
                _escritor = value.Trim();
            }
        }
        internal string Editora
        {
            get => _editora;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Editora não pode ser nula ou vazia.");
                }
                _editora = value.Trim();
            }
        }
        internal string Genero
        {
            get => _genero;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Gênero não pode ser nulo ou vazio.");
                }
                _genero = value.Trim();
            }
        }
        internal int AnoPublicacao
        {
            get => _anoPublicacao;
            set
            {
                int anoAtual = DateTime.Now.Year;
                if (value < 1970 || value > anoAtual)
                {
                    throw new ArgumentException($"Ano de publicação deve estar entre 1970 e {anoAtual}.");
                }
                _anoPublicacao = value;
            }
        }
        internal string TipoDaCapa
        {
            get => _tipoDaCapa;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Tipo da capa não pode ser nulo ou vazio.");
                }
                _tipoDaCapa = value.Trim();
            }
        }
        internal int NumeroDePaginas
        {
            get => _numeroDePaginas;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Número de páginas não pode ser negativo.");
                }
                _numeroDePaginas = value;
            }
        }

        private string _titulo;
        private string _subTitulo;
        private string _escritor;
        private string _editora;
        private string _genero;
        private string _tipoDaCapa;
        private int _anoPublicacao;
        private int _numeroDePaginas;

        internal Livro(string isbn, string titulo, string subTitulo, string escritor, string editora, string genero, int anoPublicacao, string tipoDaCapa, int numeroDePaginas)
        {
            if (string.IsNullOrWhiteSpace(isbn))
            {
                throw new ArgumentException("ISBN não pode ser nulo ou vazio.");
            }

            Isbn = isbn.Trim();
            Titulo = titulo;
            SubTitulo = subTitulo;
            Escritor = escritor;
            Editora = editora;
            Genero = genero;
            AnoPublicacao = anoPublicacao;
            TipoDaCapa = tipoDaCapa;
            NumeroDePaginas = numeroDePaginas;
        }
    }
}