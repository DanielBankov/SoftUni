using System;
using System.Linq;

namespace _01._Action_Print
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputCollection = Console.ReadLine().Split(' ').ToArray();

            Action<string[]> names = name => Console.WriteLine(string.Join($"{Environment.NewLine}", name));
            names(inputCollection);
        }
    }
}
