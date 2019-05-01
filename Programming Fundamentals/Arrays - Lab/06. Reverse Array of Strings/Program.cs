using System;
using System.Linq;

namespace _06._Reverse_Array_of_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ').ToArray();

            var reverse = input.Reverse();

            Console.WriteLine(string.Join(" ", reverse));
        }
    }
}
