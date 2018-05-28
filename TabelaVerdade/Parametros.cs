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
        string valor { get; }

        public ParEntr(string nValor) : base(TipParametro.valor)
        {
            this.valor = nValor;
        }

        public override string Imprimir()
        {
            return valor;
            throw new NotImplementedException();
        }
    }

    public class ParValor : Parametro
    {
        bool valor { get; }

        public ParValor(bool nValor) : base(TipParametro.valor)
        {
            this.valor = nValor;
        }

        public override string Imprimir()
        {
            return "";
            throw new NotImplementedException();
        }
    }

    public class ParOperacao : Parametro
    {
        TipOperacoes valor { get; }

        public ParOperacao(TipOperacoes nValor) : base(TipParametro.operacao)
        {
            this.valor = nValor;
        }

        public override string Imprimir()
        {
            return "";
            throw new NotImplementedException();
        }
    }

    public class ParPreposicao : Parametro
    {
        Preposicao valor { get; }

        public ParPreposicao(Preposicao nValor) : base(TipParametro.preposica)
        {
            this.valor = nValor;
        }

        public override string Imprimir()
        {
            return "";
            throw new NotImplementedException();
        }

        public Preposicao Valor()
        {
            return valor;
        }
    }

}
