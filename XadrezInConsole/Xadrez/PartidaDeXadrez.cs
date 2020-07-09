﻿using System.Collections.Generic;
using Tabuleiro;

namespace Xadrez
{
    class PartidaDeXadrez
    {
        public Tabuleiroo Tab { get; private set; }
        public int Turno { get; private set; }
        public Cor JogadorAtual { get; private set; }
        public bool Terminada { get; private set; }
        private HashSet<Peca> Pecas;
        private HashSet<Peca> Capituradas;

        public PartidaDeXadrez()
        {
            Tab = new Tabuleiroo(8, 8);
            Turno = 1;
            JogadorAtual = Cor.branca;
            Terminada = false;
            Pecas = new HashSet<Peca>();
            Capituradas = new HashSet<Peca>();
            ColocarPecas();


        }
        public void ExecultaMovimento(Posicao origem, Posicao destino)
        {
            Peca p = Tab.RetirarPeca(origem);
            p.IncrementarQteMovimentos();
            Peca PecaCapturada = Tab.RetirarPeca(destino);
            Tab.ColocarPeca(p, destino);
            if(PecaCapturada != null)
            {
                Capituradas.Add(PecaCapturada);
            }
        }

        public void RealizaJogada(Posicao origem, Posicao destino)
        {
            ExecultaMovimento(origem, destino);
            Turno++;
            MudaJogador();
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
            foreach(Peca x in Capituradas)
            {
                if(x.Cor == cor)
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

        public void ColocarNovaPeca(char coluna, int linha, Peca peca)
        {
            Tab.ColocarPeca(peca, new PosicaoXadrez(coluna, linha).ToPosicao());
            Pecas.Add(peca);

        }
        private void ColocarPecas()
        {
 

            ColocarNovaPeca('c', 1, new Torre(Tab, Cor.branca));
            ColocarNovaPeca('c', 2, new Torre(Tab, Cor.branca));
            ColocarNovaPeca('d', 2, new Torre(Tab, Cor.branca));
            ColocarNovaPeca('e', 2, new Torre(Tab, Cor.branca));
            ColocarNovaPeca('e', 1, new Torre(Tab, Cor.branca));
            ColocarNovaPeca('d', 1, new Rei(Tab, Cor.branca));


            ColocarNovaPeca('c', 7, new Torre(Tab, Cor.preta));
            ColocarNovaPeca('c', 8, new Torre(Tab, Cor.preta));
            ColocarNovaPeca('d', 7, new Torre(Tab, Cor.preta));
            ColocarNovaPeca('e', 7, new Torre(Tab, Cor.preta));
            ColocarNovaPeca('e', 8, new Torre(Tab, Cor.preta));
            ColocarNovaPeca('d', 8, new Rei(Tab, Cor.preta));


        }
    }
}
