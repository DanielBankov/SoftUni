using System;

namespace _112.Volleyball
{
    class Program
    {
        static void Main(string[] args)
        {
            string yearType = Console.ReadLine();
            int p = int.Parse(Console.ReadLine());
            int h = int.Parse(Console.ReadLine());

            int weekends = 48;
            double leapYearProcent = 1.15;

            double weekendsInSofia = weekends - h;
            double saturdaysGames = weekendsInSofia * 3 / 4;
            double holiydays = (double)p * 2 / 3;
            double allPlayedDays = saturdaysGames + h + holiydays;

            if(yearType == "leap")
            {
               allPlayedDays *= leapYearProcent;
            }

            Console.WriteLine(Math.Floor(allPlayedDays));
        }
    }
}
