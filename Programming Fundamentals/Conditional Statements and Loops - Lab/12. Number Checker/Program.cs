using System;

namespace _12._Number_Checker
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                double.Parse(Console.ReadLine());
                Console.WriteLine("It is a number.");
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid input!");
            }
        }
    }
}
