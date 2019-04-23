using System;

namespace _03.Powers_of_Two
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int k = 1;

            for (int i = 0; i <= n; i++)
            {
                Console.WriteLine(k);
                k *= 2;
            }
        }
    }
}
