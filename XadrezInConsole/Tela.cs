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
        public static void imprimirTabuleiro(Tabuleiroo tab)
        {
            for(int i = 0; i <tab.linhas; i++)

            {
                Console.Write(8 - i + " ");
                for(int j = 0; j <tab.colunas; j++)
                {
                    if (tab.Peca(i, j) == null)
                    {
                        Console.Write("- ");
                    }
                    else {
                        ImprimirPeca(tab.Peca(i, j));
                        Console.Write(" ");
                            }
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }


        public static PosicaoXadrez LerPosicaoXadrez()
        {
            string s = Console.ReadLine();
            char Coluna = s[0];
            int Linha = int.Parse(s[1] + " ");
            return new PosicaoXadrez(Coluna, Linha);
        }

        public static void ImprimirPeca(Peca peca)
        {if(peca.Cor == Cor.branca)
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

        }
    }
}
