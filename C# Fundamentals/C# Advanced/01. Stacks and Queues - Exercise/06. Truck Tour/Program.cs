using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Truck_Tour
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            var queue = new Queue<int[]>();

            for (int i = 0; i < number; i++)
            {
                var inputNumers = Console.ReadLine().Split().Select(int.Parse).ToArray();
                queue.Enqueue(inputNumers);
            }

            int count = 0;

            while (true)
            {
                int totalFuel = 0;

                foreach (var currentPump in queue)
                {
                    int amountOfPetrol = currentPump[0];
                    int distance = currentPump[1];

                    totalFuel += amountOfPetrol - distance;

                    if (totalFuel < 0)
                    {
                        count++;
                        int[] removePump = queue.Dequeue();
                        queue.Enqueue(removePump);
                        break;
                    }
                }

                if (totalFuel >= 0)
                {
                    break;
                }
            }

            Console.WriteLine(count);
        }
    }
}
