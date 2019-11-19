using System;
using System.Linq;

namespace _04._Maximal_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSize = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[][] matrix = new int[matrixSize[0]][];

            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[row] = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            }

            int maxSum = 0;
            int currentSum = 0;
            int sumRow = 0;
            int sumCol = 0;

            for (int row = 0; row < matrix.Length - 2; row++)
            {
                for (int col = 0; col < matrix[row].Length - 2; col++)
                {
                    currentSum = matrix[row][col] + matrix[row][col + 1] + matrix[row][col + 2]
                        + matrix[row + 1][col] + matrix[row + 1][col + 1] + matrix[row + 1][col + 2]
                        + matrix[row + 2][col] + matrix[row + 2][col + 1] + matrix[row + 2][col + 2];

                    if (currentSum > maxSum)
                    {
                        maxSum = currentSum;
                        sumRow = row;
                        sumCol = col;
                    }
                }
            }

            Console.WriteLine($"Sum = {maxSum}");
            Console.WriteLine($"{matrix[sumRow][sumCol]} {matrix[sumRow][sumCol + 1]} {matrix[sumRow][sumCol + 2]}");
            Console.WriteLine($"{matrix[sumRow + 1][sumCol]} {matrix[sumRow + 1][sumCol + 1]} {matrix[sumRow + 1][sumCol + 2]}");
            Console.WriteLine($"{matrix[sumRow + 2][sumCol]} {matrix[sumRow + 2][sumCol + 1]} {matrix[sumRow + 2][sumCol + 2]}");
        }
    }
}
