using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Reverse_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputNumbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var stack = new Stack<int>();

            for (int i = 0; i < inputNumbers.Length; i++)
            {
                stack.Push(inputNumbers[i]);
            }

            foreach (var number in stack)
            {
                Console.Write(number + " ");
            }

            Console.WriteLine();
        }
    }
}
