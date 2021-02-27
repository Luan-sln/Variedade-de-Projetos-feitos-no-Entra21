using System;
using System.Collections.Generic;
using System.Text;

namespace Jorge
{
    class SocialClient : NormalClient
    {
        public double QtdAcoes { get; set; }
        public SocialClient()
        {

        }
        public SocialClient(double qtdAcoes, string nome, string cpf, int idade, double saldo) : base(nome, cpf, idade, saldo)
        {
            qtdAcoes /= 100;
            QtdAcoes = qtdAcoes;
        }

        public override void MostraDados(string corDesing, string corLetra)
        {
            base.MostraDados(corDesing, corLetra);
            
        }
        public virtual void MostraAcoes(string corDesing, string corLetra)
        {
            Program.Cor(corLetra);
            Console.Write("     Qtd Ações ");
            Program.Cor(corDesing);
            Console.Write("|");
            Program.Cor(corLetra);
            if (QtdAcoes < 1)
            {
                Console.WriteLine("   0{0:#.##}%", QtdAcoes);
            }
            else
            {
                Console.WriteLine("   {0:#.##}%", QtdAcoes);

            }
        }

        public override void DefineDados(string nome, string cpf, int idade, double saldo)
        {
            base.DefineDados(nome, cpf, idade, saldo);
        }
        public virtual void DefineAcoes(double acoes)
        {
            acoes/=100;
            QtdAcoes = acoes;
        }

    }
}
