using System;
using System.Collections.Generic;

namespace _1._Reverse_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            Stack<string> reverseText = new Stack<string>();

            foreach (var ch in text)
            {
                reverseText.Push(ch.ToString());
            }

            Console.WriteLine(string.Join("", reverseText));
        }
    }
}
