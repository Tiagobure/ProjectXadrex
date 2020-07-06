
namespace Tabuleiro
{
    class Tabuleiroo
    {
        public int linhas { get; set; }
        public int colunas { get; set; }
        private Peca[,] Pecas;

        public Tabuleiroo(int linhas, int colunas)
        {
            this.linhas = linhas;
            this.colunas = colunas;
            Pecas = new Peca[linhas, colunas];
        }


        public Peca Peca(int linha, int coluna)
        {
            return Pecas[linha, coluna];
        }
      

        public Peca Peca(Posicao pos)
        {
            return Pecas[pos.Linha, pos.Coluna];
        }

        public bool Existepeca(Posicao pos)
        {
            ValidarPosicao(pos);
            return Peca(pos) != null;

        }
      

        public void ColocarPeca(Peca p, Posicao pos)
        {
            if (Existepeca(pos))
            {
                throw new TabuleiroException("Já existe uma peça nessa posição");
            }
            Pecas[pos.Linha, pos.Coluna] = p;
            p.posicao = pos;

        }
      

        public bool PosicaoValida(Posicao pos)
        {
            if (pos.Linha < 0 || pos.Linha >= linhas || pos.Coluna < 0 || pos.Coluna >=colunas)
            {
                return false;
            }
            return true;
        }
        public void ValidarPosicao(Posicao pos)
        {
            if (!PosicaoValida(pos))
            {
                throw new TabuleiroException("Posição Invalida!");
            }
        }
    }
}
