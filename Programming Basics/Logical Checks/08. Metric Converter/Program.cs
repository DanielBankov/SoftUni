using System;

namespace _08.Metric_Converter
{
    class Program
    {
        static void Main(string[] args)
        {
            double enterNum = double.Parse(Console.ReadLine());
            string enterUnit = Console.ReadLine();
            string outUnit = Console.ReadLine();

            double num = enterNum;

            if (enterUnit == "mm")
            {
                num = enterNum / 1000;
            }
            else if (enterUnit == "cm")
            {
                num = enterNum / 100;
            }
            else if (enterUnit == "mi")
            {
                num = enterNum / 0.000621371192;
            }
            else if (enterUnit == "in")
            {
                num = enterNum / 39.3700787;
            }
            else if (enterUnit == "km")
            {
                num = enterNum / 0.001;
            }
            else if (enterUnit == "ft")
            {
                num = enterNum / 3.2808399;
            }
            else if (enterUnit == "yd")
            {
                num = enterNum / 1.0936133;
            }

            if (outUnit == "mm")
            {
                num = num * 1000;
            }
            else if (outUnit == "cm")
            {
                num = num * 100;
            }
            else if (outUnit == "mi")
            {
                num = num * 0.000621371192;
            }
            else if (outUnit == "in")
            {
                num = num * 39.3700787;
            }
            else if (outUnit == "km")
            {
                num = num * 0.001;
            }
            else if (outUnit == "ft")
            {
                num = num * 3.2808399;
            }
            else if (outUnit == "yd")
            {
                num = num * 1.0936133;
            }

            Console.WriteLine(num + " " + outUnit);
        }
    }
}
