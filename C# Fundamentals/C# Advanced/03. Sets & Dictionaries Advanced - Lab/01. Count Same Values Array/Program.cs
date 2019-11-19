using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Count_Same_Values_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] inputNumbers = Console.ReadLine().Split().Select(double.Parse).ToArray();
            Dictionary<double, int> dict = new Dictionary<double, int>();

            for (int i = 0; i < inputNumbers.Length; i++)
            {
                if (!dict.ContainsKey(inputNumbers[i]))
                {
                    dict.Add(inputNumbers[i], 1);
                }
                else
                {
                    dict[inputNumbers[i]]++;
                }
            }

            foreach (var number in dict)
            {
                Console.WriteLine($"{number.Key} - {number.Value} times");
            }
        }
    }
}
