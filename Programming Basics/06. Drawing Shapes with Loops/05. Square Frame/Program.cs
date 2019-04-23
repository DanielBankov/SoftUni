using System;

namespace _05.Square_Frame
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                if (i == 0 || i == n - 1)
                {
                    Console.Write("+ ");
                }
                else
                {
                    Console.Write("| ");
                }

                for (int j = 0; j < n - 2; j++)
                {
                    Console.Write("- ");
                }

                if (i == 0 || i == n - 1)
                {
                    Console.Write("+ ");
                }
                else
                {
                    Console.Write("| ");
                }
                Console.WriteLine();
            }
        }
    }
}
