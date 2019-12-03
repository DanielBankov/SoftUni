using System;
using System.Linq;

namespace _09._Crossfire
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSize = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var input = Console.ReadLine();
            var matrix = new int[matrixSize[0]][];

            FillMatrix(matrix, matrixSize);
            
            while(input != "Nuke it from orbit")
            {
                var coordinates = input.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                var targetRow = coordinates[0];
                var targetCol = coordinates[1];
                var radius = coordinates[2];

                Replace(matrix, targetRow, targetCol, radius);
                Remove(matrix);

                input = Console.ReadLine();
            }

            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join(" ", row.Where(n => n > 0)));
            }

        }

        private static void Remove(int[][] matrix)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                if (matrix[row].Contains(-1))
                {
                    matrix[row] = matrix[row].Where(r => r > 0).ToArray();
                }
                if (matrix[row].Length < 1)
                {
                    matrix = matrix.Take(row).Concat(matrix.Skip(row + 1)).ToArray();
                    row--;
                }
            }
        }

        private static void Replace(int[][] matrix, int targetRow, int targetCol, int radius)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if ((row == targetRow && Math.Abs(col - targetCol) <= radius) || 
                        (col == targetCol && Math.Abs(row - targetRow) <= radius))
                    {
                        matrix[row][col] = -1;
                    }
                }
            }
        }

        private static void FillMatrix(int[][] matrix, int[] matrixSize)
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
