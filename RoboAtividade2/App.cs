using System;

namespace RoboAtividade2
{
    class App
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Digite Grid:");
            String grid = Console.ReadLine();

            String op = null;

            #region Verificação do GRID
            //verifica se existe algum valor no grid
            #endregion
            if (grid != null)
            {
                #region Laço de repetição
                //repete até o usuário digitar s
                #endregion
                do
                {
                    Console.WriteLine("Digite a Posição:");
                    String position = Console.ReadLine();

                    Console.WriteLine("Digite os comandos:");
                    String command = Console.ReadLine();

                    #region Chama uma função de leitura
                    //Chama a função responsável por processar os dados
                    #endregion
                    controllers.Controller.Read(grid, position, command);

                    Console.WriteLine("Digite 1 para fazer outra operação e S para sair:");
                    op = Console.ReadLine();
                } while (op.ToUpper() != "S");
            }
            else
            {
                Console.WriteLine("ERRO: Insira um valor correto");
            }

        }

        

    }
}
