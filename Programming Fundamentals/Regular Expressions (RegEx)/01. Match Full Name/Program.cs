using System;
using System.Text.RegularExpressions;

namespace _01._Match_Full_Name
{
    class Program
    {
        static void Main(string[] args)
        {
            string regex = @"\b[A-Z][a-z]+ [A-Z][a-z]+\b";

            string names = Console.ReadLine();

            MatchCollection matchNmaes = Regex.Matches(names, regex);

            foreach (Match name in matchNmaes)
            {
                Console.Write(name.Value + " ");
            }

            Console.WriteLine();
        }
    }
}
