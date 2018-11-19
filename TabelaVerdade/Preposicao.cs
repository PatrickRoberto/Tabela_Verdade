using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TabelaVerdade
{

    public class Preposicao
    {
        List<Parametro> preposicao;
        //string expresao;

        public Preposicao(string expresao)
        {
            if (Validar(expresao))
            {
                preposicao = QuebrarExpresao(expresao);
            }
            else
            {
                //lancar erro
                throw new NotImplementedException();
            }

        }

        

    #region Levar para outra classe
        private List<Parametro> QuebrarExpresao(string expresao)
        {
            List<Parametro> saida = new List<Parametro>();

            int inicio = 0;

            string texto = expresao.Replace(" ", "");
            
            for (int i = 0; i < texto.Length; i++)
            {
                switch (texto[i])
                {
                    case '^':
                    case 'v':
                    case '~':
                    case ')':
                        saida.Add(new ParEntr(texto.Substring(inicio, i - inicio)));
                        saida.Add(new ParOperacao(Ultilitarios.RetornaOperacao(texto[i])));
                        inicio = i + 1;
                        break;
                    case '(':
                        //saida.Add(texto[i] + ""); TRATAR PARA ADICIONAR UMA SUB PREPOSIÇÃO NESTE TRECHO
                        inicio = i + 1;
                        break;

                    default: break;

                }
            }
            
            throw new NotImplementedException();
        }

        

        public bool Validar(string e)
        {
            throw new NotImplementedException();
        }

        public int QtdOperecoes()
        {
            int x = 0;
            foreach (var ent in preposicao)
            {
                switch(ent.tipo)
                {
                    case TipParametro.operacao:
                        x++;
                        break;
                    case TipParametro.preposica:
                        x += ((ParPreposicao)ent).valor().QtdOperecoes();
                        break;
                    default: break;
                }
            }
            return x;
        }
    #endregion

    
    }

    class GerenciarPrep
    {
        List<Entrada> entradas;
        Preposicao prep;

        

        
    }
}
