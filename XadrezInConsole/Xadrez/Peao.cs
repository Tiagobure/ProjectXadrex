using Tabuleiro;

namespace Xadrez
{
    class Peao : Peca
    {
        private PartidaDeXadrez Partida;
         
        public Peao(Tabuleiroo tab, Cor cor, PartidaDeXadrez partida) : base(cor, tab)
        {
            Partida = partida;
        }
        public override string ToString()
        {

            return "p";
        }

        private bool ExisteInimigo(Posicao pos)
        {
            Peca p = Tab.Peca(pos);
            return p != null && p.Cor != Cor;
        }
        private bool Livre(Posicao pos)
        {
            return Tab.Peca(pos) == null;
        }
        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[Tab.linhas, Tab.colunas];

            Posicao pos = new Posicao(0, 0);

            if (Cor == Cor.branca)
            {
                pos.DefinirValores(Posicao.Linha -1, Posicao.Coluna);
                if (Tab.PosicaoValida(pos) && Livre(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }
                pos.DefinirValores(Posicao.Linha -2 , Posicao.Coluna);
                if (Tab.PosicaoValida(pos) && Livre(pos) && QteMovimentos == 0)
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }
                pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna - 1);
                if (Tab.PosicaoValida(pos) && ExisteInimigo(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }
                pos.DefinirValores(Posicao.Linha -1 , Posicao.Coluna + 1);
                if (Tab.PosicaoValida(pos) && ExisteInimigo(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }

                //#jogadaespecial passant
                if(Posicao.Linha == 3)
                {
                    Posicao Esquerda = new Posicao(Posicao.Linha, Posicao.Coluna - 1);
                    if(Tab.PosicaoValida(Esquerda) && ExisteInimigo(Esquerda) && Tab.Peca(Esquerda) == Partida.VuneravelEnPassant)
                    {
                        mat[Esquerda.Linha - 1, Esquerda.Coluna] = true;
                    }
                    Posicao Direita = new Posicao(Posicao.Linha, Posicao.Coluna + 1);
                    if (Tab.PosicaoValida(Direita) && ExisteInimigo(Direita) && Tab.Peca(Direita) == Partida.VuneravelEnPassant)
                    {
                        mat[Direita.Linha - 1, Direita.Coluna] = true;
                    }
                }

            }
            else
            {
                pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna);
                if (Tab.PosicaoValida(pos) && Livre(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }
                pos.DefinirValores(Posicao.Linha + 2, Posicao.Coluna);
                if (Tab.PosicaoValida(pos) && Livre(pos) && QteMovimentos == 0)
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }
                pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna + 1);
                if (Tab.PosicaoValida(pos) && ExisteInimigo(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }
                pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna - 1);
                if (Tab.PosicaoValida(pos) && ExisteInimigo(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }

                //#jogadaespecial passant
                if (Posicao.Linha == 4)
                {
                    Posicao Esquerda = new Posicao(Posicao.Linha, Posicao.Coluna - 1);
                    if (Tab.PosicaoValida(Esquerda) && ExisteInimigo(Esquerda) && Tab.Peca(Esquerda) == Partida.VuneravelEnPassant)
                    {
                        mat[Esquerda.Linha +1, Esquerda.Coluna] = true;
                    }
                    Posicao Direita = new Posicao(Posicao.Linha, Posicao.Coluna + 1);
                    if (Tab.PosicaoValida(Direita) && ExisteInimigo(Direita) && Tab.Peca(Direita) == Partida.VuneravelEnPassant)
                    {
                        mat[Direita.Linha +1, Direita.Coluna] = true;
                    }
                }


            }
            return mat;
        }
    }
}
