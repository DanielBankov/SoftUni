using System;

namespace _09._Celsius_to_Fahrenheit
{
    class Program
    {
        static void Main(string[] args)
        {
            double C = double.Parse(Console.ReadLine());
            var F = C * 1.8 + 32;

            Console.WriteLine(Math.Round(F, 2));
        }
    }
}
