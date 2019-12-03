using System;
using System.Linq;

namespace _03._Count_Uppercase_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            Func<string, bool> isUpper = word => word[0] == word.ToUpper()[0];

            var words = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).Where(isUpper).ToArray();

            foreach (var word in words)
            {
                Console.WriteLine(word);
            }
        }
    }
}
