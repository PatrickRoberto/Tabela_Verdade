using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TabelaVerdade
{
    class GerenciarTabVerdade
    {
        Tabela tab;
        Entrada[] entr;
        Preposicao prep;

        #region Contrutores
        //Recebe uma preposição e a partir dela faz as validações necessarias
        public GerenciarTabVerdade(Preposicao prep)
        {
            /*
            tab = new Tabela(prep);
            entr = prep.Entradas();
            */
            throw new NotImplementedException();
        }

        //Recebe uma lista de entradas para validar possiveis valores para ela
        public GerenciarTabVerdade(Entrada[] entradas)
        {
            /*
            entr = entradas;
            tab = new Tabela(entradas); //criar um construtor que considere uma lista de entradas
            */
            throw new NotImplementedException();
        }

        //Ja recebe uma tabela e pode fazer execuções emcima desta tabela
        public GerenciarTabVerdade(bool[] tabelaDeValores)
        {
            throw new NotImplementedException();
        }

        //Esse gera as entradas para gerar uma tabela verdade
        public GerenciarTabVerdade(int QtdEntradas)
        {
            throw new NotImplementedException();
        }
#endregion

        

    }
}
