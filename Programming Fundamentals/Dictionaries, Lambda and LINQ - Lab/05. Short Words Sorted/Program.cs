using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Short_Words_Sorted
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] text = Console.ReadLine().ToLower().Split(".,:;()[]\"'\\/!? ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            List<string> printOutput = new List<string>();

            foreach (var letter in text)
            {
                if (letter.Length < 5)
                {
                    printOutput.Add(letter);
                }
            }

            List<string> result = new List<string>(printOutput.OrderBy(x => x).Distinct());

            Console.WriteLine(string.Join(", ", result));

        }
    }
}
