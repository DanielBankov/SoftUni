using System;
using System.Linq;

namespace _05._Applied_Arithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputCollection = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            Func<int[], int[]> add = numbers => numbers.Select(n => n + 1).ToArray();
            Func<int[], int[]> multiply = numbers => numbers.Select(n => n * 2).ToArray();
            Func<int[], int[]> subtract = numbers => numbers.Select(n => n - 1).ToArray();
            Action<int[]> print = numbres => Console.WriteLine(string.Join(" ", numbres));
            var inputCommand = Console.ReadLine();

            while(inputCommand != "end")
            {
                switch (inputCommand)
                {
                    case "add":
                        inputCollection = add(inputCollection);
                        break;
                    case "multiply":
                        inputCollection = multiply(inputCollection);
                        break;
                    case "subtract":
                        inputCollection = subtract(inputCollection);
                        break;
                    case "print":
                        print(inputCollection);
                        break;
                }

                inputCommand = Console.ReadLine();
            }
        }
    }
}
