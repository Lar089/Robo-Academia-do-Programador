using RoboAtividade2.model;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoboAtividade2.controllers
{
    class Controller
    {
        private static int x_start;
        private static int y_start;
        private static String position_start;
        private static int x_total;
        private static int y_total;

        private static Face face;
        private static X x = new X();
        private static Y y = new Y();
        private static Robo robo = new Robo(face, x, y);

        #region Função de leitura dos dados
        //Essa função vai ler o tamanho do grid, a posição do x, y e a face e os comandos de movinmentação
        #endregion
        public static void Read(string grid, string position, string command)
        {
            int[] result_grid = Controller.ReadGrid(grid);
            x_total = result_grid[0];
            y_total = result_grid[1];

            #region Verificação a POSIÇÃO
            //verifica se os falores de x e y são positivos
            #endregion
            if (x_total >= 0 && y_total >= 0)
            {
                int[] result_position = controllers.Controller.ReadPosition(position);
                x_start = result_position[0];
                y_start = result_position[1];

                int size = command.Length;
                command = command.ToUpper();

                robo.Face = ConvertFace(position_start);
                robo.SGX = x_start;
                robo.SGY = y_start;

                #region Verifica a opção de movimentação
                //Varefica qual opção de movimentação foi selecionada pelo usuário Esquerda, direita ou movimentar
                #endregion
                foreach (char com in command)
                {
                    switch (com)
                    {
                        case 'E':
                            Controller.RoboFace(com, robo.Face);
                            break;
                        case 'D':
                            Controller.RoboFace(com, robo.Face);
                            break;
                        case 'M':
                            Controller.Move(robo.Face);
                            break;
                        default:
                            Console.WriteLine("ERRO: Digite um movimento");
                            break;
                    }
                }

                #region Mostra o resultado final
                //Apresenta na tela as informações finais do X, Y e a Face
                #endregion
                Console.WriteLine("*****Resultado*****");
                Console.WriteLine($"X: {robo.SGX}");
                Console.WriteLine($"Y: {robo.SGY}");
                Console.WriteLine($"Face: {robo.Face}");

            }
        }

        #region Função de leitura do grid
        //Essa função vai ler o tamanho do grid
        #endregion
        public static int[] ReadGrid(string grid)
        {
            int[] values_grid = new int[2];
            int i = 0;
            string[] grids = grid.Split(' ');
            foreach (var g in grids)
            {
                values_grid[i] = Convert.ToInt32(g);
                i++;
            }

            return values_grid;
        }

        #region Função de leitura da posição inicial
        //Essa função vai ler a posição do x, y e a face
        #endregion
        public static int[] ReadPosition(string position)
        {

            int[] values_position = new int[2];
            int j = 0;
            string[] positions = position.Split(' ');
            foreach (var p in positions)
            {
                if (j < 2)
                {
                    values_position[j] = Convert.ToInt32(p);
                    j++;
                }
                else
                {
                    position_start = p.ToUpper();
                    return values_position;
                }
            }
            return values_position;

        }

        #region Função que verifica qual posição da face
        //Essa função vai verificar qual a posição da face(N, S, L, O) a partir da movimentação escolhida pelo usuário(E ou D)
        #endregion
        public static void RoboFace(char str, Face face_str)
        {
            if (face_str.Equals(Face.N))
            {
                if (str.Equals('E'))
                {
                    robo.Face = Face.O;
                }
                else if (str.Equals('D'))
                {
                    robo.Face = Face.L;
                }
            }
            else if (face_str.Equals(Face.S))
            {
                if (str.Equals('E'))
                {
                    robo.Face = Face.L;
                }
                else if (str.Equals('D'))
                {
                    robo.Face = Face.O;
                }
            }
            else if (face_str.Equals(Face.L))
            {
                if (str.Equals('E'))
                {
                    robo.Face = Face.N;
                }
                else if (str.Equals('D'))
                {
                    robo.Face = Face.S;
                }
            }
            else if (face_str.Equals(Face.O))
            {
                if (str.Equals('E'))
                {
                    robo.Face = Face.S;
                }
                else if (str.Equals('D'))
                {
                    robo.Face = Face.N;
                }
            }
            else
            {
                Console.WriteLine("ERRO: Face não encontrada");
            }
        }

        #region Função responsável por Convertar variavel String em char da Face
        //Essa função vai converter a string face inicial em um char para ser comparada de forma correta
        #endregion
        public static Face ConvertFace(string str)
        {
            if (str.Equals("N"))
            {
                return Face.N;
            } else if (str.Equals("S"))
            {
                return Face.S;
            }
            else if (str.Equals("L"))
            {
                return Face.L;
            }
            else if (str.Equals("O"))
            {
                return Face.O;
            }
            return Face.ERRO;
        }

        #region Função que movimenta o robo
        //Essa função vai movimentar o robo através do eixo y e o eixo x a partir da face já determianda e na posição correta
        #endregion
        public static void Move(Face face_str)
        {
            if (face_str.Equals(Face.N))
            {
                robo.SGY += 1;
            }
            else if (face_str.Equals(Face.S))
            {
                robo.SGY -= 1;
            }
            else if (face_str.Equals(Face.L))
            {
                robo.SGX += 1;
            }
            else if (face_str.Equals(Face.O))
            {
                robo.SGX -= 1;
            }
            
        }

    }
}
