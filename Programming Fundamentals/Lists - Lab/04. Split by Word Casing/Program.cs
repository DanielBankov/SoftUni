using System;
using System.Collections.Generic;

namespace _04._Split_by_Word_Casing
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split(",;:.!()\"'\\/[] ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            List<string> lowerCase = new List<string>();
            List<string> upperCase = new List<string>();
            List<string> mixed = new List<string>();

            foreach (var word in words)
            {
                if (IsUpper(word))
                {
                    upperCase.Add(word);
                }
                else if (IsLower(word))
                {
                    lowerCase.Add(word);
                }
                else
                {
                    mixed.Add(word);
                }

            }

            Console.WriteLine($"Lower-case: {string.Join(", ", lowerCase)}");
            Console.WriteLine($"Mixed-case: {string.Join(", ", mixed)}");
            Console.WriteLine($"Upper-case: {string.Join(", ", upperCase)}");
        }

        private static bool IsLower(string text)
        {
            foreach (char letter in text)
            {
                if (letter < 'a' || letter > 'z')
                {
                    return false;
                }
            }
            return true;
        }

        private static bool IsUpper(string text)
        {
            foreach (char letter in text)
            {
                if (letter < 'A' || letter > 'Z')
                {
                    return false;
                }
            }
            return true;
        }
    }
}
