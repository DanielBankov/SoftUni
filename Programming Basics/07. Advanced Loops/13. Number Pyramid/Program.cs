using System;

namespace _13.Number_Pyramid
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int num = 1;
            bool shouldBreak = false;

            for (int row = 1; row <= n; row++)
            {
                for (int col = 0; col < row; col++)
                {
                    Console.Write($"{num} ");
                    num ++;

                    if (num > n)
                    {
                        shouldBreak = true;
                        break;
                    }
                }

                if (shouldBreak)
                    break;

                Console.WriteLine();
            }
        }
    }
}
