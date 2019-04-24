using System;

namespace _11._Convert_Speed_Units
{
    class Program
    {
        static void Main(string[] args)
        {
            float distanceInMeters = float.Parse(Console.ReadLine());
            float hours = float.Parse(Console.ReadLine());
            float minutes = float.Parse(Console.ReadLine());
            float seconds = float.Parse(Console.ReadLine());

            float totalSeconds = hours * 3600 + minutes * 60 + seconds;
            float totalHours = hours + minutes / 60 + seconds / 3600;

            Console.WriteLine(distanceInMeters / totalSeconds);
            Console.WriteLine(distanceInMeters / 1000 / totalHours);
            Console.WriteLine(distanceInMeters / 1609 / totalHours);
        }
    }
}
