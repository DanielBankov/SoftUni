using System;

namespace _01._Day_of_Week
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] day = { "monday", "tuesday", "wednesday", "thursday", "friday", "saturday", "sunday" };

            int num = int.Parse(Console.ReadLine());

            if (num < 1 || num > 7)
            {
                Console.WriteLine("Invalid day!");
            }
            else
            {
                Console.WriteLine(day[num - 1]);
            }
        }
    }
}
