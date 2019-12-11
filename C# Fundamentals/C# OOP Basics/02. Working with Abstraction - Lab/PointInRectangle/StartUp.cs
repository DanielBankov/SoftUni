using System;
using System.Linq;

namespace PointInRectangle
{
    public class StartUp
    {
        static void Main()
        {
            int[] n = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Rectangle rectangle = new Rectangle()
            {
                topLeft = new Point(n[0], n[1]),
                botRight = new Point(n[2], n[3])
            };

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                int[] point = Console.ReadLine().Split().Select(int.Parse).ToArray();

                Console.WriteLine(rectangle.Contains(new Point(point[0], point[1])));

            }
        }
    }
}
