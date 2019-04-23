using System;

namespace _14.Number_Table
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
                    var num = i + j;
                    
                    if (num > n)
                    {
                        num = (num % n) - n;
                    }

                    Console.Write($"{Math.Abs(num)} ");
                }

                Console.WriteLine();
            }
        }
    }
}
