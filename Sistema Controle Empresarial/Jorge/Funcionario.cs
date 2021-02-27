using System;
using System.Collections.Generic;
using System.Text;

namespace Jorge
{
    class Funcionario : NormalClient
    {
        public double SalarioPorHora { get; set; }
        public string Cargo { get; set; }

        public Funcionario()
        {

        }
        public Funcionario(double salarioPorHora, string cargo, string nome, string cpf, int idade, double saldo) : base(nome, cpf, idade, saldo)
        {
            SalarioPorHora = salarioPorHora;
            Cargo = cargo;
        }

        public override void MostraDados(string corDesing, string corLetra)
        {
            base.MostraDados(corDesing, corLetra);
        }
        public override void DefineDados(string nome, string cpf, int idade, double saldo)
        {
            base.DefineDados(nome, cpf, idade, saldo);
        }

        public void MostraCargoSalario(string corDesing, string corLetra)
        {
            Program.Cor(corLetra);
            Console.Write("     Cargo     ");
            Program.Cor(corDesing);
            Console.Write("|");
            Program.Cor(corLetra);
            Console.WriteLine("   {0}", Cargo);

            Program.Cor(corLetra);
            Console.Write("     Salario   ");
            Program.Cor(corDesing);
            Console.Write("|");
            Program.Cor(corLetra);
            Console.WriteLine("   {0:c}", SalarioPorHora);

        }
        public void DefineCargoSalario(string cargo, double salarioHora)
        {
            Cargo = cargo;
            SalarioPorHora = salarioHora;
        }

        public double BaterPontoDia(int hrEntrada, int hrSaida)
        {
            int diaria = hrSaida - hrEntrada;
            double a = this.SalarioPorHora * diaria;
            a += this.Saldo;
            return a;
        }
        public double BaterPontoMes()
        {
            Random ran = new Random();
            int diaria;
            double a;
            for (int i = 0; i < 30; i++)
            {
                diaria = ran.Next(7, 10);
                a = this.SalarioPorHora * diaria;
                this.Saldo += a;
            }
            return this.Saldo;
        }

    }
}
