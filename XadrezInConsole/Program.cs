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
                    Console.Clear();


                    Tela.imprimirTabuleiro(par.Tab);

                    Console.WriteLine("------------------");
                    Console.Write("Origem: ");
                    Posicao origem = Tela.LerPosicaoXadrez().ToPosicao();
                    Console.Write("Destino: ");
                    Posicao destino = Tela.LerPosicaoXadrez().ToPosicao();

                    par.ExecultaMovimento(origem, destino);

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
