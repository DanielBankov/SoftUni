using System;

namespace _12._Currency_Converter
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal value = decimal.Parse(Console.ReadLine());
            string inputCurrency = Console.ReadLine();
            string outputCurrency = Console.ReadLine();

            decimal firstRate = 0.0m;
            decimal secondRate = 0.0m;

            if (inputCurrency == "BGN")
            {
                firstRate = 1;
            }
            else if (inputCurrency == "USD")
            {
                firstRate = 1.79549m;
            }

            if (inputCurrency == "EUR")
            {
                firstRate = 1.95583m;
            }
            else if (inputCurrency == "GBP")
            {
                firstRate = 2.53405m;
            }


            if (outputCurrency == "BGN")
            {
                secondRate = 1;
            }
            else if (outputCurrency == "USD")
            {
                secondRate = 1.79549m;
            }

            if (outputCurrency == "EUR")
            {
                secondRate = 1.95583m;
            }
            else if (outputCurrency == "GBP")
            {
                secondRate = 2.53405m;

            }

            decimal result = value * (firstRate / secondRate);
            Console.WriteLine("{0} {1}", Math.Round(result, 2), outputCurrency);
        }
    }
}
