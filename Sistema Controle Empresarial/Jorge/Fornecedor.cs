using System;
using System.Collections.Generic;
using System.Text;

namespace Jorge
{
    class Fornecedor : Funcionario
    {
        public string Cnpj { get; set; }
        public int TipoProduto { get; set; }
        public int QtdMensal { get; set; }
        public Fornecedor(string nomeEmpresa, string cnpj, int tipoProduto, int qtdMensal)
        {
            Nome = nomeEmpresa;
            Cnpj = cnpj;
            TipoProduto = tipoProduto;
            QtdMensal = qtdMensal;
        }
        public Fornecedor()
        {

        }

        public override void MostraDados(string corDesing, string corLetra)
        {
            Program.Cor(corDesing);
            Console.WriteLine("   -------------------------");
            Program.Cor(corLetra);
            Console.Write("     Nome        ");
            Program.Cor(corDesing);
            Console.Write("|");
            Program.Cor(corLetra);
            Console.WriteLine("   {0}", this.Nome);
            Console.Write("     CNPJ        ");
            Program.Cor(corDesing);
            Console.Write("|");
            Program.Cor(corLetra);
            Console.WriteLine("   {0}", this.Cnpj);
            Console.Write("     Tipo Prod.  ");
            Program.Cor(corDesing);
            Console.Write("|");
            Program.Cor(corLetra);
            Console.WriteLine("   {0}", this.TipoProduto);
        }

        public void MostraQtdMensal(string corDesing, string corLetra)
        {
            Program.Cor(corLetra);
            Console.Write("     Qtd. Mensal ");
            Program.Cor(corDesing);
            Console.Write("|");
            Program.Cor(corLetra);
            Console.WriteLine("   {0}", QtdMensal);
        }
        public void DefineQtdMensal(int quantidade)
        {
            QtdMensal = quantidade;
        }
    }
}
