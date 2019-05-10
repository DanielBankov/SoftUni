using System;
using System.Numerics;

namespace _03._Big_Factorial
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = int.Parse(Console.ReadLine());
            BigInteger factorial = 1;

            for (int i = 1; i <= input; i++)
            {
                factorial *= i;
            }

            Console.WriteLine(factorial);
        }
    }
}
