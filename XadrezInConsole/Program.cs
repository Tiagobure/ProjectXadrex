using System;
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
                PartidaDeXadrez par = new PartidaDeXadrez();

                while (!par.Terminada)
                {
                    try {
                        Console.Clear();


                        Tela.ImprimirPartida(par);


                        Console.Write("Origem: ");
                        Posicao origem = Tela.LerPosicaoXadrez().ToPosicao();
                        par.ValidarPosicaoOrigem(origem);


                        bool[,] PosicoesPossiveis = par.Tab.Peca(origem).MovimentosPossiveis();

                        Console.Clear();
                        Tela.imprimirTabuleiro(par.Tab, PosicoesPossiveis);


                        Console.WriteLine();
                        Console.Write("Destino: ");
                        Posicao destino = Tela.LerPosicaoXadrez().ToPosicao();
                        par.ValidarPosicaoDestino(origem, destino);

                        par.RealizaJogada(origem, destino);

                    }
                    catch(TabuleiroException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
                    }

                Tela.imprimirTabuleiro(par.Tab);

            }
            catch (TabuleiroException e)
            {
                Console.WriteLine(e.Message);
            }
            //PosicaoXadrez pos = new PosicaoXadrez('c', 7);
            //Console.WriteLine(pos);
            //Console.WriteLine(pos.ToPosicao());


            Console.Read();

        }
    }
}
