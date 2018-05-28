using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TabelaVerdade
{
    static class Ultilitarios
    {
        public static TipOperacoes RetornaOperacao(char entrada)
        {
            switch (entrada)
            {
                case '~':
                    return TipOperacoes.NOT;
                case '^':
                    return TipOperacoes.AND;
                case 'v':
                    return TipOperacoes.OR;
                //case '~':
                //    return TipOperacoes.NOT;
                //case '~':
                //    return TipOperacoes.NOT;
                default: throw new Exception(); //Criar exception de não identificado
            }
        }

        public static TipOperacoes RetornaOperacao(int entrada)
        {
            switch (entrada)
            {
                case 1:
                    return TipOperacoes.NOT;
                case 2:
                    return TipOperacoes.AND;
                case 3:
                    return TipOperacoes.OR;
                case 4:
                    return TipOperacoes.IF;
                case 5:
                    return TipOperacoes.IFTHEN;
                case 6:
                    return TipOperacoes.NAND;
                case 7:
                    return TipOperacoes.NOR;
                case 8:
                    return TipOperacoes.XOR;
                case 9:
                    return TipOperacoes.XNOR;
                default:
                    throw new Exception(); //Criar exception de não identificado
            }
        }

        public static TipOperacoes RetornaOperacao(string entrada)
        {
            switch (entrada)
            {
                case "NOT":
                    return TipOperacoes.NOT;
                case "AND":
                    return TipOperacoes.AND;
                case "OR":
                    return TipOperacoes.OR;
                case "IF":
                    return TipOperacoes.IF;
                case "IFTHEN":
                    return TipOperacoes.IFTHEN;
                case "NAND":
                    return TipOperacoes.NAND;
                case "NOR":
                    return TipOperacoes.NOR;
                case "XOR":
                    return TipOperacoes.XOR;
                case "XNOR":
                    return TipOperacoes.XNOR;
                default:
                    throw new Exception(); //Criar exception de não identificado
            }
        }

    }
}
