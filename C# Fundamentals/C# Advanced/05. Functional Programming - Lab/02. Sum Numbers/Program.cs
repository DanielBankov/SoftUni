using System;
using System.Linq;

namespace _02._Sum_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputNumbers = Console.ReadLine();
            Func<string, int> parser = number => int.Parse(number);

            //also works
            //int parser(string number) => int.Parse(number);

            var numbers = inputNumbers.Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(parser).ToArray();

            Console.WriteLine(numbers.Count());
            Console.WriteLine(numbers.Sum());
        }
    }
}
