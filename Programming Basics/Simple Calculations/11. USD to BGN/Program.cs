using System;

namespace _11._USD_to_BGN
{
    class Program
    {
        static void Main(string[] args)
        {
            //1 USD = 1.79549 BGN.

            double USD = double.Parse(Console.ReadLine());
            var BGN = USD * 1.79549;

            Console.WriteLine(Math.Round(BGN, 2) + " BGN");
        }
    }
}
