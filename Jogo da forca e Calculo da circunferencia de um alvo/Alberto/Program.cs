using System;

namespace Alberto
{
    class Program
    {
        static void Main(string[] args)
        {
            EscolhaDeJogo();
        }

        public static void EscolhaDeJogo()
        {
            string[] menu = { "Jogo da Forca", "Alvo", "Sair" };
            MostraMenu(menu, "branco", "azulE", "Menu");
            int esc = CInt();
            switch (esc)
            {
                case 1:
                    JogoForca();
                    break;
                case 2:
                    Alvo();
                    break;
                case 3:
                    Environment.Exit(0);
                    break;
                default:
                    Console.Clear();
                    break;
            }
        }


        //Jogo da Forca
        //======================================================
        public static void JogoForca()
        {
            Console.Clear();
            string[] menu = { "Inserir Palavra", "Jogar" };
            int erro = 6;
            int acerto = 0;
            int verif = 0;
            char letra;
            string palavra = "";
            bool jogar = false, conf = false, ganhou = false;
            while (!jogar)
            {
                MostraMenu(menu, "vermelhoE", "branco", "Forca");
                Cor("branco");
                int esc = CInt();
                switch (esc)
                {
                    case 1:
                        Console.WriteLine("Digite a palavra para outra pessoa tentar adivinhar:");
                        palavra = CString();
                        Cor("vermelhoE");
                        Console.WriteLine($"Muito bem a palavra será -> {palavra}");
                        string[] vetor = new string[palavra.Length];
                        Console.Write("[ENTER]");
                        CString();
                        conf = true;
                        Console.Clear();
                        Cor("branco");
                        break;
                    case 2:
                        vetor = new string[palavra.Length];
                        if (conf)
                        {
                            while (erro > 0 && verif != vetor.Length)
                            {
                                Palavra(vetor);
                                Console.WriteLine(" Você tem {0} tentativas, insira a letra para tentar Adivinhar: ", erro);
                                letra = CChar();
                                Console.Clear();
                                int verificar = palavra.IndexOf(letra);
                                if (verificar == -1)
                                {
                                    erro--;
                                }
                                else
                                {
                                    acerto++;
                                    for (int i = 0; i < palavra.Length; i++)
                                    {

                                        if (palavra[i].ToString() == letra.ToString())
                                        {
                                            vetor[i] = letra.ToString();
                                            if (vetor[i] != null && vetor[i] != "_ ")
                                            {
                                                verif++;
                                            }
                                        }
                                        else if (vetor[i] == null)
                                        {
                                            vetor[i] = "_ ";
                                        }



                                    }


                                }
                                if (erro == 0)
                                {
                                    Console.WriteLine();
                                    Console.Clear();
                                    // Pontuacao(erro, acerto);
                                    Console.WriteLine();
                                    Palavra(vetor);
                                    Console.WriteLine();
                                    Cor("vermelhoE");
                                    Console.WriteLine("*Você PERDEU*");
                                    Console.Write("[ENTER]");
                                    CString();
                                    EscolhaDeJogo();
                                }
                                else if (verif == palavra.Length)
                                {
                                    Console.WriteLine();
                                    Console.Clear();
                                    Palavra(vetor);
                                    Console.WriteLine();
                                    Cor("verdeE");
                                    Console.WriteLine("*Você GANHOU*");
                                    Console.Write("[ENTER]");
                                    CString();
                                    EscolhaDeJogo();
                                }
                                else
                                {
                                    // Pontuacao(erro, acerto);
                                }
                            }
                        }
                        else
                        {
                            Cor("vermelhoE");
                            Console.WriteLine("*ERRO INSIRA UMA PALAVRA ANTES PARA JOGAR*");
                            jogar = true;
                        }
                        break;
                    default:
                        break;
                }
            }
        }
        public static void Palavra(string[] vetor)
        {
            foreach (var item in vetor)
            {
                Cor("vermelhoE");
                Console.Write(item);
                Console.ResetColor();
            }
            Console.WriteLine();
        }

        //Alvo
        //==========================================================
        public static void Alvo()
        {
            Cor("verdeE");
            Console.WriteLine("Qual o raio da argola maior?");
            double raio6 = CDoub();
            double circun;
            circun = raio6 * 6.28;

            double temp = circun / 6;
            circun -= temp;
            double raio5 = circun / 6.28;
             
            temp = 0;
            temp = circun / 5;
            circun -= temp;
            double raio4 = circun / 6.28;

            temp = 0;
            temp = circun/4;
            circun -= temp;
            double raio3 = circun / 6.28;

            temp = 0;
            temp = circun / 3;
            circun -= temp;
            double raio2 = circun / 6.28;

            temp = 0;
            temp = circun / 2;
            circun -= temp;
            double raio1 = circun / 6.28;

            Cor("azulE");
            Console.Write("|");
            Cor("branco");
            Console.Write("{0:#.#}cm", raio6);
            Cor("azulE");
            Console.Write("|  ");

            Cor("vermelhoE");
            Console.Write("|");
            Cor("branco");
            Console.Write("{0:#.#}cm", raio5);
            Cor("vermelhoE");
            Console.Write("|  ");

            Cor("magentaE");
            Console.Write("|");
            Cor("branco");
            Console.Write("{0:#.#}cm", raio4);
            Cor("magentaE");
            Console.Write("|  ");

            Cor("amareloE");
            Console.Write("|");
            Cor("branco");
            Console.Write("{0:#.#}cm", raio3);
            Cor("amareloE");
            Console.Write("|  ");

            Cor("verdeE");
            Console.Write("|");
            Cor("branco");
            Console.Write("{0:#.#}cm", raio2);
            Cor("verdeE");
            Console.Write("|  ");

            Cor("azulE");
            Console.Write("|");
            Cor("branco");
            Console.Write("{0:#.#}cm", raio1);
            Cor("azulE");
            Console.Write("|  ");

            Cor("verdeE");
            Console.WriteLine("[ENTER]");
            CString();
            Console.Clear();
            EscolhaDeJogo();
        }



        //Funções base
        //-----------------------------------------
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
                if (titulo == "Menu")//ESSAS VERFICAÇÕES SÃO PARA DEIXAR BEM GENERICO
                {
                    for (int i = 0; i < 7; i++)
                    {
                        Console.Write(" ");//ESSES '(" ")' SÃO PARA DEIXAR O TITULO NO MEIO SEMPRE 
                    }
                    Console.Write("{0}", titulo);
                    for (int i = 0; i < 8; i++)
                    {
                        Console.Write(" ");
                    }
                }
                else if (titulo == "Forca")
                {
                    for (int i = 0; i < 8; i++)
                    {
                        Console.Write(" ");//ESSES '(" ")' SÃO PARA DEIXAR O TITULO NO MEIO SEMPRE 
                    }
                    Console.Write("{0}", titulo);
                    for (int i = 0; i < 8; i++)
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
    }
}
