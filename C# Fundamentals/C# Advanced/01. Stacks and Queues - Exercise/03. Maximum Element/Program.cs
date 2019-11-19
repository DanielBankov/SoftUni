using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Maximum_Element
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberInput = int.Parse(Console.ReadLine());
            var stack = new Stack<int>();

            for (int i = 0; i < numberInput; i++)
            {
                var inputCommand = Console.ReadLine().Split().Select(int.Parse).ToArray();

                if (inputCommand[0] == 1)
                {
                    stack.Push(inputCommand[1]);
                }
                else if (inputCommand[0] == 2)
                {
                    stack.Pop();
                }
                else
                {
                    Console.WriteLine(stack.Max());
                }
            }
        }
    }
}
