using System;
using System.Linq;

namespace _02._Knights_of_Honor
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputCollection = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

            Action<string[]> append = names => Console.WriteLine("Sir " + string.Join($"{Environment.NewLine}Sir ",  names));
            append(inputCollection);
        }
    }
}