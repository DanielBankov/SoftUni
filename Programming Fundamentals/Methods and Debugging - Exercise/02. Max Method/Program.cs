using System;

namespace _02.Max_Method
{
    class Program
    {
        static void Main(string[] args)
        {
            int c = int.Parse(Console.ReadLine());
            Console.WriteLine(Math.Max(c, GetMax(c)));
        }
        private static int GetMax(int a)
        {
            a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int maxDigit = Math.Max(a, b);
            return maxDigit;
        }
    }
}