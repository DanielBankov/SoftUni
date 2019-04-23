using System;

namespace _10._Radians_to_Degrees
{
    class Program
    {
        static void Main(string[] args)
        {
            double radius = double.Parse(Console.ReadLine());
            var deg = radius * (180 / Math.PI);

            Console.WriteLine(Math.Round(deg));
        }
    }
}
