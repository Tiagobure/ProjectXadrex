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
            Posicao p;
            p = new Posicao(2, 4);

            Console.WriteLine(p);
            Console.ReadLine();

        }
    }
}
