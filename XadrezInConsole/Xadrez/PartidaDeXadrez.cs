using System.Collections.Generic;
using Tabuleiro;

namespace Xadrez
{
    class PartidaDeXadrez
    {
        public Tabuleiroo Tab { get; private set; }
        public int Turno { get; private set; }
        public Cor JogadorAtual { get; private set; }
        public bool Terminada { get; private set; }
        public bool Xeque { get; private set; }
        private HashSet<Peca> Pecas;
        private HashSet<Peca> Capituradas;

        public PartidaDeXadrez()
        {
            Tab = new Tabuleiroo(8, 8);
            Turno = 1;
            JogadorAtual = Cor.branca;
            Terminada = false;
            Xeque = false;
            Pecas = new HashSet<Peca>();
            Capituradas = new HashSet<Peca>();
            ColocarPecas();


        }
        public Peca ExecultaMovimento(Posicao origem, Posicao destino)
        {
            Peca p = Tab.RetirarPeca(origem);
            p.IncrementarQteMovimentos();
            Peca PecaCapturada = Tab.RetirarPeca(destino);
            Tab.ColocarPeca(p, destino);
            if (PecaCapturada != null)
            {
                Capituradas.Add(PecaCapturada);
            }
            return PecaCapturada;
        }

        public void DesfazerMovimento(Posicao origem, Posicao destino, Peca pecaCapiturada)
        {
            Peca p = Tab.RetirarPeca(destino);
            p.DecrementarQteMovimento();
            if (pecaCapiturada != null)
            {
                Tab.ColocarPeca(pecaCapiturada, destino);
                Capituradas.Remove(pecaCapiturada);
            }
            Tab.ColocarPeca(p, origem);
        }

        public void RealizaJogada(Posicao origem, Posicao destino)
        {
            Peca PecaCapturada = ExecultaMovimento(origem, destino);
            if (EstaEmXeque(JogadorAtual))
            {
                DesfazerMovimento(origem, destino, PecaCapturada);
                throw new TabuleiroException("Não pode se colocar em Xeque!!");
            }
            if (EstaEmXeque(Adversaria(JogadorAtual)))
            {
                Xeque = true;
            }
            else
            {
                Xeque = false;
            }
            if (TestXequeMate(Adversaria(JogadorAtual)))
            {
                Terminada = true;
            }
            else
            {

                Turno++;
                MudaJogador();
            }
        }



        public void ValidarPosicaoOrigem(Posicao pos)
        {
            if (Tab.Peca(pos) == null)
            {
                throw new TabuleiroException("Não existe peça nessa posição!");
            }
            if (JogadorAtual != Tab.Peca(pos).Cor)
            {
                throw new TabuleiroException("A peça não é sua!");
            }
            if (!Tab.Peca(pos).ExisteMoPossiveis())
            {
                throw new TabuleiroException("Não há movimentos possiveis para peça escolhida!");
            }

        }
        public void ValidarPosicaoDestino(Posicao origem, Posicao destino)
        {
            if (!Tab.Peca(origem).PodeMoverPara(destino))
            {
                throw new TabuleiroException("Posição de Destino Inválida!");
            }

        }
        private void MudaJogador()
        {
            if (JogadorAtual == Cor.branca)
            {
                JogadorAtual = Cor.preta;
            }
            else
            {
                JogadorAtual = Cor.branca;
            }
        }

        public HashSet<Peca> PecasCapituradas(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in Capituradas)
            {
                if (x.Cor == cor)
                {
                    aux.Add(x);
                }

            }
            return aux;
        }




        public HashSet<Peca> PecasEmJogo(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in Pecas)
            {
                if (x.Cor == cor)
                {
                    aux.Add(x);
                }

            }
            aux.ExceptWith(PecasCapituradas(cor));
            return aux;
        }

        private Cor Adversaria(Cor cor)
        {
            if (cor == Cor.branca)
            {
                return Cor.preta;
            }
            else
            {
                return Cor.branca;
            }
        }

        private Peca Rei(Cor cor)
        {
            foreach (Peca x in PecasEmJogo(cor))
            {
                if (x is Rei)
                {
                    return x;
                }
            }
            return null;
        }


        public bool EstaEmXeque(Cor cor)
        {
            Peca R = Rei(cor);
            if (R == null)
            {
                throw new TabuleiroException("Não tem rei da cor" + cor + " em jogo?!!");
            }
            foreach (Peca x in PecasEmJogo(Adversaria(cor)))
            {
                bool[,] mat = x.MovimentosPossiveis();
                if (mat[R.Posicao.Linha, R.Posicao.Coluna])
                {
                    return true;
                }
            }
            return false;
        }


        public bool TestXequeMate(Cor cor)
        {
            if (!EstaEmXeque(cor))
            {
                return false;
            }
            else { 
            foreach (Peca x in PecasEmJogo(cor))
                {
                bool[,] mat = x.MovimentosPossiveis();
                    for (int i = 0; i < Tab.linhas; i++)
                    {
                        for (int j = 0; j < Tab.colunas; j++)
                        {
                            if (mat[i, j])
                            {
                                Posicao origem = x.Posicao;
                                Posicao destino = new Posicao(i, j);
                                Peca PecaCapturada = ExecultaMovimento(origem, destino);
                                bool TesteXeque = EstaEmXeque(cor);
                                DesfazerMovimento(origem, destino, PecaCapturada);
                                if (!TesteXeque)
                                {
                                    return false;
                                }

                            }

                        }
                    }
                }
            }
            return true;
        }

        public void ColocarNovaPeca(char coluna, int linha, Peca peca)
        {
            Tab.ColocarPeca(peca, new PosicaoXadrez(coluna, linha).ToPosicao());
            Pecas.Add(peca);

        }
        private void ColocarPecas()
        {


           // ColocarNovaPeca('c', 1, new Torre(Tab, Cor.branca));
            ColocarNovaPeca('c', 2, new Torre(Tab, Cor.branca));
           // ColocarNovaPeca('d', 2, new Torre(Tab, Cor.branca));
           // ColocarNovaPeca('e', 2, new Torre(Tab, Cor.branca));
            ColocarNovaPeca('h', 7, new Torre(Tab, Cor.branca));
            ColocarNovaPeca('h', 1, new Rei(Tab, Cor.branca));


            //ColocarNovaPeca('c', 7, new Torre(Tab, Cor.preta));
            //ColocarNovaPeca('c', 8, new Torre(Tab, Cor.preta));
            //ColocarNovaPeca('d', 7, new Torre(Tab, Cor.preta));
            ColocarNovaPeca('b', 8, new Torre(Tab, Cor.preta));
          //  ColocarNovaPeca('e', 8, new Torre(Tab, Cor.preta));
            ColocarNovaPeca('a', 8, new Rei(Tab, Cor.preta));


        }
    }
}
