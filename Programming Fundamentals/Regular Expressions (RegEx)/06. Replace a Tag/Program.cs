using System;
using System.Text.RegularExpressions;

namespace _06._Replace_a_Tag
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"<a.*?href.*?=(.*)>(.*?)<\/a>";
            string input = Console.ReadLine();

            while (input != "end")
            {
                string replaced = Regex.Replace(input, pattern, "[URL href=$1]$2[/URL]");

                Console.WriteLine(replaced);
                input = Console.ReadLine();
            }
        }
    }
}
