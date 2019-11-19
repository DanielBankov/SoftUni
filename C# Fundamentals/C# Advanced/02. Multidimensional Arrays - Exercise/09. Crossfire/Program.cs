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
                var row = coordinates[0];
                var col = coordinates[1];
                var radius = coordinates[2];


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
