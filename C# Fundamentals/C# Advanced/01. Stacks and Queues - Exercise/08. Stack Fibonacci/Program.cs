using System;
using System.Collections.Generic;

namespace _08._Stack_Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            Stack<long> stack = new Stack<long>();

            stack.Push(0);
            stack.Push(1);

            for (int i = 0; i < number - 1; i++)
            {
                long lastNum = stack.Pop();
                long value = lastNum + stack.Peek();

                stack.Push(lastNum);
                stack.Push(value);
            }

            Console.WriteLine(stack.Pop());
        }
    }
}
