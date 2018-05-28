using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TabelaVerdade
{
    class Program
    {
        public static void Main(string[] args)
        {
            bool x = true;
            if (x)
            {
                

            }
            else
            {
                bool[,] tabela = CriarTabela();

                byte op = 0;

                do
                {
                    #region Cabeçalho PUC
                    Console.WriteLine(" PONTIFICIA UNIVERSIDADE CATOLICA DE MINAS GERAIS");
                    Console.WriteLine(" TRABALHO INTERDISCIPLINAR");
                    Console.WriteLine(" 1o PERIODO - SISTEMAS DE INFORMACAO");
                    Console.Write("\n");
                    #endregion

                    #region Proposicao do trabalho
                    Console.Write("\n As tabelas verdade que sao mostradas no trabalho sao resultados da seguinte proposicao:\n");
                    Console.Write("\n IF (P1 AND P3)");
                    Console.Write("\n THEN (IF P4");
                    Console.Write("\n       THEN T1");
                    Console.Write("\n       ELSE T2)");
                    Console.Write("\n ELSE (IF (NOT P3)");
                    Console.Write("\n       THEN (P1 AND T3)");
                    Console.Write("\n       ELSE (P2 AND (NOT P5) AND T4))");
                    Console.WriteLine("\n");
                    #endregion

                    #region Menu de Operaçõs
                    Console.Write("\n Atencao para a visualizacao correta da tabela em tela!!!");
                    Console.WriteLine("\n Aumente a largura do buffer do console para 240 e a altura para 1100.");

                    Console.WriteLine("\n Escolha a opcao desejada:\n");
                    Console.WriteLine(" 1 - Criar tabela verdade em arquivo. (9 variaveis e 8 conectivos)");
                    Console.WriteLine(" 2 - Criar tabela verdade em tela. (9 variaveis e 8 conectivos)");
                    Console.WriteLine(" 3 - Criar tabela verdade e mostrar apenas combinacoes que resulte a proposicao em verdadeira.");
                    Console.WriteLine(" 4 - Escolher conectivo para teste individual.");
                    Console.WriteLine(" 0 - Sair\n");
                    Console.Write(" Sua escolha => ");
                    try
                    {
                        op = Convert.ToByte(Console.ReadLine());
                    }
                    catch (OverflowException)
                    {
                        op = 5;
                    }

                    switch (op)
                    {
                        case 1:
                            EscreverArquivo(ref tabela);
                            Console.ReadKey();
                            break;
                        case 2:
                            EscreverTela(ref tabela);
                            Console.ReadKey();
                            break;
                        case 3:
                            EscreverVerdadeiras(ref tabela);
                            Console.ReadKey();
                            break;
                        case 4:
                            TesteIndividual();
                            break;
                        case 0:
                            Console.Write("\n Voce escolheu sair!");
                            Console.ReadKey();
                            break;
                        default:
                            Console.WriteLine("\n ERRO!!!");
                            Console.WriteLine(" Digito invalido!\n");
                            Console.ReadKey();
                            break;
                    }

                    Console.Clear();
                    #endregion

                } while (op != 0);
            }
        }

        #region METODOS DO MAIN
        //Escreve um arquivo com o conteudo da tabela verdade
        public static void EscreverArquivo(ref bool[,] tabela)
        {
            try
            {
                StreamWriter arq = new StreamWriter(@"C:\Users\Public\Documents\Arquivo.txt");

                //Design cabecalho da tabela
                CriarNumColun(ref arq, (ushort)(tabela.GetLength(1)));
                CriarTitulo(ref arq);
                //fim design cabecalho da tabela

                CriarLinha(ref arq);
                for (ushort row = 0; row < tabela.GetLength(0); row++)
                {

                    for (ushort col = 0; col < tabela.GetLength(1); col++)
                    {
                        if (tabela[row, col])
                        {
                            arq.Write("    " + tabela[row, col] + "     |");
                        }
                        else
                        {
                            arq.Write("    " + tabela[row, col] + "    |");
                        }
                    }
                    arq.Write("\n");
                    CriarLinha(ref arq);
                }

                //Design rodape da tabela
                CriarTitulo(ref arq);
                CriarNumColun(ref arq, (ushort)(tabela.GetLength(1)));
                //fim design rodape da tabela

                arq.Close();
                Console.WriteLine("\n Arquivo criado com sucesso!!!");
                Console.Write(" Endereco => C:\\Users\\Public\\Documents\\Arquivo.txt");
                Console.Write("\n Obs: Para visualizacao correta a quebra automatica de linhas do notepad deve estar desativada.");
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("\n ERRO!!!");
                Console.WriteLine(" Arquivo nao pode ser criado. O endereco de gravacao tem o acesso nao autorizado.");
                Console.Write(" Endereco => C:\\Users\\Public\\Documents\\Arquivo.txt");
                Console.Write("\n Obs: Altere as configuracoes de acesso da pasta.");
            }
        }

        //Escreve na tela o conteudo da tabela verdade
        public static void EscreverTela(ref bool[,] tabela)
        {
            Console.Write("\n Atencao para a visualizacao correta da tabela!!!");
            Console.Write("\n Antes de seguir deste ponto aumente a largura do buffer do console para 240 e a altura para 1100.");
            Console.Write("\n Aperte ENTER se ja tiver feito isso.");
            Console.ReadKey();
            Console.Clear();

            //Design cabecalho da tabela
            CriarNumColun((ushort)(tabela.GetLength(1)));
            CriarTitulo();
            //Fim design cabecalho da tabela

            CriarLinha();
            for (ushort row = 0; row < tabela.GetLength(0); row++)
            {
                Console.Write("|");
                for (ushort col = 0; col < tabela.GetLength(1); col++)
                {
                    if (tabela[row, col])
                    {
                        Console.Write("    " + tabela[row, col] + "     |");
                    }
                    else
                    {
                        Console.Write("    " + tabela[row, col] + "    |");
                    }
                }
                Console.Write("\n");
                CriarLinha();
            }


            //Design rodape da tabela
            CriarTitulo();
            CriarNumColun((ushort)(tabela.GetLength(1)));
            //Fim design rodape da tabela
        }

        //Escreve na tela as linhas da tabela verdade em que a proposicao final e verdadeira
        public static void EscreverVerdadeiras(ref bool[,] tabela)
        {
            Console.Write("\n Atencao para a visualizacao correta da tabela!!!");
            Console.Write("\n Antes de seguir deste ponto aumente a largura do buffer do console para 240 e a altura para 1100.");
            Console.Write("\n Aperte ENTER se ja tiver feito isso.");
            Console.ReadKey();
            Console.Clear();

            //Design cabecalho da tabela
            CriarNumColun((ushort)(tabela.GetLength(1)));
            CriarTitulo();
            //Fim design cabecalho da tabela

            CriarLinha();
            for (ushort row = 0; row < tabela.GetLength(0); row++)
            {
                if (tabela[row, (tabela.GetLength(1) - 1)] == true)
                {
                    Console.Write("|");
                    for (ushort col = 0; col < tabela.GetLength(1); col++)
                    {
                        if (tabela[row, col])
                        {
                            Console.Write("    " + tabela[row, col] + "     |");
                        }
                        else
                        {
                            Console.Write("    " + tabela[row, col] + "    |");
                        }
                    }
                    Console.Write("\n");
                    CriarLinha();
                }
            }

            //Design rodape da tabela
            CriarTitulo();
            CriarNumColun((ushort)(tabela.GetLength(1)));
            //Fim design rodape da tabela

        }

        //Teste individual
        public static void TesteIndividual()
        {
            byte op = 0;
            Console.Clear();
            Console.WriteLine(" PONTIFICIA UNIVERSIDADE CATOLICA DE MINAS GERAIS");
            Console.WriteLine(" TRABALHO INTERDISCIPLINAR");
            Console.WriteLine(" 1o PERIODO - SISTEMAS DE INFORMACAO");
            Console.WriteLine("\n");

            Console.WriteLine(" Escolha o conectivo a ser testado:\n");
            Console.WriteLine(" 1 - NOT.");
            Console.WriteLine(" 2 - AND.");
            Console.WriteLine(" 3 - OR.");
            Console.WriteLine(" 4 - IF...THEN.");
            Console.WriteLine(" 5 - IF...THEN...ELSE.");
            Console.WriteLine(" 6 - IFF.");
            Console.WriteLine(" 7 - ORR.");
            Console.WriteLine(" 0 - Sair do menu de conectivos\n");

            do
            {
                Console.Write(" Digite sua escolha => ");
                try
                {
                    op = Convert.ToByte(Console.ReadLine());
                }
                catch (OverflowException)
                {
                    op = 8;
                }

                bool t1, t2, t3;
                switch (op)
                {
                    case 1:
                        Console.Write("\n Teste NOT (1 variavel)");
                        Console.Write("\n Digite o valor da variavel do teste (1 = true | 0 ou !=1 = false) => ");
                        t1 = Convert.ToInt32(Console.ReadLine()) == 1 ? true : false;

                        Console.Write("\n NOT T1({0}) = {1}\n\n", t1, Expressoes.Not(t1));
                        break;
                    case 2:
                        Console.Write("\n Teste AND (2 variaveis)");
                        Console.Write("\n Digite o valor da variavel 1 do teste (1 = true | 0 ou !=1 = false) => ");
                        t1 = Convert.ToInt32(Console.ReadLine()) == 1 ? true : false;
                        Console.Write(" Digite o valor da variavel 2 do teste (1 = true | 0 ou !=1 = false) => ");
                        t2 = Convert.ToInt32(Console.ReadLine()) == 1 ? true : false;

                        Console.Write("\n T1({0}) AND T2({1}) = {2}\n\n", t1, t2, Expressoes.And(t1, t2));
                        break;
                    case 3:
                        Console.Write("\n Teste OR (2 variaveis)");
                        Console.Write("\n Digite o valor da variavel 1 do teste (1 = true | 0 ou !=1 = false) => ");
                        t1 = Convert.ToInt32(Console.ReadLine()) == 1 ? true : false;
                        Console.Write(" Digite o valor da variavel 2 do teste (1 = true | 0 ou !=1 = false) => ");
                        t2 = Convert.ToInt32(Console.ReadLine()) == 1 ? true : false;

                        Console.Write("\n T1({0}) OR T2({1}) = {2}\n\n", t1, t2, Expressoes.Or(t1, t2));
                        break;
                    case 4:
                        Console.Write("\n Teste IF...THEN (2 variaveis)");
                        Console.Write("\n Digite o valor da variavel 1 do teste (1 = true | 0 ou !=1 = false) => ");
                        t1 = Convert.ToInt32(Console.ReadLine()) == 1 ? true : false;
                        Console.Write(" Digite o valor da variavel 2 do teste (1 = true | 0 ou !=1 = false) => ");
                        t2 = Convert.ToInt32(Console.ReadLine()) == 1 ? true : false;

                        Console.Write("\n IF T1({0}) THEN T2({1}) = {2}\n\n", t1, t2, Expressoes.IfThen(t1, t2));
                        break;
                    case 5:
                        Console.Write("\n Teste IF...THEN...ELSE (3 variaveis)");
                        Console.Write("\n Digite o valor da variavel 1 do teste (1 = true | 0 ou !=1 = false) => ");
                        t1 = Convert.ToInt32(Console.ReadLine()) == 1 ? true : false;
                        Console.Write(" Digite o valor da variavel 2 do teste (1 = true | 0 ou !=1 = false) => ");
                        t2 = Convert.ToInt32(Console.ReadLine()) == 1 ? true : false;
                        Console.Write(" Digite o valor da variavel 3 do teste (1 = true | 0 ou !=1 = false) => ");
                        t3 = Convert.ToInt32(Console.ReadLine()) == 1 ? true : false;

                        Console.Write("\n IF T1({0}) THEN T2({1}) ELSE T3({2}) = {3}\n\n", t1, t2, t3, Expressoes.IfThenElse(t1, t2, t3));
                        break;
                    case 6:
                        Console.Write("\n Teste IFF (2 variaveis)");
                        Console.Write("\n Digite o valor da variavel 1 do teste (1 = true | 0 ou !=1 = false) => ");
                        t1 = Convert.ToInt32(Console.ReadLine()) == 1 ? true : false;
                        Console.Write(" Digite o valor da variavel 2 do teste (1 = true | 0 ou !=1 = false) => ");
                        t2 = Convert.ToInt32(Console.ReadLine()) == 1 ? true : false;

                        Console.Write("\n T1({0}) IFF T2({1}) = {2}\n\n", t1, t2, Expressoes.Iff(t1, t2));
                        break;
                    case 7:
                        Console.Write("\n Teste ORR (2 variaveis)");
                        Console.Write("\n Digite o valor da variavel 1 do teste (1 = true | 0 ou !=1 = false) => ");
                        t1 = Convert.ToInt32(Console.ReadLine()) == 1 ? true : false;
                        Console.Write(" Digite o valor da variavel 2 do teste (1 = true | 0 ou !=1 = false) => ");
                        t2 = Convert.ToInt32(Console.ReadLine()) == 1 ? true : false;

                        Console.Write("\n T1({0}) ORR T2({1}) = {2}\n\n", t1, t2, Expressoes.Orr(t1, t2));
                        break;
                    default:
                        Console.WriteLine(" ERRO!!!");
                        Console.WriteLine(" Digito invalido!\n");
                        break;
                }
            } while (op != 0);
        }

        //Cria e preencher a tabela verdade
        public static bool[,] CriarTabela()
        {
            // Numero de variaveis e de conectivos
            byte nVar = 9, nElem = 8;

            bool[,] tabela = new bool[(int)Math.Pow(2, nVar), nVar + nElem];  //Cria a tabela [linha , coluna]

            //Apenas para auxiliar o preenchimento das variaveis
            ushort aux = Convert.ToUInt16(Math.Pow(2, nVar - 1));  //Define numero de elementos true ou false
            ushort contRepet = 0, contCol = 0;

            //'col' = colunas
            for (ushort col = 0; col < tabela.GetLength(1); col++)
            {

                if (col < nVar)//Verifica se estah em uma coluna de variaveis. Se sim as preenche, se nao define os conectivos a partir das variaveis ja preenchidas
                {
                    //'row' = linhas
                    for (ushort row = 0; row < tabela.GetLength(0); row++)
                    {
                        contRepet++;

                        if (contRepet > (aux * 2))
                        {
                            contRepet = 1;
                        }

                        if (contRepet <= aux)
                        {
                            tabela[row, col] = true;
                        }
                        else
                        {
                            tabela[row, col] = false;
                        }
                    }
                    // Define ate que ponto vai ser True para depois passar para False
                    aux /= 2;
                }
                else//Define valor dos conectivos
                {
                    contCol++;//Para saber qual conectivo executar em cada coluna
                    //'row' = linhas
                    for (ushort row = 0; row < tabela.GetLength(0); row++)
                    {
                        switch (contCol)//Escolhe o conectivo pela coluna de conectivos
                        {
                            case 1:
                                tabela[row, col] = Expressoes.Not(tabela[row, 3 - 1]);
                                break;
                            case 2:
                                tabela[row, col] = Expressoes.Not(tabela[row, 5 - 1]);
                                break;
                            case 3:
                                tabela[row, col] = Expressoes.And(tabela[row, 2 - 1], tabela[row, 3 - 1]);
                                break;
                            case 4:
                                tabela[row, col] = Expressoes.And(tabela[row, 1 - 1], tabela[row, 9 - 1]);
                                break;
                            case 5:
                                tabela[row, col] = Expressoes.And(tabela[row, 2 - 1], Expressoes.And(tabela[row, (nVar + 2) - 1], tabela[row, 9 - 1]));
                                break;
                            case 6:
                                tabela[row, col] = Expressoes.IfThenElse(tabela[row, 4 - 1], tabela[row, 6 - 1], tabela[row, 7 - 1]);
                                break;
                            case 7:
                                tabela[row, col] = Expressoes.IfThenElse(tabela[row, (nVar + 1) - 1], tabela[row, (nVar + 4) - 1], tabela[row, (nVar + 5) - 1]);
                                break;
                            case 8:
                                tabela[row, col] = Expressoes.IfThenElse(tabela[row, (nVar + 3) - 1], tabela[row, (nVar + 6) - 1], tabela[row, (nVar + 7) - 1]);
                                break;
                        }
                    }
                }
            }
            return tabela;
        }

        #endregion

        #region METODOS PARA DESIGN DA TABELA

        //Cria titulo da tabela
        public static void CriarTitulo(ref StreamWriter arq)
        {
            CriarLinha(ref arq);
            arq.Write("|");
            //Variaveis
            arq.Write("     P1      |");
            arq.Write("     P2      |");
            arq.Write("     P3      |");
            arq.Write("     P4      |");
            arq.Write("     P5      |");
            arq.Write("     T1      |");
            arq.Write("     T2      |");
            arq.Write("     T3      |");
            arq.Write("     T4      |");
            //Conectivos
            arq.Write("     ~P3     |");//11 espacos de largura
            arq.Write("     ~P5     |");
            arq.Write("   P1 & P2   |");
            arq.Write("   P1 & T3   |");
            arq.Write(" P2& C11& T4 |");
            arq.Write(" P4? P6 : P7 |");
            arq.Write(" C10?C13:C14 |");
            arq.Write(" C12?C15:C16 |");
            arq.Write("\n");
            CriarLinha(ref arq);
        }

        //Criar linha tabela
        public static void CriarLinha(ref StreamWriter arq)
        {
            arq.Write("-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
            arq.Write("\n");
        }

        //Criar linha tabela
        public static void CriarNumColun(ref StreamWriter arq, ushort colunas)
        {
            CriarLinha(ref arq);
            arq.Write("|");
            for (int col = 0; col < colunas; col++)
            {
                if ((col + 1) < 10)
                {
                    arq.Write("     C{0}      |", col + 1);
                }
                else
                {
                    arq.Write("     C{0}     |", col + 1);
                }
            }
            arq.Write("\n");
            CriarLinha(ref arq);
        }

        //Cria titulo da tabela
        public static void CriarTitulo()
        {
            CriarLinha();
            //Variaveis
            Console.Write("|");
            Console.Write("     P1      |");
            Console.Write("     P2      |");
            Console.Write("     P3      |");
            Console.Write("     P4      |");
            Console.Write("     P5      |");
            Console.Write("     T1      |");
            Console.Write("     T2      |");
            Console.Write("     T3      |");
            Console.Write("     T4      |");
            //Conectivos
            Console.Write("     ~P3     |");//11 espacos de largura
            Console.Write("     ~P5     |");
            Console.Write("   P1 & P2   |");
            Console.Write("   P1 & T3   |");
            Console.Write(" P2& C11& T4 |");
            Console.Write(" P4? P6 : P7 |");
            Console.Write(" C10?C13:C14 |");
            Console.Write(" C12?C15:C16 |");
            Console.Write("\n");
            CriarLinha();
        }

        //Criar linha tabela
        public static void CriarLinha()
        {
            Console.Write("-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
            Console.Write("\n");
        }

        //Criar linha tabela
        public static void CriarNumColun(ushort colunas)
        {
            CriarLinha();
            Console.Write("|");
            for (int col = 0; col < colunas; col++)
            {
                if ((col + 1) < 10)
                {
                    Console.Write("     C{0}      |", col + 1);
                }
                else
                {
                    Console.Write("     C{0}     |", col + 1);
                }
            }
            Console.Write("\n");
            CriarLinha();
        }

        #endregion



    }

}
