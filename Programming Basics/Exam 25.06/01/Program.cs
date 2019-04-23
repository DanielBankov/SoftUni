using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberDays = int.Parse(Console.ReadLine());
            int numberWorkers = int.Parse(Console.ReadLine());
            int numberTorta = int.Parse(Console.ReadLine());
            int numberGofreti = int.Parse(Console.ReadLine());
            int numberPalachinki = int.Parse(Console.ReadLine());

            double torti = numberTorta * 45;
            double gofreti = numberGofreti * 5.8;
            double palachinki = numberPalachinki * 3.2;

            double priceForDay = (torti + gofreti + palachinki) * numberWorkers;

            double priceOfCampany = priceForDay * numberDays;
            double razhodi = (priceOfCampany * 0.125) - priceOfCampany;

            Console.WriteLine($"{razhodi:f2}");    
                
         }
    }
}
