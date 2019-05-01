using System;
using System.Linq;

namespace _06._Sum_Reversed_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split().Select(a => int.Parse(new string(a.Reverse().ToArray())));

            Console.WriteLine(numbers.Sum());
        }
    }
}
