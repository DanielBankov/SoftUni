using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Square_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            List<int> sortNumbers = new List<int>();

            foreach (var digit in arr)
            {
                if (Math.Sqrt(digit) == (int)Math.Sqrt(digit))
                {
                    sortNumbers.Add(digit);
                }
            }

            sortNumbers.Sort((a, b) => b.CompareTo(a));
            Console.WriteLine(string.Join(" ", sortNumbers));
        }
    }
}
