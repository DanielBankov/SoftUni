using System;

namespace Shapes
{
    public class StartUp
    {
        public static void Main()
        {
            int radius = int.Parse(Console.ReadLine());
            int width = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());

            IDrawable circle = new Circle(radius);
            circle.Draw();

            IDrawable rectangle = new Rectangle(width, height);
            rectangle.Draw();
        }
    }
}
