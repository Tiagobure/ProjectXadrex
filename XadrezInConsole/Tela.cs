using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tabuleiro;
using Xadrez;


namespace XadrezInConsole
{
    class Tela
    {

        public static void ImprimirPartida(PartidaDeXadrez par)
        {
            imprimirTabuleiro(par.Tab);
            Console.WriteLine("------------------");
            Console.WriteLine();
            ImprimirPecasCapituradas(par);
            Console.WriteLine();
            Console.WriteLine("Turno " + par.Turno);
            if (!par.Terminada)
            {
                Console.WriteLine("Aguardando jogada: " + par.JogadorAtual);

                if (par.Xeque)
                {
                    Console.WriteLine("XEQUE!");
                    Console.WriteLine();

                }
            }
            else if(par.Terminada)
            {
                Console.WriteLine("XEQUE MATE!!");
                Console.WriteLine("Vencedor: " + par.JogadorAtual);
            }


        }

        public static void ImprimirPecasCapituradas(PartidaDeXadrez par)
        {
            Console.WriteLine("Peças capituradas:");
            Console.Write("Brancas:");
            ImprimirConjunto(par.PecasCapituradas(Cor.branca));
            Console.Write("Pretas:");
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            ImprimirConjunto(par.PecasCapituradas(Cor.preta));
            Console.ForegroundColor = aux;


        }
        public static void ImprimirConjunto(HashSet<Peca> conjunto)
        {
            Console.Write("[");
            foreach (Peca x in conjunto)
            {
                Console.Write(x + " ");
            }
            Console.WriteLine("]");
        }
        public static void imprimirTabuleiro(Tabuleiroo tab)
        {
            for (int i = 0; i < tab.linhas; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < tab.colunas; j++)
                {
                    ImprimirPeca(tab.Peca(i, j));

                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }
        public static void imprimirTabuleiro(Tabuleiroo tab, bool[,] posicoesPossiveis)
        {
            ConsoleColor FundoOriginal = Console.BackgroundColor;
            ConsoleColor FundoAlterado = ConsoleColor.DarkRed;

            for (int i = 0; i < tab.linhas; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < tab.colunas; j++)
                {
                    if (posicoesPossiveis[i, j] == true)
                    {
                        Console.BackgroundColor = FundoAlterado;
                    }
                    else
                    {
                        Console.BackgroundColor = FundoOriginal;
                    }
                    ImprimirPeca(tab.Peca(i, j));
                    Console.BackgroundColor = FundoOriginal;


                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
            Console.BackgroundColor = FundoOriginal;
        }

        public static PosicaoXadrez LerPosicaoXadrez()
        {
            string s = Console.ReadLine();
            char Coluna = s[0];
            int Linha = int.Parse(s[1] + " ");
            return new PosicaoXadrez(Coluna, Linha);
        }


        public static void ImprimirPeca(Peca peca)
        {
            if (peca == null)
            {
                Console.Write("- ");
            }
            else
            {

                if (peca.Cor == Cor.branca)
                {
                    Console.Write(peca);
                }
                else
                {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(peca);
                    Console.ForegroundColor = aux;
                }
                Console.Write(" ");
            }
        }
    }
}
