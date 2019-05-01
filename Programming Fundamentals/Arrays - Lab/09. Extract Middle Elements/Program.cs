using System;
using System.Linq;

namespace _09._Extract_Middle_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int lenght = arr.Length;
            int[] even = new int[1];
            int[] odd = new int[2];

            if (arr.Length == 1)
            {
                Console.WriteLine(arr[0]);
                return;
            }

            if (lenght % 2 == 0)
            {
                int firstDigit = arr.Length / 2;
                int secondDigit = arr.Length / 2 - 1;
                string result = arr[secondDigit] + ", " + arr[firstDigit];
                Console.WriteLine(($"{{{result}}}"));
            }
            else
            {
                int firstDigit = arr.Length / 2 - 1;
                int secondDigit = arr.Length / 2;
                int thirdSecond = arr.Length / 2 + 1;
                string result = arr[firstDigit] + " " + arr[secondDigit] + " " + arr[thirdSecond];
                Console.WriteLine($"{{{result}}}");
            }

            Console.WriteLine("Hello World!");
        }
    }
}
