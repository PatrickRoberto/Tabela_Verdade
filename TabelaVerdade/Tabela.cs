using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TabelaVerdade
{
    class Tabela
    {
        Entrada[] entradas;
        bool[,] tab;
        int qtdLinha, qtdColuna;

    #region Construtores
        public Tabela(int colunas)
        {
            this.qtdLinha = CalcularLinhas(colunas);
            this.qtdColuna = colunas;
            this.tab = new bool[qtdLinha, qtdColuna];

            this.MontarTabela(tab);
        }

        public Tabela(Preposicao P)
        {
            throw new NotImplementedException();
        }

    #endregion


        private void MontarTabela(bool[,] tab)
        {
            throw new NotImplementedException();
        }

        private int CalcularLinhas(int col)
        {
            return (int)Math.Pow(2, col);
        }
        
    }
}
