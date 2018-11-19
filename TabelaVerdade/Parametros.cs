using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TabelaVerdade
{
    /// <summary>
    /// Aqui será todas as classes publics
    /// </summary>
    public abstract class Parametro
    {
        
        public TipParametro tipo { get; }

        public Parametro(TipParametro t)
        {
            this.tipo = t;
        }

        public abstract string Imprimir();

        


    }

    public class ParEntr : Parametro
    {
        string Valor { get; }

        public ParEntr(string nValor) : base(TipParametro.valor)
        {
            this.Valor = nValor;
        }

        public override string Imprimir()
        {
            return Valor;
            throw new NotImplementedException();
        }
    }

    public class ParValor : Parametro
    {
        bool Valor { get; }

        public ParValor(bool nValor) : base(TipParametro.valor)
        {
            this.Valor = nValor;
        }

        public override string Imprimir()
        {
            return "";
            throw new NotImplementedException();
        }
    }

    public class ParOperacao : Parametro
    {
        TipOperacoes Valor { get; }

        public ParOperacao(TipOperacoes nValor) : base(TipParametro.operacao)
        {
            this.Valor = nValor;
        }

        public override string Imprimir()
        {
            return "";
            throw new NotImplementedException();
        }
    }

    public class ParPreposicao : Parametro
    {
        Preposicao Valor { get; }

        public ParPreposicao(Preposicao nValor) : base(TipParametro.preposica)
        {
            this.Valor = nValor;
        }

        public override string Imprimir()
        {
            return "";
            throw new NotImplementedException();
        }

        public Preposicao valor()
        {
            return Valor;
        }
    }

}
