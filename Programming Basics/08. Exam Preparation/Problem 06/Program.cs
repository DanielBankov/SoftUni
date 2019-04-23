using System;

namespace Problem_06
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.WriteLine("{0}\\{1}/{0}", new string('*', i++), new string('-', (n * 2) - j - i + 1));
                }
            }

            for (int j = 0; j < n / 3; j++)
            {
                Console.WriteLine("|{0}\\{1}/{0}|", new string('*', (n / 2) + j), new string('*', (n - j) - j));
            }

            for (int i = 1; i <= n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.WriteLine("{0}\\{1}/{0}", new string('-', i++), new string('*', (n * 2) - j - i + 1));
                }
            }
        }
    }
}
