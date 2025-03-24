namespace Biblioteca
{
    internal class Livro
    {
        internal string Titulo
        {
            get => _titulo;
            set => _titulo = value?.Trim();
        }
        internal string SubTitulo
        {
            get => _subTitulo;
            set => _subTitulo = value?.Trim();
        }
        internal string Escritor
        {
            get => _escritor;
            set => _escritor = value?.Trim();
        }
        internal string Editora
        {
            get => _editora;
            set => _editora = value?.Trim();
        }
        internal string Genero
        {
            get => _genero;
            set => _genero = value?.Trim();
        }
        internal int AnoPublicacao { get; set; }
        internal string TipoDaCapa
        {
            get => _tipoDaCapa;
            set => _tipoDaCapa = value?.Trim();
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