using System;

namespace _01._Square_Area
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("a = ");

            int a = int.Parse(Console.ReadLine());
            var area = a * a;

            Console.WriteLine("Square = {0}", area);
        }
    }
}
