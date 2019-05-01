using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Append_Lists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> texts = Console.ReadLine().Split('|').ToList();

            texts.Reverse();

            foreach (var text in texts)
            {
                string[] printText = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                Console.Write(string.Join(" ", printText));
                Console.Write(" ");
            }
        }
    }
}
