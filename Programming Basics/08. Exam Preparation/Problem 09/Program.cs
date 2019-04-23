using System;

namespace Problem_09
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= 9; i++)
            {
                for (int j = 1; j <= 9; j++)
                {
                    for (int k = 1; k <= 9; k++)
                    {
                        for (int l = 1; l <= 9; l++)
                        {
                            for (int f = 1; f <= 9; f++)
                            {
                                for (int g = 1; g <= 9; g++)
                                {
                                    if(i * j * k * l * f * g == n)
                                        Console.Write($"{i}{j}{k}{l}{f}{g} ");
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
