using System;

namespace _04._Beverage_Labels
{
    class Program
    {
        static void Main(string[] args)
        {
            string productName = Console.ReadLine();
            int ml = int.Parse(Console.ReadLine());
            int kcal = int.Parse(Console.ReadLine());
            int g = int.Parse(Console.ReadLine());

            double totalEnergy = (double)kcal * ml / 100;
            double totalSugar = (double)g * ml / 100;

            Console.WriteLine($"{ml}ml {productName}: \n{totalEnergy}kcal, {totalSugar}g sugars");
        }
    }
}
