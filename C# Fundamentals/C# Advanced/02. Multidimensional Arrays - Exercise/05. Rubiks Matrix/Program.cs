using System;
using System.Linq;

namespace _05._Rubiks_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSize = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int commandsCount = int.Parse(Console.ReadLine());
            int[][] matrix = new int[matrixSize[0]][];

            FillMatrix(matrixSize, matrix);

            for (int count = 0; count < commandsCount; count++)
            {
                string[] commands = Console.ReadLine().Split();

                int row = int.Parse(commands[0]);
                int col = int.Parse(commands[0]);
                string direction = commands[1];
                int moves = int.Parse(commands[2]);

                switch (direction)
                {
                    case "down":
                        MoveDown(matrix, row, moves);
                        break;
                    case "up":
                        MoveUp(matrix, row, moves);
                        break;
                    case "right":
                        MoveRight(matrix, col, moves);
                        break;
                    case "left":
                        MoveLeft(matrix, col, moves);
                        break;
                }
            }

            Rearrange(matrix);
        }

        private static void Rearrange(int[][] matrix)
        {
            int counter = 0;
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (matrix[row][col] == ++counter)
                    {
                        Console.WriteLine("No swap required");
                    }
                    else
                    {
                        for (int currentRow = 0; currentRow < matrix.Length; currentRow++)
                        {
                            for (int currentCol = 0; currentCol < matrix[currentRow].Length; currentCol++)
                            {
                                if (matrix[currentRow][currentCol] == counter)
                                {
                                    Console.WriteLine($"Swap {(row, col)} with {(currentRow, currentCol)}");

                                    int holder = matrix[row][col];
                                    matrix[row][col] = matrix[currentRow][currentCol];
                                    matrix[currentRow][currentCol] = holder;
                                }
                            }
                        }
                    }
                }
            }
        }

        private static void MoveLeft(int[][] matrix, int col, int moves)
        {
            for (int move = 0; move < moves % matrix[col].Length; move++)
            {
                int holdCell = matrix[col][0];

                for (int i = 0; i < matrix[col].Length - 1; i++)
                {
                    matrix[col][i] = matrix[col][i + 1];
                }
                matrix[col][matrix[col].Length - 1] = holdCell;
            }
        }

        private static void MoveRight(int[][] matrix, int col, int moves)
        {
            for (int move = 0; move < moves % matrix[col].Length; move++)
            {
                int holdCell = matrix[col][matrix[col].Length - 1];

                for (int i = matrix[col].Length - 1; i > 0; i--)
                {
                    matrix[col][i] = matrix[col][i - 1];
                }
                matrix[col][0] = holdCell;
            }
        }

        private static void MoveUp(int[][] matrix, int row, int moves)
        {
            for (int move = 0; move < moves % matrix.Length; move++)
            {
                int holdCell = matrix[0][row];

                for (int i = 0; i < matrix.Length - 1; i++)
                {
                    matrix[i][row] = matrix[i + 1][row];
                }
                matrix[matrix.Length - 1][row] = holdCell;
            }
        }

        private static void MoveDown(int[][] matrix, int row, int moves)
        {
            for (int move = 0; move < moves % matrix.Length; move++)
            {
                int holdCell = matrix[matrix.Length - 1][row];

                for (int i = matrix.Length - 1; i > 0; i--)
                {
                    matrix[i][row] = matrix[i - 1][row];
                }
                matrix[0][row] = holdCell;
            }
        }

        private static void FillMatrix(int[] matrixSize, int[][] matrix)
        {
            int count = 0;

            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[row] = new int[matrixSize[1]];

                for (int col = 0; col < matrixSize[1]; col++)
                {
                    matrix[row][col] = ++count;
                }
            }
        }
    }
}
