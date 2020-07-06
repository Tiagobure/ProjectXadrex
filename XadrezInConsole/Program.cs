using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tabuleiro;

namespace XadrezInConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Tabuleiroo tab = new Tabuleiroo(8,8);

            Tela.imprimirTabuleiro(tab);


            Console.Read();

        }
    }
}
