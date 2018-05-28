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

    public enum TipOperacoes
    {
        //Comuns
        NOT = 1,
        AND = 2,
        OR = 3,
        IF = 4,
        IFTHEN = 5,
        //Diferenciados
        NAND = 6,
        NOR = 7,
        XOR = 8,
        XNOR = 9

    }

}
