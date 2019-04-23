using System;

namespace Problem_05
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int l = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    for (char k = 'a'; k < 'a' + l; k++)
                    {
                        for (char d = 'a'; d < 'a' + l; d++)
                        {
                            for (int s = Math.Max(i ,j) + 1; s <= n; s++)
                            {
                                Console.Write($"{i}{j}{k}{d}{s} ");
                            }
                        }
                    }
                }
            }
        }
    }
}
