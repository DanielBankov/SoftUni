using System;
using System.Collections.Generic;
using System.Linq;

class TargetPractice
{
    static void Main()
    {
        int[] matrixSize = Console.ReadLine().Split().Select(int.Parse).ToArray();
        string snake = Console.ReadLine();
        int[] bombInfo = Console.ReadLine().Split().Select(int.Parse).ToArray();
        char[][] matrix = new char[matrixSize[0]][];

        int rowRadius = bombInfo[0];
        int colRadius = bombInfo[1];
        int radius = bombInfo[2];

        FillMatrix(matrix, matrixSize, snake);
        ShotAndReplace(matrix, rowRadius, colRadius, radius);
        Collapse(matrix);

        foreach (var item in matrix)
        {
            Console.WriteLine(string.Join("", item));
        }
    }

    private static void Collapse(char[][] matrix)
    {
        Stack<char> stack = new Stack<char>();

        for (int col = 0; col < matrix[0].Length; col++)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                if (matrix[row][col] != ' ')
                {
                    stack.Push(matrix[row][col]);
                }
            }

            for (int row = matrix.Length - 1; row >= 0; row--)
            {
                if (stack.Count != 0)
                {
                    matrix[row][col] = stack.Pop();
                }
                else
                {
                    matrix[row][col] = ' ';
                }
            }
        }
    }

    private static void ShotAndReplace(char[][] matrix, int rowRadius, int colRadius, int radius)
    {
        for (int row = 0; row < matrix.Length; row++)
        {
            for (int col = 0; col < matrix[row].Length; col++)
            {
                // a,2 + b,2 = c,2
                if (Math.Pow((row - rowRadius), 2) + Math.Pow((col - colRadius), 2) <= Math.Pow(radius, 2))
                {
                    matrix[row][col] = ' ';
                }
            }
        }
    }

    private static void FillMatrix(char[][] matrix, int[] matrixSize, string snake)
    {
        bool leftOrRightFill = true;
        int snakeIndexCount = 0;

        for (int row = matrix.Length - 1; row >= 0; row--)
        {
            matrix[row] = new char[matrixSize[1]];

            if (leftOrRightFill)
            {
                for (int col = matrix[row].Length - 1; col >= 0; col--)
                {
                    matrix[row][col] = snake[snakeIndexCount];
                    snakeIndexCount++;
                    if (snakeIndexCount > snake.Length - 1)
                    {
                        snakeIndexCount = 0;
                    }
                }
                leftOrRightFill = false;
            }
            else
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    matrix[row][col] = snake[snakeIndexCount];
                    snakeIndexCount++;
                    if (snakeIndexCount > snake.Length - 1)
                    {
                        snakeIndexCount = 0;
                    }
                }
                leftOrRightFill = true;
            }
        }
    }
}
