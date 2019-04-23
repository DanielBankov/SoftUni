using System;

namespace _06._PointOnRectangleBorder
{
    class Program
    {
        static void Main(string[] args)
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());
            double x = double.Parse(Console.ReadLine());
            double y = double.Parse(Console.ReadLine());

            bool onLeftSide = x == x1 && y >= y1 && y <= y2;
            bool onRightSide = x == x2 && y >= y1 && y <= y2;
            bool onTopSide = y == y1 && x >= x1 && x <= x2;
            bool onBotSide = y == y2 && x >= x1 && x <= x2;

            bool inSomeBorder = onLeftSide || onRightSide || onTopSide || onBotSide;

            if (!inSomeBorder)
            {
                Console.WriteLine("Inside / Outside");
            }
            else
            {
                Console.WriteLine("Border");
            }
        }
    }
}
