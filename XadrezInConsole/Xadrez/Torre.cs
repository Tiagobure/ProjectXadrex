using Tabuleiro;

namespace Xadrez
{
    class Torre : Peca
    {
        public Torre (Tabuleiroo tab, Cor cor)
            : base(cor, tab)
        {
        }


        public override string ToString()
        {

            return "T";
        }
    }
}
    

