using System;
using System.Collections.Generic;
using System.Linq;

namespace Biblioteca
{
    internal class Leitor
    {
        internal string Nome { get; set; }
        internal int Idade { get; set; }
        internal string CPF { get; set; }
        internal List<Livro> LivrosLeitor { get; set; } = new List<Livro>();

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