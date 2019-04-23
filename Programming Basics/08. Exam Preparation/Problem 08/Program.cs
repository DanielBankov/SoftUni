using System;

namespace Problem_08
{
    class Program
    {
        static void Main(string[] args)
        {
            int player1 = int.Parse(Console.ReadLine());
            int player2 = int.Parse(Console.ReadLine());
            int maxPoints = int.Parse(Console.ReadLine());

            int points = 0;

            for (int i = 1; i <= player1; i++)
            {
                for (int j = 1; j <= player2; j++)
                {
                    Console.Write($"({i} <-> {j}) ");
                    points++;

                    if (points >= maxPoints)
                        return;
                }
            }
        }
    }
}
