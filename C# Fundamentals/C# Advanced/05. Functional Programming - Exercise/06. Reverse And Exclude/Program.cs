using System;
using System.Linq;

namespace _06._Reverse_And_Exclude
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputCollection = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var inputDivisible = int.Parse(Console.ReadLine());

            Func<int[], int[]> reverse = numbres => numbres.Reverse().ToArray();
            Func<int[], int[]> divide = numbers => numbers.Where(n => n % inputDivisible != 0).ToArray();
            Action<int[]> print = numbers => Console.WriteLine(string.Join(" ", inputCollection));

            inputCollection = reverse(inputCollection);
            inputCollection = divide(inputCollection);
            print(inputCollection);
        }
    }
}
