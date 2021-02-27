using System;
using System.Collections.Generic;
using System.Text;

namespace Jorge
{
    class NormalClient
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public int Idade { get; set; }
        public double Saldo { get; set; }

        public NormalClient()
        {

        }
        public NormalClient(string nome, string cpf, int idade, double saldo)
        {
            Nome = nome;
            Cpf = cpf;
            Idade = idade;
            Saldo = saldo;
        }

        public virtual void MostraDados(string corDesing, string corLetra)
        {
            Program.Cor(corDesing);
            Console.WriteLine("   -------------------------");
            Program.Cor(corLetra);
            Console.Write("     Nome      ");
            Program.Cor(corDesing);
            Console.Write("|");
            Program.Cor(corLetra);
            Console.WriteLine("   {0}", this.Nome);
            Console.Write("     Idade     ");
            Program.Cor(corDesing);
            Console.Write("|");
            Program.Cor(corLetra);
            Console.WriteLine("   {0}", this.Idade);
            Console.Write("     CPF       ");
            Program.Cor(corDesing);
            Console.Write("|");
            Program.Cor(corLetra);
            Console.WriteLine("   {0}", this.Cpf);
            Console.Write("     Saldo     ");
            Program.Cor(corDesing);
            Console.Write("|");
            Program.Cor(corLetra);
            Console.WriteLine("   {0:c}", this.Saldo);

        }
        public virtual void DefineDados(string nome, string cpf, int idade, double saldo)
        {
            Nome =nome;
            Cpf = cpf;
            Idade = idade;
            Saldo = saldo;
        }

    }
}
