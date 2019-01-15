using System;

namespace _13.Area_of_Figures
{
    class Program
    {
        static void Main(string[] args)
        {
            string figure = Console.ReadLine();
            double sqareOrCircle = double.Parse(Console.ReadLine());

            var area = 0.0;

            if (figure == "rectangle" || figure == "triangle")
            {
                double rectangleOrTriangle = double.Parse(Console.ReadLine());

                if (figure == "rectangle")
                {
                    area = sqareOrCircle * rectangleOrTriangle;
                    Console.WriteLine(Math.Round(area, 3));
                }
                else
                {
                    area = (sqareOrCircle * rectangleOrTriangle) / 2;
                    Console.WriteLine(area);
                }
            }
            if (figure == "square" || figure == "circle")
            {
                if (figure == "square")
                {
                    area = sqareOrCircle * sqareOrCircle;
                    Console.WriteLine(area);
                }

                else
                {
                    area = (sqareOrCircle * sqareOrCircle) * Math.PI;
                    Console.WriteLine(area);
                }
            }
        }
    }
}
