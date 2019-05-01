using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Sort_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<decimal> digits = Console.ReadLine().Split(' ').Select(decimal.Parse).ToList();

            digits.Sort();

            foreach (var digit in digits)
            {
                Console.WriteLine(string.Join(" <= ", digit));
            }
        }
    }
}
