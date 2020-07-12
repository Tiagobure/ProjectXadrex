using Tabuleiro;

namespace Xadrez
{
    class Rei : Peca
    {
        private PartidaDeXadrez partida;
        
        

        public Rei(Tabuleiroo tab, Cor cor, PartidaDeXadrez partida)
            : base(cor, tab)
        {
            this.partida = partida;
        }


        public override string ToString()
        {

            return "R";
        }

        private bool PodeMover(Posicao pos)
        {
            Peca p = Tab.Peca(pos);
            return p == null || p.Cor != Cor;

        }
        private bool TestTorreParaRoque(Posicao pos) {
            Peca p = Tab.Peca(pos);
            return p != null && p is Torre && p.Cor == Cor && p.QteMovimentos == 0;
        }

       public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[Tab.linhas, Tab.colunas];

            Posicao pos = new Posicao(0, 0);

            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna);
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna + 1);
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            pos.DefinirValores(Posicao.Linha, Posicao.Coluna + 1);
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna + 1);
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna);
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna -1);
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            pos.DefinirValores(Posicao.Linha, Posicao.Coluna - 1);
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna - 1);
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            //#jogadaespecial
            if (QteMovimentos == 0 && !partida.Xeque)
            {
                //reoque pequeno
                Posicao PosTorre = new Posicao(Posicao.Linha, Posicao.Coluna + 3);
                if (TestTorreParaRoque(PosTorre))
                {
                    Posicao p1 = new Posicao(Posicao.Linha,Posicao.Coluna + 1);
                    Posicao p2 = new Posicao(Posicao.Linha, Posicao.Coluna + 2);
                    if (Tab.Peca(p1) == null && Tab.Peca(p2) == null)
                    {
                        mat[Posicao.Linha, Posicao.Coluna + 2] = true;

                    }
                }
                //#jogadaespecisl Rooque Grande
                Posicao PosTorre2 = new Posicao(Posicao.Linha, Posicao.Coluna - 4);
                if (TestTorreParaRoque(PosTorre2))
                {
                    Posicao p1 = new Posicao(Posicao.Linha, Posicao.Coluna - 1);
                    Posicao p2 = new Posicao(Posicao.Linha, Posicao.Coluna - 2);
                    Posicao p3 = new Posicao(Posicao.Linha, Posicao.Coluna - 3);

                    if (Tab.Peca(p1) == null && Tab.Peca(p2) == null && Tab.Peca(p3) == null)
                    {
                        mat[Posicao.Linha, Posicao.Coluna - 2] = true;

                    }
                }
            }


            return mat;
        }

    }
}


