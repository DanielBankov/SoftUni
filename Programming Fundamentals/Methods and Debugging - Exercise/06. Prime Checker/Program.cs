using System;

namespace _06.Prime_Checker
{
    class Program
    {
        static void Main(string[] args)
        {
            long n = long.Parse(Console.ReadLine());
            Console.WriteLine(IsPrime(n));
        }

        private static bool IsPrime(long n)
        {
            int sqrtN = (int)Math.Sqrt(n);

            if (n <= 1)
            {
                return false;
            }
            else
            {
                for (int i = 2; i <= sqrtN; i++)
                {
                    if (n % i == 0)
                        return false;
                }
            }

            return true;
        }
    }
}