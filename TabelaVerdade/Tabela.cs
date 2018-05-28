using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TabelaVerdade
{
    class Entrada
    {
        public string Id { get; }
        bool? valor;

        public void FixarValor(bool v)
        {
            this.valor = v;
        }

        public void reiniciarValor()
        {
            this.valor = null;
        }

    }


    class Tabela
    {
        Entrada[] entradas;
        bool[,] tab;
        int qtdLinha, qtdColuna;


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
