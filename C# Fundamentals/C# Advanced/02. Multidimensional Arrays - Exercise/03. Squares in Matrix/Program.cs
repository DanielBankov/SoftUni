using System;
using System.Linq;

namespace _03._Squares_in_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSize = Console.ReadLine().Split().Select(int.Parse).ToArray();
            char[][] matrix = new char[matrixSize[0]][];

            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[row] = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();
            }

            int foundEquals = 0;

            for (int row = 0; row < matrix.Length - 1; row++)
            {
                for (int col = 0; col < matrix[row].Length - 1; col++)
                {
                    if (matrix[row][col] == matrix[row][col + 1] && matrix[row + 1][col] == matrix[row + 1][col + 1] && matrix[row][col] == matrix[row + 1][col])
                    {
                        foundEquals++;
                    }
                }
            }

            Console.WriteLine(foundEquals);
        }
    }
}
