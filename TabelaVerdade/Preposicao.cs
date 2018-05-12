using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TabelaVerdade
{

    public class Preposicao
    {
        List<Parametro> Entradas;
        string expresao;

        public Preposicao(string expresao)
        {
            if (validar(expresao))
            {
                Entradas = quebrarExpresao(expresao);
            }
            else
            {
                //lancar erro
                throw new NotImplementedException();
            }

        }


        private List<Parametro> quebrarExpresao(string expresao)
        {
            //Expresão de teste
            List<Parametro> ent = new List<Parametro>();

            foreach (var item in expresao)
            {

            }

            throw new NotImplementedException();
        }

        public bool validar(string e)
        {
            throw new NotImplementedException();
        }

        public int QtdOperecoes()
        {
            int x = 0;
            foreach (var ent in Entradas)
            {
                switch(ent.tipo)
                {
                    case TipParametro.operacao:
                        x++;
                        break;
                    case TipParametro.preposica:
                        x += ((ParPreposicao)ent).Valor().QtdOperecoes();
                        break;
                    default: break;
                }
            }
            return x;
        }

    }
}
