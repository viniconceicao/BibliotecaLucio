using System;
using System.Collections.Generic;
using System.Linq;

namespace Biblioteca
{
    internal class Leitor
    {
        internal string Nome
        {
            get => _nome;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Nome não pode ser nulo ou vazio.");
                }
                _nome = value.Trim();
            }
        }
        internal int Idade { get; set; }
        internal string CPF
        {
            get => _cpf;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("CPF não pode ser nulo ou vazio.");
                }
                _cpf = value.Trim();
            }
        }
        internal List<Livro> LivrosLeitor { get; set; } = new List<Livro>();

        private string _nome;
        private string _cpf;

        internal static List<Leitor> leitores = new List<Leitor>();

        internal Leitor(string nome, int idade, string cpf)
        {
            Nome = nome;
            Idade = idade;
            CPF = cpf;
        }

        internal static bool CriarLeitor(string nome, int idade, string cpf)
        {
            if (leitores.Any(l => l.CPF == cpf))
            {
                return false;
            }

            leitores.Add(new Leitor(nome, idade, cpf));
            return true;
        }

        internal static List<Leitor> ListarLeitores()
        {
            return leitores;
        }

        internal bool EditarLeitor(string novoNome, int novaIdade)
        {
            Nome = novoNome;
            Idade = novaIdade;
            return true;
        }

        internal static bool ExcluirLeitor(string cpf)
        {
            var leitor = leitores.Find(l => l.CPF == cpf);
            if (leitor == null)
            {
                return false;
            }

            leitores.Remove(leitor);
            return true;
        }

        internal void AdicionarLivro(Livro livro)
        {
            LivrosLeitor.Add(livro);
        }

        internal bool RemoverLivro(Livro livro)
        {
            return LivrosLeitor.Remove(livro);
        }

        internal bool DoarLivroLeitor(string cpfDestino, string titulo)
        {
            var leitorDestino = leitores.Find(l => l.CPF == cpfDestino);
            if (leitorDestino == null)
            {
                return false;
            }

            var livro = LivrosLeitor.Find(l => l.Titulo == titulo);
            if (livro == null)
            {
                return false;
            }

            LivrosLeitor.Remove(livro);
            leitorDestino.AdicionarLivro(livro);
            return true;
        }
    }
}