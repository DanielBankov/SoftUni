using System;

namespace _05.LAB_Temperature_Conversion
{
    class Program
    {
        static void Main(string[] args)
        {
            double fahrenheit = double.Parse(Console.ReadLine());

            Console.WriteLine($"{FahrenheitToCelsius(fahrenheit):f2}");
        }

        private static double FahrenheitToCelsius(double fahrenheit)
        {
            double result = (fahrenheit - 32) * 5 / 9;
            return result;
        }
    }
}
