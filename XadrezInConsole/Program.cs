﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tabuleiro;
using Xadrez;

namespace XadrezInConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Tabuleiroo tab = new Tabuleiroo(8, 8);
                tab.ColocarPeca(new Torre(tab, Cor.preta), new Posicao(0, 6));
                tab.ColocarPeca(new Torre(tab, Cor.preta), new Posicao(1, 5));
                tab.ColocarPeca(new Rei(tab, Cor.preta), new Posicao(0, 6));



                Tela.imprimirTabuleiro(tab);
            }catch(TabuleiroException e)
            {
                Console.WriteLine(e.Message);
            }

            Console.Read();

        }
    }
}
