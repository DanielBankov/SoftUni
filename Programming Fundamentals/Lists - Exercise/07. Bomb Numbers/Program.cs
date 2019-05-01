using System;
using System.Linq;

namespace _07._Bomb_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            var bombParameters = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var bombNumber = bombParameters[0];
            var bombStrength = bombParameters[1];

            while (numbers.Contains(bombNumber))
            {
                var bombIndex = numbers.IndexOf(bombNumber);

                var startIndex = Math.Max(bombIndex - bombStrength, 0);
                var count = Math.Min(bombStrength * 2 + 1, numbers.Count - startIndex);

                numbers.RemoveRange(startIndex, count);
            }

            Console.WriteLine(numbers.Sum());
        }
    }
}
