using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _03._Camera_View
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] elements = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string text = Console.ReadLine();
            string pattern = @"\|<(.*?)(?=\||$)";

            MatchCollection matches = Regex.Matches(text, pattern);
            List<string> camera = new List<string>();

            foreach (Match match in matches)
            {
                string elem = string.Concat(match.Groups[1].ToString().Skip(elements[0]).Take(elements[1]).ToArray());
                camera.Add(elem);
            }

            Console.WriteLine(string.Join(", ", camera));
        }
    }
}
