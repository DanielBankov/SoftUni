using System;
using System.Collections.Generic;

namespace _05._Count_Symbols
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<char, int> letters = new SortedDictionary<char, int>();
            string text = Console.ReadLine();

            for (int i = 0; i < text.Length; i++)
            {
                if (!letters.ContainsKey(text[i]))
                {
                    letters.Add(text[i], 0);
                }

                letters[text[i]]++;
            }

            foreach (var kvp in letters)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value} time/s");
            }
        }
    }
}
