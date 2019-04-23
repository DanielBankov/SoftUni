using System;

namespace Problem_01
{
    class Program
    {
        static void Main(string[] args)
        {
            int QtyCups = int.Parse(Console.ReadLine());
            int workers = int.Parse(Console.ReadLine());
            int workDays = int.Parse(Console.ReadLine());

            int workHours = workDays * workers * 8;
            double cups = workHours / 5;

            double losses = 0;
            
            if(cups >= QtyCups)
            {
                losses = (cups - QtyCups) * 4.2;
                Console.WriteLine($"{losses:f2} extra money");
            }
            else
            {
                losses = (QtyCups - cups) * 4.2;
                Console.WriteLine($"Losses: {losses:f2}");
            }
             
        }
    }
}
