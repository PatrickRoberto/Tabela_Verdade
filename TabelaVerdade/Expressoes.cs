using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TabelaVerdade
{
    public class Operacoes
    {
        public bool Calculo(bool P1, bool P2, TipOperacoes op)
        {

            switch (op)
            {
                case TipOperacoes.AND:
                    return Expressoes.And(P1, P2);
                case TipOperacoes.OR:
                    return Expressoes.Or(P1, P2);
                case TipOperacoes.IF:
                    return Expressoes.Iff(P1, P2);
                case TipOperacoes.IFTHEN:
                    return Expressoes.IfThen(P1, P2);
                //case TipOperacoes.NAND:
                //    return Expressoes.N(P1, P2);
                //case TipOperacoes.AND:
                //    return Expressoes.Na(P1, P2);
                //case TipOperacoes.AND:
                //    return Expressoes.And(P1, P2);
                //case TipOperacoes.AND:
                //    return Expressoes.And(P1, P2);
                default:
                    throw new NotImplementedException();

            }

        }


    }

    static class Expressoes
    {

        #region METODOS DOS CONECTIVOS

        //Conetivo NOT
        public static bool Not(bool A)
        {
            return (!A);
        }

        //Conectivo AND 
        public static bool And(bool A, bool B)
        {
            return (A && B);
        }

        //Conectivo OR 
        public static bool Or(bool A, bool B)
        {
            return (A || B);
        }

        //Conectivo IF...THEN 
        public static bool IfThen(bool A, bool B)
        {
            return (A ? B : !A);
        }

        //Conectivo IF...THEN...ELSE
        public static bool IfThenElse(bool A, bool B, bool C)
        {
            return (A ? B : C);
        }

        //Conectivo IFF (se somente se) IF AND ONLY IF
        public static bool Iff(bool A, bool B)
        {
            return (A == B);
        }

        //Conectivo ORR (ou somente ou) - 7 Or And Onlu Or
        public static bool Orr(bool A, bool B)
        {
            return (A != B);
        }
        #endregion

        #region Retorno Nomes
        public static string ValorPortugues(this bool A)
        {
            return A ? "Verdadeiro" : "Falso";
        }

        public static string ValorSimplificadoPortugues(this bool A)
        {
            return A ? "V" : "F";
        }

        public static string ValorSimplificadoIngles(this bool A)
        {
            return A ? "T" : "F";
        }
        #endregion


        //public char[] CaracteresOperacoes()
        //{
        //    return new char[] { }
        //} 

    }
}
