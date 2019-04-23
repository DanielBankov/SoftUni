using System;

namespace _08._Triangle_Area
{
    class Program
    {
        static void Main(string[] args)
        {
            double a = double.Parse(Console.ReadLine());
            double h = double.Parse(Console.ReadLine());

            var area = a * h / 2;

            Console.WriteLine("Triangle area = " + Math.Round(area, 2));
        }
    }
}
