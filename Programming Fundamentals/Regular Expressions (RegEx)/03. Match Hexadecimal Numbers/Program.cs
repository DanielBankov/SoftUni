using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _03._Match_Hexadecimal_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(?:0x)?[\dA-F]+\b";
            string input = Console.ReadLine();

            string[] dex = Regex.Matches(input, pattern).Cast<Match>().Select(x => x.Value).ToArray();

            Console.WriteLine(string.Join(" ", dex));
        }
    }
}
