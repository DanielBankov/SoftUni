using System;

namespace Ferrari
{
    public class StartUp
    {
        static void Main()
        {
            string driver = Console.ReadLine();

            IFerari ferari = new Ferrari(driver);

            Console.WriteLine($"{ferari.Model}/{ferari.Breaks()}/{ferari.Gas()}/{ferari.Driver}");
        }
    }
}
