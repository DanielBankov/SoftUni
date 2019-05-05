using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Count_Real_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] arr = Console.ReadLine().Split().Select(double.Parse).ToArray();
            var dict = new SortedDictionary<double, int>();

            foreach (var number in arr)
            {
                if (dict.ContainsKey(number))
                {
                    dict[number]++;
                }
                else
                {
                    dict.Add(number, 1);
                }
            }

            foreach (var number in dict)
            {
                Console.WriteLine($"{number.Key} -> {number.Value}");
            }
        }
    }
}
