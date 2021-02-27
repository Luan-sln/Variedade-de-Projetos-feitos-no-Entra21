using System;
using System.Collections.Generic;
using System.Threading;

namespace Jorge
{
    class Program
    {
        static void Main(string[] args)
        {
            List<NormalClient> nList = new List<NormalClient>();
            List<SocialClient> sList = new List<SocialClient>();
            List<Funcionario> fList = new List<Funcionario>();
            List<Fornecedor> eList = new List<Fornecedor>();
            for (int i = 0; i < 5; i++)
            {
                NormalClient nCli = new NormalClient();
                string cpf = Gerador.Cpf();
                nCli.DefineDados(Gerador.NomePessoa(), VerifCpf(cpf, nList, sList, fList, eList), Gerador.Idade(), Gerador.Saldo());
                nList.Add(new NormalClient(Gerador.NomePessoa(), VerifCpf(cpf, nList, sList, fList, eList), Gerador.Idade(), Gerador.Saldo()));

                //Gera Funcionarios
                Funcionario proletario = new Funcionario();
                Random ran = new Random();
                string cpfFunc = Gerador.Cpf();
                double salarioHora = ran.Next(15, 50) + ran.NextDouble();
                proletario.DefineDados(Gerador.NomePessoa(), VerifCpf(cpfFunc, nList, sList, fList, eList), Gerador.Idade(), Gerador.Saldo());
                proletario.DefineCargoSalario(Gerador.GeraCargos(), salarioHora);
                fList.Add(new Funcionario(salarioHora, Gerador.GeraCargos(), Gerador.NomePessoa(), VerifCpf(cpfFunc, nList, sList, fList, eList), Gerador.Idade(), Gerador.Saldo()));
            }
            for (int i = 0; i < 2; i++)
            {
                SocialClient sCli = new SocialClient();
                Random ran = new Random();
                string cpf = Gerador.Cpf();
                double qtdAcoes = ran.Next(0, 500) + ran.NextDouble();
                if (qtdAcoes > 495)
                {
                    qtdAcoes = ran.Next(0, 500) + ran.NextDouble();
                }
                else { }
                sCli.DefineDados(Gerador.NomePessoa(), VerifCpf(cpf, nList, sList, fList, eList), Gerador.Idade(), Gerador.Saldo());
                sCli.DefineAcoes(qtdAcoes);
                sList.Add(new SocialClient(qtdAcoes, Gerador.NomePessoa(), VerifCpf(cpf, nList, sList, fList, eList), Gerador.Idade(), Gerador.Saldo()));

            }
            double CAIXA = 0;
            Inicio(); //Poder Comentar essa função para não ver ela toda vez que der F5
            Menu(nList, sList, fList, eList, CAIXA);
        }
        //Funções essenciais para o Trabalho
        //----------------------------------
        public static bool TestCpf(string cpf, List<NormalClient> nlist, List<SocialClient> slist, List<Funcionario> fList, List<Fornecedor> eList)
        {
            bool verif = false;
            foreach (var item in nlist)
            {
                if (item.Cpf == cpf)
                {
                    verif = true;
                    break;
                }
            }
            foreach (var item in slist)
            {
                if (item.Cpf == cpf)
                {
                    verif = true;
                    break;
                }
            }
            foreach (var item in fList)
            {
                if (item.Cpf == cpf)
                {
                    verif = true;
                    break;
                }
            }
            foreach (var item in eList)
            {
                if (item.Cnpj == cpf)
                {
                    verif = true;
                    break;
                }
            }
            return verif;
        }
        public static string VerifCpf(string cpf, List<NormalClient> nlist, List<SocialClient> slist, List<Funcionario> fList, List<Fornecedor> eList)
        {
            do
            {
                if (TestCpf(cpf, nlist, slist, fList, eList))
                {
                    cpf = Gerador.Cpf();
                }
                else
                {
                    break;
                }
            } while (true);
            return cpf;
        }
        public static double OsFornecedores(List<Fornecedor> eList)
        {
            double preju = 0;
            foreach (var item in eList)
            {
                if (item.TipoProduto == 1)
                {
                    preju += item.QtdMensal * 5.45;
                }
                else if (item.TipoProduto == 2)
                {
                    preju += item.QtdMensal * 6.78;
                }
                else if (item.TipoProduto == 3)
                {
                    preju += item.QtdMensal * 1.43;
                }
                else if (item.TipoProduto == 4)
                {
                    preju += item.QtdMensal * 2.68;
                }
                else if (item.TipoProduto == 5)
                {
                    preju += item.QtdMensal * 3.78;
                }
                else if (item.TipoProduto == 6)
                {
                    preju += item.QtdMensal * 2.96;
                }
            }
            return preju;
        }
        public static double OsSocialClient(List<SocialClient> slist)
        {
            double desconto = 0;
            foreach (var item in slist)
            {
                desconto += item.QtdAcoes;
            }
            desconto /= 100;
            desconto -= 1.00;
            if (desconto < 0)
            {
                desconto *= -1;
            }
            else { }
            return desconto;
        }
        public static void Menu(List<NormalClient> nList, List<SocialClient> sList, List<Funcionario> fList, List<Fornecedor> eList, double CAIXA)
        {
            Console.Clear();
            string[] menu = new string[] { "Adicionar", "Remover", "Comprar", "Bater Cartão", "Alterar", "Calcular Lucro", "Ver Pessoas", "Sair" };
            MostraMenu(menu, "vermelhoE", "branco", "Menu");
            int escolhaMenus = CInt();
            switch (escolhaMenus)
            {
                case 1:
                    while (escolhaMenus != 5)
                    {
                        Console.Clear();
                        string[] subMenu1 = new string[] { "Cliente Normal", "Cliente Associado", "Funcionario", "Fornecedor", "Voltar" };
                        Console.WriteLine("O que o Sr.(a) gostaria de ADICIONAR?");
                        MostraMenu(subMenu1, "branco", "cinza", "Sub Menu");
                        escolhaMenus = CInt();
                        if (escolhaMenus == 1)
                        {
                            AdicionarNCli(nList, sList, fList, eList);
                        }
                        else if (escolhaMenus == 2)
                        {
                            AdicionarSCli(nList, sList, fList, eList, CAIXA);
                        }
                        else if (escolhaMenus == 3)
                        {
                            AdicionarFCli(nList, sList, fList, eList);
                        }
                        else if (escolhaMenus == 4)
                        {
                            AdicionarECli(nList, sList, fList, eList);
                        }
                        else if (escolhaMenus == 5)
                        {
                            Menu(nList, sList, fList, eList, CAIXA);
                        }
                    } //Adicionar
                    break;
                case 2:
                    while (escolhaMenus != 5)
                    {
                        Console.Clear();
                        string[] subMenu2 = new string[] { "Cliente Normal", "Cliente Associado", "Funcionario", "Fornecedor", "Voltar" };
                        Console.WriteLine("O que o Sr.(a) gostaria de REMOVER?");
                        MostraMenu(subMenu2, "branco", "cinza", "Sub Menu");
                        escolhaMenus = CInt();
                        if (escolhaMenus == 1)
                        {
                            RemoverNCli(nList, sList, fList, eList);
                        }
                        else if (escolhaMenus == 2)
                        {
                            RemoverSCli(nList, sList, fList, eList);
                        }
                        else if (escolhaMenus == 3)
                        {

                            RemoverFCli(nList, sList, fList, eList);
                        }
                        else if (escolhaMenus == 4)
                        {
                            RemoverECli(nList, sList, fList, eList, CAIXA);

                        }
                        else if (escolhaMenus == 5)
                        {
                            Menu(nList, sList, fList, eList, CAIXA);
                        }
                    } //Remover 
                    break;
                case 3:
                    escolhaMenus = 0;
                    while (escolhaMenus != 3)
                    {
                        Console.Clear();
                        string[] subMenu2 = new string[] { "Cliente Normal", "Cliente Associado", "Voltar" };
                        Console.WriteLine("Com o que o Sr.(a) gostaria de COMPRAR?");
                        MostraMenu(subMenu2, "branco", "cinza", "Sub Menu");
                        escolhaMenus = CInt();
                        if (escolhaMenus == 1)
                        {
                            ComprarNCli(nList, sList, fList, eList);
                        }
                        else if (escolhaMenus == 2)
                        {
                            ComprarSCli(nList, sList, fList, eList);
                        }
                        else if (escolhaMenus == 3)
                        {
                            Menu(nList, sList, fList, eList, CAIXA);
                        }
                    } //Comprar
                    break;
                case 4:
                    {
                        BaterCartoes(nList, sList, fList, eList, CAIXA);
                    } //Bater Cartão
                    break;
                case 5:
                    escolhaMenus = 0;

                    while (escolhaMenus != 5)
                    {
                        Console.Clear();
                        string[] subMenu3 = new string[] { "Cliente Normal", "Cliente Associado", "Funcionario", "Fornecedor", "Voltar" };
                        Console.WriteLine("O que o Sr.(a) gostaria de ALTERAR?");
                        MostraMenu(subMenu3, "branco", "cinza", "Sub Menu");
                        escolhaMenus = CInt();
                        if (escolhaMenus == 1)
                        {
                            AlterarNCli(nList, sList, fList, eList);
                        }
                        else if (escolhaMenus == 2)
                        {
                            AlterarSCli(nList, sList, fList, eList);
                        }
                        else if (escolhaMenus == 3)
                        {
                            AlterarFCli(nList, sList, fList, eList);
                        }
                        else if (escolhaMenus == 4)
                        {
                            AlterarECli(nList, sList, fList, eList, CAIXA);
                        }
                        else if (escolhaMenus == 5)
                        {
                            Menu(nList, sList, fList, eList, CAIXA);

                        }
                    } //Alterar
                    break;
                case 6:
                    {
                        CalculaLucro(nList, sList, fList, eList, CAIXA);
                    } //Calcula Lucro
                    break;
                case 7:
                    while (escolhaMenus != 6)
                    {
                        Console.Clear();
                        string[] subMenu1 = new string[] { "Cliente Normal", "Cliente Associado", "Funcionarios", "Fornecedores", "Tudo", "Voltar" };
                        for (int i = 0; i < 5; i++)
                        {
                            Console.Write(" ");
                        }
                        Console.WriteLine("O que o Sr.(a) gostaria de ver?");
                        MostraMenu(subMenu1, "cinzaE", "branco", " Sub Menu");
                        escolhaMenus = CInt();
                        if (escolhaMenus == 1)
                        {
                            MostraTodosCli(nList);
                            Console.Write("[ENTER]");
                            CString();
                        }
                        else if (escolhaMenus == 2)
                        {
                            MostraTodosCli(sList);
                            Console.Write("[ENTER]");
                            CString();
                        }
                        else if (escolhaMenus == 3)
                        {
                            MostraTodosCli(fList);
                            Console.Write("[ENTER]");
                            CString();
                        }
                        else if (escolhaMenus == 4)
                        {
                            MostraTodosCli(eList);
                            Console.Write("[ENTER]");
                            CString();
                        }
                        else if (escolhaMenus == 5)
                        {
                            MostraTodosCli(nList, sList, fList, eList);
                            Console.Write("[ENTER]");
                            CString();
                        }
                        else if (escolhaMenus == 6)
                        {
                            Menu(nList, sList, fList, eList, CAIXA);
                        }
                    } //Ver Pessoas
                    break;
                case 8:
                    {
                        Final();
                        Environment.Exit(0);
                    } //Sair
                    break;
                default:
                    Menu(nList, sList, fList, eList, CAIXA);
                    break;
            }

        }

        //Adicionar Cliente
        //---------------------------
        public static void AdicionarNCli(List<NormalClient> nList, List<SocialClient> sList, List<Funcionario> fList, List<Fornecedor> eList)
        {
            Console.Clear();
            Console.WriteLine("Muito bem, será um 'Cliente Normal'. Insira as credenciais do Cliente:");
            Console.Write("Nome: ");
            string nome = CString();
            bool verif = false;
            string cpf = "";
            while (verif == false)
            {
                Console.Write("CPF (Inisira os pontos e o traço por gentileza): ");
                cpf = CString();
                if (TestCpf(cpf, nList, sList, fList, eList))
                {
                    Console.Clear();
                    Cor("vermelhoE");
                    Console.WriteLine("Este CPF já existe, por favor insira um válido!");
                    Console.ResetColor();
                }
                else
                {
                    verif = true;
                }
            } //Verifica o CPF
            Console.Write("Idade: ");
            int idade = CInt();
            Console.Write("Saldo: R$ ");
            double saldo = CDoub();
            nList.Add(new NormalClient(nome, cpf, idade, saldo));
            Console.Clear();
            Cor("azulE");
            Console.WriteLine("Dados Insiridos com Sucesso, seja bem vindo {0}!", nome);
            Thread.Sleep(1111);
            Console.ResetColor();
            Console.WriteLine("Voltando ao Menu, Aguarde um instante...");
            Thread.Sleep(1111);
            Console.WriteLine("Pode demorar um pouco devido a sua conexão com a internet....");
            Thread.Sleep(2222);
        } //Preciso passar todas as listas como parametro para poder testar os CPF
        public static void AdicionarSCli(List<NormalClient> nList, List<SocialClient> sList, List<Funcionario> fList, List<Fornecedor> eList, double CAIXA)
        {
            if (sList.Count >= 10)
            {
                Cor("vermelhoE");
                Console.WriteLine("Limite de Clientes Associados excedidos, remova um Sócio para adicionar um novo!");
                Console.Write("[ENTER]");
                CString();
                Menu(nList, sList, fList, eList, CAIXA);
            }
            Console.Clear();
            Console.WriteLine("Muito bem, será um 'Cliente Associado'. Insira as credenciais do Cliente:");
            Console.Write("Nome: ");
            string nome = CString();
            bool verif = false;
            string cpf = "";
            while (verif == false)
            {
                Console.Write("CPF (Inisira os pontos e o traço por gentileza): ");
                cpf = CString();
                if (TestCpf(cpf, nList, sList, fList, eList))
                {
                    Console.Clear();
                    Cor("vermelhoE");
                    Console.WriteLine("Este CPF já existe, por favor insira um válido!");
                    Console.ResetColor();
                }
                else
                {
                    verif = true;
                }
            } //Verifica o CPF
            Console.Write("Idade: ");
            int idade = CInt();
            Console.Write("Saldo: R$ ");
            double saldo = CDoub();
            verif = false;
            double qtdAcoes = 0;
            while (verif == false)
            {
                Console.Write("Quantidade de Ações (Insira a porcentagem de Ações. Não pode ultrapassar 4,95%): ");
                qtdAcoes = CDoub();
                if (qtdAcoes > 4.95)
                {
                    Console.Clear();
                    Cor("vermelhoE");
                    Console.WriteLine("Você exedeu o limite máximo de Ações! Insira novamente.");
                    Console.ResetColor();
                }
                else
                {
                    verif = true;
                }
            }
            qtdAcoes *= 100;
            sList.Add(new SocialClient(qtdAcoes, nome, cpf, idade, saldo));
            Console.Clear();
            Cor("verdeE");
            Console.WriteLine("Dados Insiridos com Sucesso, seja bem vindo {0}!", nome);
            Thread.Sleep(1111);
            Console.ResetColor();
            Console.WriteLine("Voltando ao Menu, Aguarde um instante...");
            Thread.Sleep(1111);
            Console.WriteLine("Pode demorar um pouco devido a sua conexão com a internet....");
            Thread.Sleep(2222);
        }
        public static void AdicionarFCli(List<NormalClient> nList, List<SocialClient> sList, List<Funcionario> fList, List<Fornecedor> eList)
        {
            Console.Clear();
            Console.WriteLine("Muito bem, será um 'Funcionario'. Insira as credenciais do Funcionario:");
            Console.Write("Nome: ");
            string nome = CString();
            bool verif = false;
            string cpf = "";
            while (verif == false)
            {
                Console.Write("CPF (Inisira os pontos e o traço por gentileza): ");
                cpf = CString();
                if (TestCpf(cpf, nList, sList, fList, eList))
                {
                    Console.Clear();
                    Cor("vermelhoE");
                    Console.WriteLine("Este CPF já existe, por favor insira um válido!");
                    Console.ResetColor();
                }
                else
                {
                    verif = true;
                }
            } //Verifica o CPF
            Console.Write("Idade: ");
            int idade = CInt();
            Console.Write("Saldo: R$ ");
            double saldo = CDoub();
            Console.Write("Salario por Hora: R$ ");
            double salarioHora = CDoub();
            Console.Write("Cargo: ");
            string cargo = CString();
            fList.Add(new Funcionario(salarioHora, cargo, nome, cpf, idade, saldo));
            Console.Clear();
            Cor("verdeE");
            Console.WriteLine("Dados Insiridos com Sucesso, seja bem vindo a empresa {0}!", nome);
            Thread.Sleep(1111);
            Console.ResetColor();
            Console.WriteLine("Voltando ao Menu, Aguarde um instante...");
            Thread.Sleep(1111);
            Console.WriteLine("Pode demorar um pouco devido a sua conexão com a internet....");
            Thread.Sleep(2222);
        }
        public static void AdicionarECli(List<NormalClient> nList, List<SocialClient> sList, List<Funcionario> fList, List<Fornecedor> eList)
        {
            Console.Clear();
            Console.WriteLine("Muito bem, será um 'Fornecedor'. Insira as credenciais do Fornecedor:");
            Console.Write("Nome da Empresa: ");
            string nomeEmpresa = CString();
            bool verif = false;
            string cnpj = "";
            while (verif == false)
            {
                Console.Write("CPNPJ (Inisira os pontos e o traço por gentileza): ");
                cnpj = CString();
                if (TestCpf(cnpj, nList, sList, fList, eList))
                {
                    Console.Clear();
                    Cor("vermelhoE");
                    Console.WriteLine("Este CNPJ já existe, por favor insira um válido!");
                    Console.ResetColor();
                }
                else
                {
                    verif = true;
                }
            } //Verifica o CPF
            string[] subSubMenu = new string[] { "Comida", "Camisetas", "Espadas Orientais", "Brinquedo de Criança", "Cytotec", "Doce" };
            Console.WriteLine("Tipo do seu produto: ");
            MostraMenu(subSubMenu, "amareloE", "branco", "Tipos ");
        Refaz: //eu estava com preguiça de usar while, mas vai dizer foi uma boa ideia usar aqui :)
            int tipo = CInt();
            if (tipo > 7 || tipo <= 0)
            {
                Cor("vermelhoE");
                Console.WriteLine("Desculpe, mas esse produto não existe. Insira Novamente");
                Console.ResetColor();
                goto Refaz;
            }
            Console.Write("Quantidade mensal do seu produto: ");
            int qtdMensal = CInt();
            eList.Add(new Fornecedor(nomeEmpresa, cnpj, tipo, qtdMensal));
            Console.Clear();
            Cor("amareloE");
            Console.WriteLine("Dados Insiridos com Sucesso, obrigado por se tornar nosso mais novo fornecedor, {0}!", nomeEmpresa);
            Thread.Sleep(1111);
            Console.ResetColor();
            Console.WriteLine("Voltando ao Menu, Aguarde um instante...");
            Thread.Sleep(1111);
            Console.WriteLine("Pode demorar um pouco devido a sua conexão com a internet....");
            Thread.Sleep(2222);
        }

        //Remover Cliente
        //--------------------------
        public static void RemoverNCli(List<NormalClient> nList, List<SocialClient> sList, List<Funcionario> fList, List<Fornecedor> eList)
        {
            Console.Clear();
            Console.WriteLine("Muito bem, será um 'Cliente Normal'. Pelo CPF escolha QUEM o SR.(a) irá remover: ");
            Console.WriteLine();
            MostraTodosCli(nList);
            int i = 0;
            string cpfRemov = "";
            bool verif = false;
            while (verif == false)
            {
                Console.Write("-> ");
                cpfRemov = CString();
                if (!TestCpf(cpfRemov, nList, sList, fList, eList))
                {
                    Cor("vermelhoE");
                    Console.WriteLine("Este CPF foi digitado incorretamente ou não existe! Por favor insira novamente.");
                    Console.ResetColor();
                    verif = false;
                }
                else
                {
                    verif = true;
                }
            } //Confere o CPF
            foreach (var item in nList)
            {
                if (item.Cpf == cpfRemov)
                {
                    break;
                }
                i++;
            }
            nList.RemoveAt(i);
            Console.Clear();
            Cor("azulE");
            Console.WriteLine("Dados Removidos com Sucesso!");
            Thread.Sleep(1111);
            Console.ResetColor();
            Console.WriteLine("Voltando ao Menu, Aguarde um instante...");
            Thread.Sleep(1111);
            Console.WriteLine("Pode demorar um pouco devido a sua conexão com a internet....");
            Thread.Sleep(2222);
        }
        public static void RemoverSCli(List<NormalClient> nList, List<SocialClient> sList, List<Funcionario> fList, List<Fornecedor> eList)
        {
            Console.Clear();
            Console.WriteLine("Muito bem, será um 'Cliente Sócio'. Pelo CPF escolha QUEM o SR.(a) irá remover: ");
            Console.WriteLine();
            MostraTodosCli(sList);
            int i = 0;
            string cpfRemov = "";
            bool verif = false;
            while (verif == false)
            {
                Console.Write("-> ");
                cpfRemov = CString();
                if (!TestCpf(cpfRemov, nList, sList, fList, eList))
                {
                    Cor("vermelhoE");
                    Console.WriteLine("Este CPF foi digitado incorretamente ou não existe! Por favor insira novamente.");
                    Console.ResetColor();
                    verif = false;
                }
                else
                {
                    verif = true;
                }
            } //Confere o CPF
            foreach (var item in sList)
            {
                if (item.Cpf == cpfRemov)
                {
                    break;
                }
                i++;
            } //Pega o Indice
            sList.RemoveAt(i);
            Console.Clear();
            Cor("verdeE");
            Console.WriteLine("Dados Removidos com Sucesso!");
            Thread.Sleep(1111);
            Console.ResetColor();
            Console.WriteLine("Voltando ao Menu, Aguarde um instante...");
            Thread.Sleep(1111);
            Console.WriteLine("Pode demorar um pouco devido a sua conexão com a internet....");
            Thread.Sleep(2222);
        }
        public static void RemoverFCli(List<NormalClient> nList, List<SocialClient> sList, List<Funcionario> fList, List<Fornecedor> eList)
        {
            Console.Clear();
            Console.WriteLine("Muito bem, será um 'Funcionário'. Pelo CPF escolha QUEM o SR.(a) irá DEMITIR: ");
            Console.WriteLine();
            MostraTodosCli(fList);
            int i = 0;
            string cpfRemov = "";
            bool verif = false;
            while (verif == false)
            {
                Console.Write("-> ");
                cpfRemov = CString();
                if (!TestCpf(cpfRemov, nList, sList, fList, eList))
                {
                    Cor("vermelhoE");
                    Console.WriteLine("Este CPF foi digitado incorretamente ou não existe! Por favor insira novamente.");
                    Console.ResetColor();
                    verif = false;
                }
                else
                {
                    verif = true;
                }
            } //Confere o CPF
            foreach (var item in fList)
            {
                if (item.Cpf == cpfRemov)
                {
                    break;
                }
                i++;
            }
            fList.RemoveAt(i);
            Console.Clear();
            Cor("vermelhoE");
            Console.WriteLine("Funcionário Demitido com Sucesso!");
            Thread.Sleep(1111);
            Console.ResetColor();
            Console.WriteLine("Voltando ao Menu, Aguarde um instante...");
            Thread.Sleep(1111);
            Console.WriteLine("Pode demorar um pouco devido a sua conexão com a internet....");
            Thread.Sleep(2222);
        }
        public static void RemoverECli(List<NormalClient> nList, List<SocialClient> sList, List<Funcionario> fList, List<Fornecedor> eList, double CAIXA)
        {
            Console.Clear();
            if (eList.Count == 0)
            {
                Cor("vermelhoE");
                Console.WriteLine("Desculpe Sr.(a), mas é impossível remover um Fornecedor que não exite. Adicione um primeiro para poder usar esta função.");
                Console.ResetColor();
                Console.Write("[PRESSIONE ENTER PARA VOLTAR AO MENU]");
                CString();
                Menu(nList, sList, fList, eList, CAIXA);
            }
            Console.WriteLine("Muito bem, será um 'Fornecedor'. Pelo CNPJ escolha QUAL empresa o SR.(a) irá DEMITIR: ");
            Console.WriteLine();
            MostraTodosCli(eList);
            int i = 0;
            string cnpjRemov = "";
            bool verif = false;
            while (verif == false)
            {
                Console.Write("-> ");
                cnpjRemov = CString();
                if (!TestCpf(cnpjRemov, nList, sList, fList, eList))
                {
                    Cor("vermelhoE");
                    Console.WriteLine("Este CPF foi digitado incorretamente ou não existe! Por favor insira novamente.");
                    Console.ResetColor();
                    verif = false;
                }
                else
                {
                    verif = true;
                }
            } //Confere o CPF
            foreach (var item in eList)
            {
                if (item.Cnpj == cnpjRemov)
                {
                    break;
                }
                i++;
            }
            eList.RemoveAt(i);
            Console.Clear();
            Cor("amareloE");
            Console.WriteLine("Empresa Demitida com Sucesso!");
            Thread.Sleep(1111);
            Console.ResetColor();
            Console.WriteLine("Voltando ao Menu, Aguarde um instante...");
            Thread.Sleep(1111);
            Console.WriteLine("Pode demorar um pouco devido a sua conexão com a internet....");
            Thread.Sleep(2222);
        }

        //Comprar
        //---------------------------
        public static void ComprarNCli(List<NormalClient> nList, List<SocialClient> sList, List<Funcionario> fList, List<Fornecedor> eList)
        {
            Console.Clear();
            Console.WriteLine("Muito bem, será um 'Cliente Normal'. Pelo CPF escolha QUEM irá comprar: ");
            Console.WriteLine();
            MostraTodosCli(nList);
            string cpfComp = "";
            bool verif = false;
            while (verif == false)
            {
                Console.Write("-> ");
                cpfComp = CString();
                if (!TestCpf(cpfComp, nList, sList, fList, eList))
                {
                    Cor("vermelhoE");
                    Console.WriteLine("Este CPF foi digitado incorretamente ou não existe! Por favor insira novamente.");
                    Console.ResetColor();
                    verif = false;
                }
                else
                {
                    verif = true;
                }
            } //Confere o CPF
            int i = 0;
            foreach (var item in nList)
            {
                if (item.Cpf == cpfComp)
                {
                    break;
                }
                i++;
            }
            Console.WriteLine("Qual o valor da Compra?");
            double vCompra = CDoub();
            nList[i] = new NormalClient(nList[i].Nome, nList[i].Cpf, nList[i].Idade, nList[i].Saldo + vCompra);
            Console.Clear();
            Cor("azulE");
            Console.WriteLine("Produtos Comprados com Sucesso! Obrigado {0}, você faz a gente mais Rico!", nList[i].Nome);
            Thread.Sleep(1111);
            Console.ResetColor();
            Console.WriteLine("Voltando ao Menu, Aguarde um instante...");
            Thread.Sleep(1111);
            Console.WriteLine("Pode demorar um pouco devido a sua conexão com a internet....");
            Thread.Sleep(2222);
        }
        public static void ComprarSCli(List<NormalClient> nList, List<SocialClient> sList, List<Funcionario> fList, List<Fornecedor> eList)
        {
            Console.Clear();
            Console.WriteLine("Muito bem, será um 'Cliente Sócio'. Pelo CPF escolha QUEM irá comprar: ");
            Console.WriteLine();
            MostraTodosCli(sList);
            string cpfComp = "";
            bool verif = false;
            while (verif == false)
            {
                Console.Write("-> ");
                cpfComp = CString();
                if (!TestCpf(cpfComp, nList, sList, fList, eList))
                {
                    Cor("vermelhoE");
                    Console.WriteLine("Este CPF foi digitado incorretamente ou não existe! Por favor insira novamente.");
                    Console.ResetColor();
                    verif = false;
                }
                else
                {
                    verif = true;
                }
            } //Confere o CPF
            int i = 0;
            foreach (var item in sList)
            {
                if (item.Cpf == cpfComp)
                {
                    break;
                }
                i++;
            }
            Console.WriteLine("Qual o valor da Compra?");
            double vCompra = CDoub();
            vCompra *= 0.8;
            sList[i] = new SocialClient(sList[i].QtdAcoes, sList[i].Nome, sList[i].Cpf, sList[i].Idade, sList[i].Saldo + vCompra);
            Console.Clear();
            Cor("verdeE");
            Console.WriteLine("Produtos Comprados com Sucesso! Obrigado {0}, você faz a gente mais Rico!", sList[i].Nome);
            Thread.Sleep(1111);
            Console.ResetColor();
            Console.WriteLine("Voltando ao Menu, Aguarde um instante...");
            Thread.Sleep(1111);
            Console.WriteLine("Pode demorar um pouco devido a sua conexão com a internet....");
            Thread.Sleep(2222);
        }

        //Bater Cartão
        //---------------------------
        public static void BaterCartoes(List<NormalClient> nList, List<SocialClient> sList, List<Funcionario> fList, List<Fornecedor> eList, double CAIXA)
        {
            Console.Clear();
            Console.WriteLine("Muito bem, pelo CPF escolha QUEM irá BATER CARTÃO: ");
            Console.WriteLine();
            MostraTodosCli(fList);
            string cpfVerif = "";
            bool verif = false;
            while (verif == false)
            {
                Console.Write("-> ");
                cpfVerif = CString();
                if (!TestCpf(cpfVerif, nList, sList, fList, eList))
                {
                    Cor("vermelhoE");
                    Console.WriteLine("Este CPF foi digitado incorretamente ou não existe! Por favor insira novamente.");
                    Console.ResetColor();
                    verif = false;
                }
                else
                {
                    verif = true;
                }
            } //Confere o CPF
            int i = 0;
            foreach (var item in fList)
            {
                if (item.Cpf == cpfVerif)
                {
                    break;
                }
                i++;
            }
            Console.Clear();
            Console.WriteLine("{0}, gostaria de bater o cartão de 1 único dia ('a') ou de 30 dias direto ('b')?", fList[i].Nome);
            char esc = CChar();
            if (esc == 'a')
            {
                Console.WriteLine("Por favor insira a Hora que entrou e a Hora que saiu (Por padrão insira com a formatação de 24h):");
                int hrEnt = CInt();
                int hrSaid = CInt();
                fList[i] = new Funcionario(fList[i].SalarioPorHora, fList[i].Cargo, fList[i].Nome, fList[i].Cpf, fList[i].Idade, fList[i].BaterPontoDia(hrEnt, hrSaid));
            }
            else if (esc == 'b')
            {
                fList[i] = new Funcionario(fList[i].SalarioPorHora, fList[i].Cargo, fList[i].Nome, fList[i].Cpf, fList[i].Idade, fList[i].BaterPontoMes());
            }
            else
            {
                Console.WriteLine("Sr.(a) infelizmente foi impossível bater o cartão de '{0}', tente novamente!", fList[i].Nome);
                Console.Write("Pressione [ENTER] para voltar ao menu....");
                CString();
                Menu(nList, sList, fList, eList, CAIXA);

            }
            Console.Clear();
            Cor("vermelhoE");
            Console.WriteLine("Cartão Batido com Sucesso!");
            Thread.Sleep(1111);
            Console.ResetColor();
            Console.WriteLine("Voltando ao Menu, Aguarde um instante...");
            Thread.Sleep(1111);
            Console.WriteLine("Pode demorar um pouco devido a sua conexão com a internet....");
            Thread.Sleep(2222);
            Menu(nList, sList, fList, eList, CAIXA);
        }

        //Aletar Cliente
        //--------------------------
        public static void AlterarNCli(List<NormalClient> nList, List<SocialClient> sList, List<Funcionario> fList, List<Fornecedor> eList)
        {
            Console.Clear();
            Console.WriteLine("Muito bem, será um 'Cliente Normal'. Pelo CPF escolha QUEM o SR.(a) irá alterar: ");
            Console.WriteLine();
            MostraTodosCli(nList);
            string cpfNew = "";
            bool verif = false;
            while (verif == false)
            {
                Console.Write("-> ");
                cpfNew = CString();
                if (!TestCpf(cpfNew, nList, sList, fList, eList))
                {
                    Cor("vermelhoE");
                    Console.WriteLine("Este CPF foi digitado incorretamente ou não existe! Por favor insira novamente.");
                    Console.ResetColor();
                    verif = false;
                }
                else
                {
                    verif = true;
                }
            } //Confere o CPF
            int i = 0;
            foreach (var item in nList)
            {
                if (item.Cpf == cpfNew)
                {
                    break;
                }
                i++;
            }
            Console.Clear();
            Console.WriteLine("Será alterado - {0}", nList[i].Nome);
            nList.RemoveAt(i);
            Console.Write("Nome: ");
            string nome = CString();
            verif = false;
            cpfNew = "";
            while (verif == false)
            {
                Console.Write("CPF (Inisira os pontos e o traço por gentileza): ");
                cpfNew = CString();
                if (TestCpf(cpfNew, nList, sList, fList, eList))
                {
                    Console.Clear();
                    Cor("vermelhoE");
                    Console.WriteLine("Este CPF já existe, por favor insira um válido!");
                    Console.ResetColor();
                }
                else
                {
                    verif = true;
                }
            }
            Console.Write("Idade: ");
            int idade = CInt();
            Console.Write("Saldo: R$ ");
            double saldo = CDoub();
            nList.Insert(i, new NormalClient(nome, cpfNew, idade, saldo));
            Console.Clear();
            Cor("azulE");
            Console.WriteLine("Dados Alterados com Sucesso!");
            Thread.Sleep(1111);
            Console.ResetColor();
            Console.WriteLine("Voltando ao Menu, Aguarde um instante...");
            Thread.Sleep(1111);
            Console.WriteLine("Pode demorar um pouco devido a sua conexão com a internet....");
            Thread.Sleep(2222);
        }
        public static void AlterarSCli(List<NormalClient> nList, List<SocialClient> sList, List<Funcionario> fList, List<Fornecedor> eList)
        {
            Console.Clear();
            Console.WriteLine("Muito bem, será um 'Cliente Sócio'. Pelo CPF escolha QUEM o SR.(a) irá alterar: ");
            Console.WriteLine();
            MostraTodosCli(sList);
            string cpfNew = "";
            bool verif = false;
            while (verif == false)
            {
                Console.Write("-> ");
                cpfNew = CString();
                if (!TestCpf(cpfNew, nList, sList, fList, eList))
                {
                    Cor("vermelhoE");
                    Console.WriteLine("Este CPF foi digitado incorretamente ou não existe! Por favor insira novamente.");
                    Console.ResetColor();
                    verif = false;
                }
                else
                {
                    verif = true;
                }
            } //Confere o CPF
            int i = 0;
            foreach (var item in sList)
            {
                if (item.Cpf == cpfNew)
                {
                    break;
                }
                i++;
            }
            Console.Clear();
            Console.WriteLine("Será alterado - {0}", sList[i].Nome);
            sList.RemoveAt(i);
            Console.Write("Nome: ");
            string nome = CString();
            verif = false;
            cpfNew = "";
            while (verif == false)
            {
                Console.Write("CPF (Inisira os pontos e o traço por gentileza): ");
                cpfNew = CString();
                if (TestCpf(cpfNew, nList, sList, fList, eList))
                {
                    Console.Clear();
                    Cor("vermelhoE");
                    Console.WriteLine("Este CPF já existe, por favor insira um válido!");
                    Console.ResetColor();
                }
                else
                {
                    verif = true;
                }
            }
            Console.Write("Idade: ");
            int idade = CInt();
            Console.Write("Saldo: R$ ");
            double saldo = CDoub();
            verif = false;
            double qtdAcoes = 0;
            while (verif == false)
            {
                Console.Write("Quantidade de Ações (Insira a porcentagem de Ações. Não pode ultrapassar 4,95%): ");
                qtdAcoes = CDoub();
                if (qtdAcoes > 4.95)
                {
                    Console.Clear();
                    Cor("vermelhoE");
                    Console.WriteLine("Você exedeu o limite máximo de Ações! Insira novamente.");
                    Console.ResetColor();
                }
                else
                {
                    verif = true;
                }
            }
            qtdAcoes *= 100;
            sList.Insert(i, new SocialClient(qtdAcoes, nome, cpfNew, idade, saldo));
            Console.Clear();
            Cor("azulE");
            Console.WriteLine("Dados Alterados com Sucesso!");
            Thread.Sleep(1111);
            Console.ResetColor();
            Console.WriteLine("Voltando ao Menu, Aguarde um instante...");
            Thread.Sleep(1111);
            Console.WriteLine("Pode demorar um pouco devido a sua conexão com a internet....");
            Thread.Sleep(2222);
        }
        public static void AlterarFCli(List<NormalClient> nList, List<SocialClient> sList, List<Funcionario> fList, List<Fornecedor> eList)
        {
            Console.Clear();
            Console.WriteLine("Muito bem, será um 'Funcionário'. Pelo CPF escolha QUEM o SR.(a) irá alterar: ");
            Console.WriteLine();
            MostraTodosCli(fList);
            string cpfNew = "";
            bool verif = false;
            while (verif == false)
            {
                Console.Write("-> ");
                cpfNew = CString();
                if (!TestCpf(cpfNew, nList, sList, fList, eList))
                {
                    Cor("vermelhoE");
                    Console.WriteLine("Este CPF foi digitado incorretamente ou não existe! Por favor insira novamente.");
                    Console.ResetColor();
                    verif = false;
                }
                else
                {
                    verif = true;
                }
            } //Confere o CPF
            int i = 0;
            foreach (var item in fList)
            {
                if (item.Cpf == cpfNew)
                {
                    break;
                }
                i++;
            }
            Console.Clear();
            Console.WriteLine("Será alterado - {0}", fList[i].Nome);
            fList.RemoveAt(i);
            Console.Write("Nome: ");
            string nome = CString();
            verif = false;
            cpfNew = "";
            while (verif == false)
            {
                Console.Write("CPF (Inisira os pontos e o traço por gentileza): ");
                cpfNew = CString();
                if (TestCpf(cpfNew, nList, sList, fList, eList))
                {
                    Console.Clear();
                    Cor("vermelhoE");
                    Console.WriteLine("Este CPF já existe, por favor insira um válido!");
                    Console.ResetColor();
                }
                else
                {
                    verif = true;
                }
            }
            Console.Write("Idade: ");
            int idade = CInt();
            Console.Write("Saldo: R$ ");
            double saldo = CDoub();
            Console.Write("Salario por Hora: R$ ");
            double salarioHora = CDoub();
            Console.Write("Cargo: ");
            string cargo = CString();
            fList.Insert(i, new Funcionario(salarioHora, cargo, nome, cpfNew, idade, saldo));
            Console.Clear();
            Cor("vermelhoE");
            Console.WriteLine("Funcionário Alterado com Sucesso!");
            Thread.Sleep(1111);
            Console.ResetColor();
            Console.WriteLine("Voltando ao Menu, Aguarde um instante...");
            Thread.Sleep(1111);
            Console.WriteLine("Pode demorar um pouco devido a sua conexão com a internet....");
            Thread.Sleep(2222);
        }
        public static void AlterarECli(List<NormalClient> nList, List<SocialClient> sList, List<Funcionario> fList, List<Fornecedor> eList, double CAIXA)
        {
            if (eList.Count == 0)
            {
                Cor("vermelhoE");
                Console.WriteLine("Desculpe Sr.(a), mas é impossível alterar um Fornecedor que não exite. Adicione um primeiro para poder usar esta função.");
                Console.ResetColor();
                Console.Write("[PRESSIONE ENTER PARA VOLTAR AO MENU]");
                CString();
                Menu(nList, sList, fList, eList, CAIXA);
            }
            Console.Clear();
            Console.WriteLine("Muito bem, será um 'Fornecedor'. Pelo CNPJ escolha QUEM o SR.(a) irá alterar: ");
            Console.WriteLine();
            MostraTodosCli(eList);
            string cnpj = "";
            bool verif = false;
            while (verif == false)
            {
                Console.Write("-> ");
                cnpj = CString();
                if (!TestCpf(cnpj, nList, sList, fList, eList))
                {
                    Cor("vermelhoE");
                    Console.WriteLine("Este CPF foi digitado incorretamente ou não existe! Por favor insira novamente.");
                    Console.ResetColor();
                    verif = false;
                }
                else
                {
                    verif = true;
                }
            } //Confere o CPF
            int i = 0;
            foreach (var item in eList)
            {
                if (item.Cpf == cnpj)
                {
                    break;
                }
                i++;
            }
            Console.Clear();
            Console.WriteLine("Será alterado - {0}", eList[i - 1].Nome);
            eList.RemoveAt(i - 1);
            Console.Write("Nome da Empresa: ");
            string nomeEmpresa = CString(); verif = false;
            cnpj = "";
            while (verif == false)
            {
                Console.Write("CPNPJ (Inisira os pontos e o traço por gentileza): ");
                cnpj = CString();
                if (TestCpf(cnpj, nList, sList, fList, eList))
                {
                    Console.Clear();
                    Cor("vermelhoE");
                    Console.WriteLine("Este CNPJ já existe, por favor insira um válido!");
                    Console.ResetColor();
                }
                else
                {
                    verif = true;
                }
            }
            string[] subSubMenu = new string[] { "Comida", "Camisetas", "Espadas Orientais", "Brinquedo de Criança", "Cytotec", "Doce" };
            Console.WriteLine("Tipo do seu produto: ");
            MostraMenu(subSubMenu, "amareloE", "branco", "Tipos ");
        Refaz: //eu estava com preguiça de usar while, mas vai dizer foi uma boa ideia usar aqui :)
            int tipo = CInt();
            if (tipo > 7 || tipo <= 0)
            {
                Cor("vermelhoE");
                Console.WriteLine("Desculpe, mas esse produto não existe. Insira Novamente");
                Console.ResetColor();
                goto Refaz;
            }
            Console.Write("Quantidade mensal do seu produto: ");
            int qtdMensal = CInt();
            eList.Insert(i - 1, new Fornecedor(nomeEmpresa, cnpj, tipo, qtdMensal));
            Console.Clear();
            Cor("amareloE");
            Console.WriteLine("Empresa Alterada com Sucesso!");
            Thread.Sleep(1111);
            Console.ResetColor();
            Console.WriteLine("Voltando ao Menu, Aguarde um instante...");
            Thread.Sleep(1111);
            Console.WriteLine("Pode demorar um pouco devido a sua conexão com a internet....");
            Thread.Sleep(2222);
        }

        //Calcula Lucro
        //--------------------------
        public static void CalculaLucro(List<NormalClient> nList, List<SocialClient> sList, List<Funcionario> fList, List<Fornecedor> eList, double CAIXA)
        {
            Console.Clear();
            double ganhosCli = 0;
            double ganhosFunc = 0;
            foreach (var item in nList)
            {
                ganhosCli += item.Saldo;
            }
            foreach (var item in sList)
            {
                ganhosCli += item.Saldo;
            }
            foreach (var item in fList)
            {
                ganhosFunc += item.Saldo;
            }
            double preju = (ganhosFunc + OsFornecedores(eList)) * OsSocialClient(sList);
            double vFinal = ganhosCli - preju;
            if (vFinal > 0)
            {
                vFinal *= OsSocialClient(sList);
                CAIXA = vFinal;
            }
            else
            {
                CAIXA = vFinal;
            }
            foreach (var item in nList)
            {
                item.Saldo = 0;
            }
            foreach (var item in sList)
            {
                item.Saldo = 0;
            }
            foreach (var item in fList)
            {
                item.Saldo = 0;
            }
            foreach (var item in eList)
            {
                //PARA ARREDONDAR PRA CIMA
                if (item.QtdMensal % 2 == 2)
                {
                    item.QtdMensal /= 2;
                }
                else
                {
                    item.QtdMensal = (item.QtdMensal + 1) / 2;

                }

            }
            Console.Write("Lucro Calculado com Sucesso! Esperamos que o Sr.(a) esteja contente com o valor de ");
            if (CAIXA > 0)
            {
                Cor("verdeE");
            }
            else
            {
                Cor("vermelhoE");
            }
            Console.Write("{0:c}\n", CAIXA);
            Console.ResetColor();
            Console.Write("[ENTER]");
            CString();
            Console.WriteLine("Voltando ao Menu, Aguarde um instante...");
            Thread.Sleep(1111);
            Console.WriteLine("Pode demorar um pouco devido a sua conexão com a internet....");
            Thread.Sleep(2222);
            Menu(nList, sList, fList, eList, CAIXA);
        }

        //Amostragem de Cliente
        //---------------------------
        public static void MostraTodosCli(List<NormalClient> nList, List<SocialClient> sList, List<Funcionario> fList, List<Fornecedor> eList)
        {
            for (int i = 0; i < 8; i++)
            {
                Console.Write(" ");
            }
            Console.WriteLine("Cliente Normal");
            foreach (var item in nList)
            {
                item.MostraDados("azulE", "branco");
            }
            Console.WriteLine();
            for (int i = 0; i < 8; i++)
            {
                Console.Write(" ");
            }
            Console.WriteLine("Cliente Sócio");
            foreach (var item in sList)
            {
                item.MostraDados("verdeE", "branco");
                item.MostraAcoes("verdeE", "branco");
            }
            Console.WriteLine();
            for (int i = 0; i < 8; i++)
            {
                Console.Write(" ");
            }
            Console.WriteLine("Funcionario");
            foreach (var item in fList)
            {
                item.MostraDados("vermelhoE", "branco");
                item.MostraCargoSalario("vermelhoE", "branco");
            }
            Console.WriteLine();
            for (int i = 0; i < 15; i++)
            {
                Console.Write(" ");
            }
            Cor("branco");
            Console.WriteLine("Empresa");
            foreach (var item in eList)
            {
                item.MostraDados("amareloE", "branco");
                item.MostraQtdMensal("amareloE", "branco");
            }

        }
        public static void MostraTodosCli(List<NormalClient> nList)
        {
            for (int i = 0; i < 8; i++)
            {
                Console.Write(" ");
            }
            Cor("branco");
            Console.WriteLine("Cliente Normal");
            foreach (var item in nList)
            {
                item.MostraDados("azulE", "branco");
            }
        }
        public static void MostraTodosCli(List<SocialClient> sList)
        {
            for (int i = 0; i < 8; i++)
            {
                Console.Write(" ");
            }
            Cor("branco");
            Console.WriteLine("Cliente Sócio");
            foreach (var item in sList)
            {
                item.MostraDados("verdeE", "branco");
                item.MostraAcoes("verdeE", "branco");
            }


        }
        public static void MostraTodosCli(List<Funcionario> fList)
        {
            for (int i = 0; i < 8; i++)
            {
                Console.Write(" ");
            }
            Cor("branco");
            Console.WriteLine("Funcionario");
            foreach (var item in fList)
            {
                item.MostraDados("vermelhoE", "branco");
                item.MostraCargoSalario("vermelhoE", "branco");
            }
        }
        public static void MostraTodosCli(List<Fornecedor> eList)
        {
            for (int i = 0; i < 13; i++)
            {
                Console.Write(" ");
            }
            Cor("branco");
            Console.WriteLine("Empresa");
            foreach (var item in eList)
            {
                item.MostraDados("amareloE", "branco");
                item.MostraQtdMensal("amareloE", "branco");
            }
        }

        //Funções BASE
        //-------------
        public static string CString()
        {
            return Convert.ToString(Console.In.ReadLine());
        }
        public static int CInt()
        {
            bool a = false;
            while (!a)
            {
                try
                {
                    a = true;
                    Console.Write("-> ");
                    return Convert.ToInt32(Console.In.ReadLine());
                }
                catch (Exception)
                {
                    Cor("vermelhoE");
                    Console.WriteLine("Você Inseriu um digito inválido, Digite Novamente.");
                    Console.Write("[APENAS PRESSIONE ENTER]");
                    Console.ResetColor();
                    CString();
                    a = false;
                }
            }
            return 0;
        }
        public static double CDoub()
        {
            bool a = false;
            while (!a)
            {
                try
                {
                    a = true;
                    Console.Write("-> ");
                    return Convert.ToDouble(Console.In.ReadLine());
                }
                catch (Exception)
                {
                    Cor("vermelhoE");
                    Console.WriteLine("Você Inseriu um digito inválido, Digite Novamente.");
                    Console.Write("[APENAS PRESSIONE ENTER]");
                    Console.ResetColor();
                    CString();
                    a = false;
                }
            }
            return 0;
        }
        public static char CChar()
        {
            bool a = false;
            while (!a)
            {
                try
                {
                    a = true;
                    Console.Write("-> ");
                    return Convert.ToChar(Console.In.ReadLine());
                }
                catch (Exception)
                {
                    Cor("vermelhoE");
                    Console.WriteLine("Você Inseriu um digito inválido, Digite Novamente.");
                    Console.Write("[APENAS PRESSIONE ENTER]");
                    Console.ResetColor();
                    CString();
                    a = false;
                }
            }
            return '0';


        }
        public static void Cor(string a)
        {
            //Cinzas
            {
                if (a == "cinzaE")
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                }
                else if (a == "cinza")
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
            }
            //Azuis
            {
                if (a == "azulE")
                {
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                }
                else if (a == "azul")
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                }
            }
            //Vermelhos
            {
                if (a == "vermelhoE")
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                }
                else if (a == "vermelho")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
            }
            //Verdes
            {
                if (a == "verdeE")
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                }
                else if (a == "verde")
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
            }
            //Amarelos
            {
                if (a == "amareloE")
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                }
                else if (a == "amarelo")
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
            }
            //Magentas
            {
                if (a == "magentaE")
                {
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                }
                else if (a == "magenta")
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                }
            }
            //Cianos
            {
                if (a == "cianoE")
                {
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                }
                else if (a == "ciano")
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                }
            }
            //Preto e Branco
            {
                if (a == "preto")
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                else if (a == "branco")
                {
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        } //Função que subistitui o Console.ForegroundColor
        public static void Cor(char func, string cor)
        {
            if (func == 'B')
            {
                if (cor == "preto")
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                else if (cor == "azul")
                {
                    Console.BackgroundColor = ConsoleColor.Blue;
                }
                else if (cor == "ciano")
                {
                    Console.BackgroundColor = ConsoleColor.Cyan;
                }
                else if (cor == "azulE")
                {
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                }
                else if (cor == "cianoE")
                {
                    Console.BackgroundColor = ConsoleColor.DarkCyan;
                }
                else if (cor == "cinzaE")
                {
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                }
                else if (cor == "verdeE")
                {
                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                }
                else if (cor == "magentaE")
                {
                    Console.BackgroundColor = ConsoleColor.DarkMagenta;
                }
                else if (cor == "vermelhoE")
                {
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                }
                else if (cor == "amareloE")
                {
                    Console.BackgroundColor = ConsoleColor.DarkYellow;
                }
                else if (cor == "cinza")
                {
                    Console.BackgroundColor = ConsoleColor.Gray;
                }
                else if (cor == "verde")
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                }
                else if (cor == "magenta")
                {
                    Console.BackgroundColor = ConsoleColor.Magenta;
                }
                else if (cor == "vermelho")
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                }
                else if (cor == "amarelo")
                {
                    Console.BackgroundColor = ConsoleColor.Yellow;
                }
                else if (cor == "branco")
                {
                    Console.BackgroundColor = ConsoleColor.White;
                }
            }
        } //Função que subistitui o Console.BackgroundColor

        //Funções Relacionadas ao Menu
        //-----------------------------------
        public static string[] SortMenu(string[] vet)
        {
            for (int i = 0; i < vet.Length; i++)
            {
                for (int j = i; j > 0; j--)
                {
                    if (vet[j].Length > vet[j - 1].Length)
                    {
                        string temp = vet[j];
                        vet[j] = vet[j - 1];
                        vet[j - 1] = temp;
                    }
                }
            }
            return vet;
        } //Importante para o funcionamento do MostraMenu()
        public static void MostraMenu(string[] vet, string corDaCaixinha, string corLetra, string titulo)
        {
            string[] vetFor = new string[vet.Length];
            Array.Copy(vet, vetFor, vet.Length);
            vetFor = SortMenu(vetFor);
            //FAZ A PARTE DE CIMA
            {
                Cor(corDaCaixinha);
                for (int i = 0; i < 5; i++)//FAZ O MENU FICAR SEMPRE NO MEIO DA TELA
                {
                    Console.Write(" ");
                }
                Console.Write("■▄");
                Cor(corDaCaixinha);
                for (int j = 0; j < vetFor[0].Length + 6; j++)
                {
                    Console.Write("▄");
                }
                Console.Write("▄■");
                Console.WriteLine();
            }
            //FAZ A PARTE DO TITULO
            {
                for (int i = 0; i < 5; i++)//FAZ O MENU FICAR SEMPRE NO MEIO DA TELA
                {
                    Console.Write(" ");
                }
                Console.Write("█-");
                Cor(corLetra);
                if (vet.Length % 2 == 0)//ESSAS VERFICAÇÕES SÃO PARA DEIXAR BEM GENERICO
                {
                    for (int i = 0; i < (vetFor[0].Length / 2) + vet.Length / titulo.Length - 1; i++)
                    {
                        Console.Write(" ");//ESSES '(" ")' SÃO PARA DEIXAR O TITULO NO MEIO SEMPRE 
                    }
                    Console.Write("{0}", titulo);
                    for (int i = 0; i < (vetFor[0].Length / 2) + vet.Length / titulo.Length - 1; i++)
                    {
                        Console.Write(" ");
                    }
                }
                else if (vet.Length % 2 != 0)
                {
                    for (int i = 0; i < (vetFor[0].Length / 2) + (vet.Length / 3) - 2; i++)
                    {
                        Console.Write(" ");
                    }
                    Console.Write("{0}", titulo);
                    for (int i = 0; i < (vetFor[0].Length / 2) + (vet.Length / 3) - 1; i++)
                    {
                        Console.Write(" ");
                    }
                }
                Cor(corDaCaixinha);
                Console.WriteLine("-█");

                //TRAÇINHO EM BAIXO DO TITULO
                for (int i = 0; i < 5; i++)//FAZ O MENU FICAR SEMPRE NO MEIO DA TELA
                {
                    Console.Write(" ");
                }
                Console.Write("█");
                Cor(corDaCaixinha);
                for (int j = 0; j < vetFor[0].Length + 7; j++)
                {
                    Console.Write("-");
                }
                Console.WriteLine("-█");
            }
            //ESCREVE AS OPÇÕES DO MENU
            {
                for (int i = 0; i < vet.Length; i++)
                {
                    for (int j = 0; j < 5; j++)//FAZ O MENU FICAR SEMPRE NO MEIO DA TELA
                    {
                        Console.Write(" ");
                    }
                    Console.Write("█-");
                    Cor(corLetra);
                    Console.Write(" ({0}) {1} ", (i + 1), vet[i]);
                    for (int j = vet[i].Length; j < vetFor[0].Length; j++)
                    {
                        Console.Write(" ");
                    }
                    Cor(corDaCaixinha);
                    Console.WriteLine("-█");
                }
            }
            //FAZ A PARTE DE BAIXO
            {
                Cor(corDaCaixinha);
                for (int i = 0; i < 5; i++)//FAZ O MENU FICAR SEMPRE NO MEIO DA TELA
                {
                    Console.Write(" ");
                }
                Console.Write("■▀");
                for (int i = 0; i < vetFor[0].Length + 6; i++)
                {
                    Console.Write("▀");
                }
                Console.WriteLine("▀■");
                Console.ResetColor();
            }
        }//Menu Completo com titulo
        public static void MostraMenu(string[] vet, string corDaCaixinha, string corLetra)
        {
            string[] vetFor = new string[vet.Length];
            Array.Copy(vet, vetFor, vet.Length);
            vetFor = SortMenu(vetFor);
            //FAZ A PARTE DE CIMA
            {
                Cor(corDaCaixinha);
                for (int i = 0; i < (Console.WindowWidth / 2) - vetFor[0].Length; i++)//FAZ O MENU FICAR SEMPRE NO MEIO DA TELA
                {
                    Console.Write(" ");
                }
                Console.Write("■▄");
                Cor(corDaCaixinha);
                for (int j = 0; j < vetFor[0].Length + 2; j++)
                {
                    Console.Write("▄");
                }
                Console.Write("▄■");
                Console.WriteLine();
            }
            //ESCREVE AS OPÇÕES DO MENU
            {
                for (int i = 0; i < vet.Length; i++)
                {
                    for (int j = 0; j < (Console.WindowWidth / 2) - vetFor[0].Length; j++)//FAZ O MENU FICAR SEMPRE NO MEIO DA TELA
                    {
                        Console.Write(" ");
                    }
                    Console.Write("█-");
                    Cor(corLetra);
                    Console.Write(" {0} ", vet[i]);
                    for (int j = vet[i].Length; j < vetFor[0].Length; j++)
                    {
                        Console.Write(" ");
                    }
                    Cor(corDaCaixinha);
                    Console.WriteLine("-█");
                }
            }
            //FAZ A PARTE DE BAIXO
            {
                Cor(corDaCaixinha);
                for (int i = 0; i < (Console.WindowWidth / 2) - vetFor[0].Length; i++)//FAZ O MENU FICAR SEMPRE NO MEIO DA TELA
                {
                    Console.Write(" ");
                }
                Console.Write("■▀");
                for (int i = 0; i < vetFor[0].Length + 2; i++)
                {
                    Console.Write("▀");
                }
                Console.WriteLine("▀■");
                Console.ResetColor();
            }
        }//Menu Simples sem titulo
        public static void Inicio()
        {
            string[] inicio = new string[] { "Seja Bem Vindo!" };
            MostraMenu(inicio, "cianoE", "branco");
            Console.WriteLine("Esse programa foi feito por: Luan Pedrangelo - Turma C# Vesp.");
            Thread.Sleep(3000);
            Console.WriteLine("Aproveite!");
            Thread.Sleep(3000);
            //5Console.Clear();
        } //Apenas para Inicialização
        public static void Final()
        {
            Cor("verdeE");
            Console.WriteLine("Obrigado Por contartar nossos serviços!");
            Thread.Sleep(1000);
            Console.WriteLine("Esse programa foi feito por: Luan Pedrangelo - Turma C# Vesp.");
            Thread.Sleep(1000);
            Console.WriteLine(":)");
            Thread.Sleep(1000);
            Console.Clear();
            Console.ResetColor();
        } //Apenas para Finalização
    }
}
