using System;

namespace _03._PointInRectangle
{
    class Program
    {
        static void Main(string[] args)
        {
            var x1 = 2;
            var x2 = 12;
            var y1 = -3;
            var y2 = 3;

            var xOfPoint = double.Parse(Console.ReadLine());
            var yOfPoint = double.Parse(Console.ReadLine());

            if (xOfPoint > x1 && xOfPoint < x2)
            {
                if (yOfPoint > y2 && yOfPoint < y1)
                {
                    Console.WriteLine("Inside");
                }
                else
                {
                    Console.WriteLine("Outside");
                }
            }
            else
            {
                Console.WriteLine("Outside");
            }
        }
    }
}
