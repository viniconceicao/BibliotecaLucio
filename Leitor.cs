using System;
using System.Collections.Generic;
using System.Linq;

namespace Biblioteca
{
    public class Leitor
    {
        public string Nome { get; set; }
        public int Idade { get; set; }
        public string CPF { get; set; }
        public List<Livro> LivrosLeitor { get; set; } = new List<Livro>();

        public static List<Leitor> leitores = new List<Leitor>();

        public Leitor(string nome, int idade, string cpf)
        {
            Nome = nome;
            Idade = idade;
            CPF = cpf;
        }

        public static bool CriarLeitor(string nome, int idade, string cpf)
        {
            if (leitores.Any(l => l.CPF == cpf))
            {
                return false;
            }

            leitores.Add(new Leitor(nome, idade, cpf));
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
            var leitor = leitores.Find(l => l.CPF == cpf);
            if (leitor == null)
            {
                return false;
            }

            leitores.Remove(leitor);
            return true;
        }

        public void AdicionarLivro(Livro livro)
        {
            LivrosLeitor.Add(livro);
        }

        public bool RemoverLivro(Livro livro)
        {
            return LivrosLeitor.Remove(livro);
        }

        public bool DoarLivroLeitor(string cpfDestino, string titulo)
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