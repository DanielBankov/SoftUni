using System;

namespace _06._Triples_of_Letters
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    for (int k = 0; k < n; k++)
                    {
                        char letter0 = (char)('a' + i);
                        char letter1 = (char)('a' + j);
                        char letter2 = (char)('a' + k);

                        Console.WriteLine($"{letter0}{letter1}{letter2}");
                    }
                }
            }
        }
    }
}
