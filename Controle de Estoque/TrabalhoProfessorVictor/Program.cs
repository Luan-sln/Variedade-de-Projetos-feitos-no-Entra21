using System;
using System.Threading;

namespace TrabalhoProfessorVictor
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] estoque;
            GeraBD log = new GeraBD();
            estoque = log.GeraMatriz();
            Inicio(); //Pode-se comentar essa função para não precisar ver a inicalização todas as vezes que der F5
            OrganizaMatriz(estoque);
            MostraMenu(estoque);
        }


        public static string CString()
        {
            return Convert.ToString(Console.In.ReadLine());
        } //Função que subistitui o ReadLine
        public static int CInt()
        {
            return Convert.ToInt32(Console.In.ReadLine());
        } //Função que subistitui o Convert.ToInt32
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
        public static void Inicio()
        {
            Cor("cianoE");
            Console.WriteLine("       ■▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄■");
            Console.Write("       █ ");
            Cor("branco");
            Console.Write("Seja Bem Vindo!!");
            Cor("cianoE");
            Console.WriteLine(" █");
            Console.WriteLine("       ■▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀■");
            Thread.Sleep(3500);
            Cor("branco");
            Console.WriteLine("Esse programa foi feito por: Luan Pedrangelo - Turma C# Vesp.");
            Thread.Sleep(3000);
            Console.WriteLine("Para Melhores Visualizações, é recomendável que deixe o Console em Full Screen");
            Thread.Sleep(5000);
            Console.WriteLine("Aproveite!");
            Thread.Sleep(3000);
            Console.Clear();
        } //Apenas para Inicialização
        public static void MostraMenu(int[][] estoque)
        {
            Console.Clear();
            Cor("vermelhoE");
            Console.WriteLine("   ■▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄■");
            Console.Write("   █-          ");
            Cor("branco");
            Console.Write("Menu");
            Cor("vermelhoE");
            Console.WriteLine("          -█");
            Console.Write("   █--------------------------█");
            Console.WriteLine();
            Console.Write("   █- ");
            Cor("branco");
            Console.Write("(1) Adicionar Itens    ");
            Cor("vermelhoE");
            Console.WriteLine("-█");
            Console.Write("   █- ");
            Cor("branco");
            Console.Write("(2) Retirar itens      ");
            Cor("vermelhoE");
            Console.WriteLine("-█");
            Console.Write("   █- ");
            Cor("branco");
            Console.Write("(3) Ver Estoque        ");
            Cor("vermelhoE");
            Console.WriteLine("-█");
            Console.Write("   █- ");
            Cor("branco");
            Console.Write("(4) Ver Estoque Org.   ");
            Cor("vermelhoE");
            Console.WriteLine("-█");
            Console.Write("   █- ");
            Cor("branco");
            Console.Write("(5) Sair do Programa   ");
            Cor("vermelhoE");
            Console.WriteLine("-█");
            Console.WriteLine("   ▄▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▄");
            Cor("branco");

            Console.Write("-> ");
            int escolhaMenu = CInt();
            switch (escolhaMenu)
            {
                case 1:
                    Adicionar(estoque);
                    break;
                case 2:
                    Remover(estoque);
                    break;
                case 3:
                    MostraMatriz(estoque);
                    Console.WriteLine("Pressione [ENTER] para voltar");
                    Console.Write("[ENTER]");
                    string sair = CString();
                    MostraMenu(estoque);
                    break;
                case 4:
                    OrganizaMatriz(estoque);
                    MostraMatriz(estoque);
                    Console.WriteLine("Pressione [ENTER] para voltar");
                    Console.Write("[ENTER]");
                    string saira = CString();
                    MostraMenu(estoque);
                    break;
                case 5:
                    Final();
                    break;
                default:
                    break;
            }
        } //Menu com as opções para o Usuário
        public static void Adicionar(int[][] estoque)
        {
            bool voltar = true;
            while (voltar)
            {
                Cor("cinzaE");
                Console.WriteLine("■▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄■");
                Console.Write("█- ");
                Cor("branco");
                Console.Write("    Categorias    ");
                Cor("cinzaE");
                Console.WriteLine("  -█");
                Console.Write("█-----------------------█");
                Console.WriteLine();
                Console.Write("█- ");
                Cor("branco");
                Console.Write("(1) Alimento");
                Cor("cinzaE");
                Console.WriteLine("        -█");
                Console.Write("█- ");
                Cor("branco");
                Console.Write("(2) Higiene Pessoal");
                Cor("cinzaE");
                Console.WriteLine(" -█");
                Console.Write("█- ");
                Cor("branco");
                Console.Write("(3) Limpeza");
                Cor("cinzaE");
                Console.WriteLine("         -█");
                Console.Write("█- ");
                Cor("branco");
                Console.Write("(4) Utensílios");
                Cor("cinzaE");
                Console.WriteLine("      -█");
                Console.Write("█- ");
                Cor("branco");
                Console.Write("(5) Voltar");
                Cor("cinzaE");
                Console.WriteLine("          -█");
                Console.WriteLine("▄▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▄");
                Cor("branco");

                Console.Write("-> ");
                int categoria;
                categoria = CInt();
                Console.Clear();
                bool p = true;

                switch (categoria)
                {
                    case 1:
                        for (int i = 0; i < estoque.Length && p == true; i++)
                        {
                            for (int j = 0; j < estoque[i].Length; j++)
                            {
                                if (i >= 0 && i < 10)
                                {
                                    if (estoque[i][j] == 0)
                                    {
                                        estoque[i][j] = categoria;
                                        Cor("cianoE");
                                        Console.WriteLine("Adicionado");
                                        Cor("branco");
                                        OrganizaMatriz(estoque);
                                        p = false;
                                        break;
                                    }
                                }
                                else
                                {
                                    Cor("verdeE");
                                    Console.WriteLine("Sinto Muito, mas esta categoria já esta cheia :(");
                                    Console.WriteLine("Digite outro número ou retire algum produto do estoque.");
                                    Cor("branco");
                                    Thread.Sleep(3000);
                                    p = false;
                                    break;
                                }
                            }
                        }
                        break;
                    case 2:
                        for (int i = 0; i < estoque.Length && p == true; i++)
                        {
                            for (int j = 0; j < estoque[i].Length; j++)
                            {

                                if (i >= 0 && i < 20)
                                {
                                    if (estoque[i][j] == 0)
                                    {
                                        estoque[i][j] = categoria;
                                        Cor("vermelhoE");
                                        Console.WriteLine("Adicionado");
                                        Cor("branco");
                                        OrganizaMatriz(estoque);
                                        p = false;
                                        break;
                                    }
                                }
                                else
                                {
                                    Cor("verdeE");
                                    Console.WriteLine("Sinto Muito, mas esta categoria já esta cheia :(");
                                    Console.WriteLine("Digite outro número ou retire algum produto do estoque.");
                                    Cor("branco");
                                    Thread.Sleep(3000);
                                    Console.Clear();
                                    p = false;
                                    break;
                                }
                            }
                        }
                        break;
                    case 3:
                        for (int i = 0; i < estoque.Length && p == true; i++)
                        {
                            for (int j = 0; j < estoque[i].Length; j++)
                            {
                                if (i >= 0 && i < 30)
                                {
                                    if (estoque[i][j] == 0)
                                    {
                                        estoque[i][j] += categoria;
                                        Cor("magentaE");
                                        Console.WriteLine("Adicionado");
                                        Cor("branco");
                                        OrganizaMatriz(estoque);
                                        p = false;
                                        break;
                                    }
                                }
                                else
                                {
                                    Cor("verdeE");
                                    Console.WriteLine("Sinto Muito, mas esta categoria já esta cheia :(");
                                    Console.WriteLine("Digite outro número ou retire algum produto do estoque.");
                                    Cor("branco");
                                    Thread.Sleep(3000);
                                    Console.Clear();
                                    p = false;
                                    break;
                                }
                            }
                        }
                        break;
                    case 4:
                        for (int i = 0; i < estoque.Length && p == true; i++)
                        {
                            for (int j = 0; j < estoque[i].Length; j++)
                            {
                                if (i >= 00 && i < 40)
                                {
                                    if (estoque[i][j] == 0)
                                    {
                                        estoque[i][j] += categoria;
                                        Cor("azulE");
                                        Console.WriteLine("Adicionado");
                                        Cor("branco");
                                        OrganizaMatriz(estoque);
                                        p = false;
                                        break;
                                    }
                                }
                                else
                                {
                                    Cor("verdeE");
                                    Console.WriteLine("Sinto Muito, mas esta categoria já esta cheia :(");
                                    Console.WriteLine("Digite outro número ou retire algum produto do estoque.");
                                    Cor("branco");
                                    Thread.Sleep(3000);
                                    Console.Clear();
                                    p = false;
                                    break;
                                }
                            }
                        }
                        break;
                    case 5:
                        voltar = false;
                        Console.Clear();
                        MostraMenu(estoque);
                        break;
                    default:
                        Cor("vermelhoE");
                        Console.WriteLine("Digite um número válido!");
                        Cor("branco");
                        break;
                }
            }
        } //Adiciona itens na Matriz
        public static void Remover(int[][] estoque)
        {
            bool voltar = false;
            do
            {
                string coluna;
                int linha;
                {
                    Console.Write("     ");
                    for (int i = 0; i < estoque.Length; i++)
                    {
                        linha = (i + 1);
                        if (linha < 10)
                        {
                            Console.Write(" 0{0}", linha);

                        }
                        else
                        {
                            Console.Write(" {0}", linha);

                        }
                    }
                    Console.WriteLine();
                    Console.WriteLine("    __________________________________________________________________________________________________________________________");
                } //Mostra a Coluna
                Cor("branco");
                for (int i = 0; i < estoque.Length; i++)
                {
                    Cor("branco");
                    coluna = " |-";

                    if (i < 9)
                    {
                        Console.Write("0" + (i + 1) + coluna);
                    }
                    else
                    {
                        Console.Write((i + 1) + coluna);
                    }
                    for (int j = 0; j < estoque[i].Length; j++)
                    {
                        if (estoque[i][j] == 1)
                        {
                            Cor("cianoE");
                        }
                        else if (estoque[i][j] == 2)
                        {
                            Cor("vermelhoE");
                        }
                        else if (estoque[i][j] == 3)
                        {
                            Cor("magentaE");
                        }
                        else if (estoque[i][j] == 4)
                        {
                            Cor("azulE");
                        }
                        else if (estoque[i][j] == 0)
                        {
                            Cor("cinzaE");
                        }
                        if (estoque[i][j] < 9)
                        {

                            Console.Write(" 0{0}", estoque[i][j]);
                        }
                    }
                    Cor("branco");
                    coluna = "-|";
                    Console.WriteLine(coluna);
                } //Printa A Matriz
                Console.WriteLine("Escolha a Linha e a Coluna:");
                Console.Write("Linha -> ");
                int escolhaL = CInt();
                escolhaL--;
                Console.Write("Coluna -> ");
                int escolhaC = CInt();
                escolhaC--;
                estoque[escolhaL][escolhaC] = 0;
                Console.Clear();
                {
                    Console.Write("     ");
                    for (int i = 0; i < estoque.Length; i++)
                    {
                        linha = (i + 1);
                        if (linha < 10)
                        {
                            Console.Write(" 0{0}", linha);

                        }
                        else
                        {
                            Console.Write(" {0}", linha);

                        }
                    }
                    Console.WriteLine();
                    Console.WriteLine("    __________________________________________________________________________________________________________________________");
                } //Mostra a Coluna
                Cor("branco");
                for (int i = 0; i < estoque.Length; i++)
                {
                    Cor("branco");
                    coluna = " |-";

                    if (i < 9)
                    {
                        Console.Write("0" + (i + 1) + coluna);
                    }
                    else
                    {
                        Console.Write((i + 1) + coluna);
                    }
                    for (int j = 0; j < estoque[i].Length; j++)
                    {
                        if (estoque[i][j] == 1)
                        {
                            Cor("cianoE");
                        }
                        else if (estoque[i][j] == 2)
                        {
                            Cor("vermelhoE");
                        }
                        else if (estoque[i][j] == 3)
                        {
                            Cor("magentaE");
                        }
                        else if (estoque[i][j] == 4)
                        {
                            Cor("azulE");
                        }
                        else if (estoque[i][j] == 0)
                        {
                            Cor("cinzaE");
                        }
                        if (estoque[i][j] < 9)
                        {

                            Console.Write(" 0{0}", estoque[i][j]);
                        }
                    }
                    Cor("branco");
                    coluna = "-|";
                    Console.WriteLine(coluna);
                } //Printa A Matriz
                Console.WriteLine("Remover mais algum?(s/n)");
                Console.Write("-> ");
                char esc = Convert.ToChar(Console.In.ReadLine());
                if (esc == 's')
                {
                    Console.Clear();
                    voltar = true;
                }
                else
                {
                    MostraMenu(estoque);
                    break;
                }
            } while (voltar);

        } //Remove itens na Matriz
        public static void OrganizaMatriz(int[][] estoque)
        {
            for (int i = 0; i < estoque.Length; i++)
            {
                for (int j = 0; j < estoque[i].Length; j++)
                {
                    //Verificações por categoria para a Organização
                    {
                        if (estoque[i][j] == 1) //Arruma 1;
                        {
                            for (int a = 0; a < estoque.Length; a++)
                            {
                                for (int b = 0; b < estoque[a].Length; b++)
                                {
                                    if (a >= 0 && a < 10)
                                    {
                                        if (estoque[a][b] == 0)
                                        {
                                            int temp = estoque[a][b];
                                            estoque[a][b] = estoque[i][j];
                                            estoque[i][j] = temp;

                                        }
                                    }
                                }
                            }
                        }
                        else if (estoque[i][j] == 2) //Arruma 2;
                        {
                            for (int a = 0; a < estoque.Length; a++)
                            {
                                for (int b = 0; b < estoque[a].Length; b++)
                                {
                                    if (a >= 10 && a < 20)
                                    {
                                        if (estoque[a][b] == 0)
                                        {
                                            int temp = estoque[a][b];
                                            estoque[a][b] = estoque[i][j];
                                            estoque[i][j] = temp;

                                        }
                                    }
                                }
                            }
                        }
                        else if (estoque[i][j] == 3) //Arruma 3;
                        {
                            for (int a = 0; a < estoque.Length; a++)
                            {
                                for (int b = 0; b < estoque[a].Length; b++)
                                {
                                    if (a >= 20 && a < 30)
                                    {
                                        if (estoque[a][b] == 0)
                                        {
                                            int temp = estoque[a][b];
                                            estoque[a][b] = estoque[i][j];
                                            estoque[i][j] = temp;

                                        }
                                    }
                                }
                            }
                        }
                        else if (estoque[i][j] == 4) //Arruma 4;
                        {
                            for (int a = 0; a < estoque.Length; a++)
                            {
                                for (int b = 0; b < estoque[a].Length; b++)
                                {
                                    if (a >= 30 && a < 40)
                                    {
                                        if (estoque[a][b] == 0)
                                        {
                                            if (estoque[a][b] == 0)
                                            {
                                                int temp = estoque[a][b];
                                                estoque[a][b] = estoque[i][j];
                                                estoque[i][j] = temp;

                                            }

                                        }
                                    }
                                }
                            }
                        }
                    }

                }
            } //Arruma Matriz
        } //Organiza a matriz e printa na tela
        public static void MostraMatriz(int[][] estoque)
        {
            string coluna;
            int linha;
            Cor("branco");
            {
                Console.Write("     ");
                for (int i = 0; i < estoque.Length; i++)
                {
                    linha = (i + 1);
                    if (linha < 10)
                    {
                        Console.Write(" 0{0}", linha);

                    }
                    else
                    {
                        Console.Write(" {0}", linha);

                    }
                }
                Console.WriteLine();
                Console.WriteLine("    __________________________________________________________________________________________________________________________");
            } //Mostra a Coluna
            for (int i = 0; i < estoque.Length; i++)
            {
                Cor("branco");
                coluna = " |-";

                if (i < 9)
                {
                    Console.Write("0" + (i + 1) + coluna);
                }
                else
                {
                    Console.Write((i + 1) + coluna);
                }
                for (int j = 0; j < estoque[i].Length; j++)
                {
                    if (estoque[i][j] == 1)
                    {
                        Cor("cianoE");
                    }
                    else if (estoque[i][j] == 2)
                    {
                        Cor("vermelhoE");
                    }
                    else if (estoque[i][j] == 3)
                    {
                        Cor("magentaE");
                    }
                    else if (estoque[i][j] == 4)
                    {
                        Cor("azulE");
                    }
                    else if (estoque[i][j] == 0)
                    {
                        Cor("cinzaE");
                    }
                    if (estoque[i][j] < 9)
                    {

                        Console.Write(" 0{0}", estoque[i][j]);
                    }
                }
                Cor("branco");
                coluna = "-|";
                Console.WriteLine(coluna);
            } //Printa A Matriz
        } //Printa a matriz na tela
        public static void Final()
        {
            Cor("verdeE");
            Console.WriteLine("Obrigado Por contartar nossos serviços!");
            Thread.Sleep(1000);
            Console.WriteLine("Esse programa foi feito por: Luan Pedrangelo - Turma C# Vesp.");
            Thread.Sleep(2000);
            Console.WriteLine(":)");
            Thread.Sleep(1000);
            Console.Clear();
        } //Apenas para Finalização
    }
}
