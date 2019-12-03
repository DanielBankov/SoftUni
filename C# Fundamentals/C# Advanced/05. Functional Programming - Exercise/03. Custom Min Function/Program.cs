using System;
using System.Linq;

namespace _03._Custom_Min_Function
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputNumbers = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            Func<int[], int> smallestNumber = number => number.Min();
            Action<int> print = num => Console.WriteLine(num);
            print(smallestNumber(inputNumbers));
        }
    }
}
