using System;

namespace _07._2D_Rectangle_Area
{
    class Program
    {
        static void Main(string[] args)
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());

            var width = Math.Abs(x2 - x1);
            var height = Math.Abs(y1 - y2);

            var area = width * height;
            var perimeter = (width + height) * 2;

            Console.WriteLine(area);
            Console.WriteLine(perimeter);
        }
    }
}
