using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Find_Evens_or_Odds
{
    class Program
    {
        static void Main(string[] args)
        {
            var range = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var command = Console.ReadLine();

            var numbers = new List<int>();

            Predicate<int> predicate = OddOrEven(command);
            Action<List<int>> print = num => Console.WriteLine(string.Join(" ", num));

            var start = range[0];
            var end = range[1];

            for (int i = start; i <= end; i++)
            {
                if (predicate(i))
                {
                    numbers.Add(i);
                }
            }

            print(numbers);
        }

        private static Predicate<int> OddOrEven(string command)
        {
            return com => command == "even" ? com % 2 == 0 : com % 2 != 0;
        }
    }
}
