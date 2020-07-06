using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tabuleiro;

namespace XadrezInConsole
{
    class Tela
    {
        public static void imprimirTabuleiro(Tabuleiroo tab)
        {
            for(int i = 0; i <tab.linhas; i++)
            {
                for(int j = 0; j <tab.colunas; j++)
                {
                    if (tab.Peca(i, j) == null)
                    {
                        Console.Write("- ");
                    }
                    else {
                        Console.Write(tab.Peca(i, j) + " ");
                            }
                }
                Console.WriteLine();
            }

        }
    }
}
