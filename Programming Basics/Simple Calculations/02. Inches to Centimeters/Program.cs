using System;

namespace _02._Inches_to_Centimeters
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Inches = ");

            var inches = double.Parse(Console.ReadLine());
            var centimetres = inches * 2.54;

            Console.Write("Centimetres is :");
            Console.WriteLine(centimetres);
        }
    }
}
