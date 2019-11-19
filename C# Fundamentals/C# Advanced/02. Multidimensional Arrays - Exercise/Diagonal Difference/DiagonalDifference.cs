using System;
using System.Linq;

class DiagonalDifference
{
    static void Main()
    {
        int matrixSize = int.Parse(Console.ReadLine());
        int[][] matrix = new int[matrixSize][];

        for (int row = 0; row < matrix.Length; row++)
        {
            matrix[row] = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        }

        int primary = PrimaryDiagonal(matrix);
        int secondary = SecondaryDiagonalSum(matrix);
        Console.WriteLine($"{Math.Abs(primary - secondary)}");

    }

    private static int SecondaryDiagonalSum(int[][] matrix)
    {
        int sum = 0;
        int count = 0;

        for (int row = 0; row < matrix.Length; row++)
        {
            for (int col = matrix[row].Length - 1; col > matrix[row].Length - 2; col--)
            {
                sum += matrix[row][col - count++];
            }
        }

        return sum;
    }

    private static int PrimaryDiagonal(int[][] matrix)
    {
        int sum = 0;
        int count = 0;

        for (int row = 0; row < matrix.Length; row++)
        {
            for (int col = 0; col < 1; col++)
            {
                sum += matrix[row][col + count++];
            }
        }

        return sum;
    }
}
