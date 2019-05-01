using System;
using System.Linq;

namespace _05._Rounding_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] arr = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();

            for (int i = 0; i < arr.Length; i++)
            {
                double result = arr[i];
                Console.WriteLine($"{result} => {Math.Round(result, MidpointRounding.AwayFromZero)}");
            }
        }
    }
}
