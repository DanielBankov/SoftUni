using System;
using System.Linq;

namespace _04._Distance_between_Points
{
    class Program
    {
        static void Main(string[] args)
        {
            Point p1 = MakePoints(Console.ReadLine());
            Point p2 = MakePoints(Console.ReadLine());
            
            Console.WriteLine($"{CalcDistance(p1, p2):f3}");
        }

        private static Point MakePoints(string input)
        {
            int[] points = input.Split().Select(int.Parse).ToArray();
            return new Point
            {
                X = points[0],
                Y = points[1]
            };
        }

        private static double CalcDistance(Point p1, Point p2)
        {
            int sideA = p1.X - p2.X;
            int sideB = p1.Y - p2.Y;

            return Math.Sqrt(sideA * sideA + sideB * sideB);
        }
    }

    class Point
    {
        public int X { get; set; }

        public int Y { get; set; }
    }
}
