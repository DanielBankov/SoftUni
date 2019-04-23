using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02
{
    class Program
    {
        static void Main(string[] args)
        {
            double recorSek = double.Parse(Console.ReadLine());
            double metersM = double.Parse(Console.ReadLine());
            double timeSek = double.Parse(Console.ReadLine());

            double needToSwim = metersM * timeSek;
            double realTime = (Math.Floor(metersM / 15) * 12.5);
            double time = needToSwim + realTime;
            double neededTime = 0;
            neededTime = Math.Abs(recorSek - time);
            if (recorSek <= time)
            {
                
                Console.WriteLine($"No, he failed! He was {(neededTime):f2} seconds slower.");
                
            }
            else
            {
                Console.WriteLine($"Yes, he succeeded! The new world record is {time:f2} seconds.");
            }
        }
    }
}
