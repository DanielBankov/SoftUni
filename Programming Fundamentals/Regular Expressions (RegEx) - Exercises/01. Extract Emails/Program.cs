using System;
using System.Text.RegularExpressions;

namespace _01._Extract_Emails
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(^| )[A-Za-z0-9][A-Za-z0-9.\-_]*@[a-z-]+(\.[a-z]+)+";
            string input = Console.ReadLine();

            MatchCollection reg = Regex.Matches(input, pattern);

            foreach (Match email in reg)
            {
                Console.WriteLine(email.Value.Trim());
            }
        }
    }
}
