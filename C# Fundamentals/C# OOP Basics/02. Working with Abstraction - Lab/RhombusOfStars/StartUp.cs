using System;

namespace RhombusOfStars
{
    public class StartUp
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                PrintUpperTriangle(n, i);
            }

            for (int i = n - 2; i >= 0; i--)
            {
                PrintUpperTriangle(n, i);
            }
        }

        private static void PrintUpperTriangle(int n, int i)
        {
            for (int j = 1; j < n - i ; j++)
            {
                Console.Write(" ");
            }

            for (int j = 0; j < i; j++)
            {
                Console.Write("* ");
            }

            Console.WriteLine("*");
        }
    }
}
