using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Basic_Stack_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            var operationNumbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var inputNumbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var stack = new Stack<int>();

            var pushNumbers = operationNumbers[0];
            var popNumbers = operationNumbers[1];
            var isNumberOnStack = operationNumbers[2];

            for (int i = 0; i < pushNumbers; i++)
            {
                stack.Push(inputNumbers[i]);
            }

            for (int i = 0; i < popNumbers; i++)
            {
                stack.Pop();
            }

            if (stack.Contains(isNumberOnStack))
            {
                Console.WriteLine("true");
            }
            else
            {
                if (stack.Count == 0)
                {
                    Console.WriteLine(0);
                    return;
                }
                Console.WriteLine(stack.Min());
            }
        }
    }
}
