using System;
using System.Linq;

class MatrixOfPalindromes
{
    static void Main()
    {
        int[] matrixSize = Console.ReadLine().Split().Select(int.Parse).ToArray();
        string[][] matrix = new string[matrixSize[0]][];
        char[] alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();

        for (int row = 0; row < matrix.Length; row++)
        {
            matrix[row] = new string[matrixSize[1]];

            for (int col = 0; col < matrix[row].Length; col++)
            {
                char firstLetter = alphabet[row];
                char midLetter = alphabet[row + col];

                matrix[row][col] = $"{firstLetter}{midLetter}{firstLetter} ";

                Console.Write(matrix[row][col]);
            }
            Console.WriteLine();
        }  
    }
}

