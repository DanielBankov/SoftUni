using System;

namespace Problem_12
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            int controlN = int.Parse(Console.ReadLine());

            int comb = 0;
            int suma = 0;

            for (int i = 1; i <= n; i++)
            {
                for (int j = m; j >= 1; j--)
                {
                    comb ++;
                    suma += (i * 2) + (j * 3);

                    if (suma >= controlN)
                    {
                        Console.WriteLine($"{comb} moves");
                        Console.WriteLine($"Score: {suma} >= {controlN}");
                        return;
                    }
                }
            }

            Console.WriteLine($"{comb} moves");
        }
    }
}
