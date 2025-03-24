namespace Biblioteca
{
    internal class Livro
    {
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
        internal int AnoPublicacao { get; set; }
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
        internal int NumeroDePaginas { get; set; }

        private string _titulo;
        private string _subTitulo;
        private string _escritor;
        private string _editora;
        private string _genero;
        private string _tipoDaCapa;

        internal Livro(string titulo, string subTitulo, string escritor, string editora, string genero, int anoPublicacao, string tipoDaCapa, int numeroDePaginas)
        {
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