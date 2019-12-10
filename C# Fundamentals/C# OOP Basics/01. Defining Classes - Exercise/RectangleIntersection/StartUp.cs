using System;
using System.Collections.Generic;
using System.Linq;

namespace RectangleIntersection
{
    public class StartUp
    {
        static void Main()
        {
            int[] num = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var rectangles = new Dictionary<string, Rectangle>();

            for (int i = 0; i < num[0]; i++)
            {
                string[] input = Console.ReadLine().Split();

                string id = input[0];
                double width = double.Parse(input[1]);
                double height = double.Parse(input[2]);
                double horizontal = double.Parse(input[3]);
                double vertical = double.Parse(input[4]);

                rectangles.Add(id, new Rectangle(id, width, height, horizontal, vertical));
                
            }

            for (int i = 0; i < num[1]; i++)
            {
                string[] input = Console.ReadLine().Split();

                Rectangle firstRec = rectangles[input[0]];
                Rectangle secondRec = rectangles[input[1]];

                Console.WriteLine(firstRec.FindIntersection(secondRec));
            }
        }
    }
}
