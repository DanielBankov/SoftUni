using System;
using System.Linq;
using System.Collections.Generic;

namespace _04._Palindromes
{
    class Program
    {
        static void Main(string[] args)
        {
            var text = Console.ReadLine().Split(new char[] { ' ', ',', '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
            var palindromes = new List<string>();

            for (int i = 0; i < text.Length; i++)
            {
                char[] arr = text[i].ToCharArray();
                Array.Reverse(arr);
                var currWord = new string(arr);

                if (currWord == text[i])
                {
                    palindromes.Add(currWord);
                }
            }

            Console.WriteLine(string.Join(", ", palindromes.Distinct().OrderBy(x => x)));
        }
    }
}
