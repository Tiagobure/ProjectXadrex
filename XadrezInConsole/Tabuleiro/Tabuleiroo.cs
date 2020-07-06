
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

        public void ColocarPeca(Peca p, Posicao pos)
        {
            Pecas[pos.Linha, pos.Coluna] = p;
            p.posicao = pos;

        }
    }
}
