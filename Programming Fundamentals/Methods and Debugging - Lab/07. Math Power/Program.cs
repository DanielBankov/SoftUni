using System;

namespace _07.LAb_Math_Power
{
    class Program
    {
        static void Main(string[] args)
        {
            double digit = double.Parse(Console.ReadLine());
            double pow = double.Parse(Console.ReadLine());

            DigitPowder(digit, pow);
        }

        private static void DigitPowder(double digit, double powder)
        {
            Console.WriteLine(Math.Pow(digit, powder));
        }
    }
}