using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TabelaVerdade
{
    public enum TipParametro
    {
        valor = 1,
        operacao = 2,
        preposica = 3
    }

    

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

        public abstract void Imprimir();

        


    }

    public class ParValor : Parametro
    {
        bool valor { get; }

        public ParValor(bool nvalor) : base(TipParametro.valor)
        {
            this.valor = nvalor;
        }

        public override void Imprimir()
        {
            throw new NotImplementedException();
        }
    }

    public class ParOperacao : Parametro
    {
        TipOperacoes valor { get; }

        public ParOperacao(TipOperacoes nvalor) : base(TipParametro.operacao)
        {
            this.valor = nvalor;
        }

        public override void Imprimir()
        {
            throw new NotImplementedException();
        }
    }

    public class ParPreposicao : Parametro
    {
        Preposicao valor { get; }

        public ParPreposicao(Preposicao nvalor) : base(TipParametro.preposica)
        {
            this.valor = nvalor;
        }

        public override void Imprimir()
        {
            throw new NotImplementedException();
        }

        public Preposicao Valor()
        {
            return valor;
        }
    }

}
