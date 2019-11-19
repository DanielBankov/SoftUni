using System;
using System.Linq;

namespace _08._Radioactive_Bunnies
{
    class Program
    {
        static char[,] board;
        static int playerRow;
        static int playerCol;
        static int rowsLength;
        static int columsLength;

        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();
            board = ReadAndFillMatrix(dimensions);
            char[] movments = Console.ReadLine().ToCharArray();

            foreach (char move in movments)
            {
                int[] previousLocation = MovePlayer(move);
                MultiplyBunnies();
                if (IsPlayerOnBoard())
                {
                    if (board[playerRow, playerCol] == 'B')
                    {
                        Die();
                    }
                    continue;
                }

                Win(previousLocation);
            }
        }

        private static void Win(int[] previousLocation)
        {
            PrintBoard();
            int row = previousLocation[0];
            int col = previousLocation[1];

            Console.WriteLine($"won: {row} {col}");
            Environment.Exit(0);
        }

        private static void PrintBoard()
        {
            for (int row = 0; row < rowsLength; row++)
            {
                for (int col = 0; col < columsLength; col++)
                {
                    Console.Write(board[row, col]);
                }
                Console.WriteLine();
            }
        }

        private static void Die()
        {
            PrintBoard();
            Console.WriteLine($"dead: {playerRow} {playerCol}");
            Environment.Exit(0);
        }

        private static bool IsPlayerOnBoard()
        {
            bool validRow = playerRow >= 0 && playerRow < rowsLength;
            bool valindCol = playerCol >= 0 && playerCol < columsLength;

            if (validRow && valindCol)
            {
                return true;
            }
            return false;
        }

        private static void MultiplyBunnies()
        {
            for (int row = 0; row < rowsLength; row++)
            {
                for (int col = 0; col < columsLength; col++)
                {
                    if (board[row, col] == 'B')
                    {
                        if (row > 0)
                        {
                            NewBunny(row - 1, col);
                        }
                        if (row < rowsLength - 1)
                        {
                            NewBunny(row + 1, col);
                        }
                        if (col > 0)
                        {
                            NewBunny(row, col - 1);
                        }
                        if (col < columsLength - 1)
                        {
                            NewBunny(row, col + 1);
                        }
                    }
                }
            }
            for (int row = 0; row < rowsLength; row++)
            {
                for (int col = 0; col < columsLength; col++)
                {
                    if (board[row, col] == 'X')
                    {
                        board[row, col] = 'B';
                    }
                }
            }
        }

        private static void NewBunny(int row, int col)
        {
            if (board[row, col] != 'B')
            {
                board[row, col] = 'X';
            }
        }

        private static int[] MovePlayer(char move)
        {
            int[] previousLocation = { playerRow, playerCol };

            switch (move)
            {
                case 'U':
                    playerRow--;
                    break;
                case 'D':
                    playerRow++;
                    break;
                case 'R':
                    playerCol++;
                    break;
                case 'L':
                    playerCol--;
                    break;
            }

            if (IsPlayerOnBoard() && board[playerRow, playerCol] != 'B')
            {
                board[playerRow, playerCol] = 'P';
            }

            int oldRow = previousLocation[0];
            int oldCol = previousLocation[1];

            board[oldRow, oldCol] = '.';
            return previousLocation;
        }

        private static char[,] ReadAndFillMatrix(int[] dimensions)
        {
            rowsLength = dimensions[0];
            columsLength = dimensions[1];
            char[,] matrix = new char[rowsLength, columsLength];

            for (int row = 0; row < rowsLength; row++)
            {
                char[] rowInput = Console.ReadLine().ToCharArray();
                for (int col = 0; col < columsLength; col++)
                {
                    matrix[row, col] = rowInput[col];
                    if (rowInput[col] == 'P')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }

            return matrix;
        }
    }
}
