using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Simple_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string[] remainder = input.Split(' ').ToArray();
            Stack<string> stak = new Stack<string>(remainder.Reverse());

            while (stak.Count > 1)
            {
                int firstNum = int.Parse(stak.Pop());
                string operation = stak.Pop();
                int secondNum = int.Parse(stak.Pop());

                if (operation == "+")
                {
                    stak.Push((firstNum + secondNum).ToString());
                }
                else if (operation == "-")
                {
                    stak.Push((firstNum - secondNum).ToString());
                }
            }

            Console.WriteLine(stak.Pop());
        }
    }
}
