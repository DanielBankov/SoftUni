using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Sum_and_Average
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> inputNumbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            int sum = 0;

            foreach (var number in inputNumbers)
            {
                sum += number;
            }

            double average = (double)sum / inputNumbers.Count;

            Console.WriteLine($"Sum={sum}; Average={average:f2}");
        }
    }
}
