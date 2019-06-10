using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02._Match_Phone_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            var pattern = @"\+359[ -]2[ -]\d{3}[ -]\d{4}\b";

            var input = Console.ReadLine();

            var regex = Regex.Matches(input, pattern);

            var phones = regex.Cast<Match>().Select(m => m.Value.Trim()).ToArray();

            Console.WriteLine(string.Join(", ", phones));
        }
    }
}
