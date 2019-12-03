using System;
using System.Linq;

namespace _04._Add_VAT
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();
            Func<double, double> addVat = number => number *= 1.2;

            var vatedNumbers = input.Select(addVat).ToArray();

            foreach (var number in vatedNumbers)
            {
                Console.WriteLine($"{number:F2}");
            }
        }
    }
}
