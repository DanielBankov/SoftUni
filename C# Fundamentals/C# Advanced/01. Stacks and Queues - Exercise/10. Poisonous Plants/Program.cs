using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._Poisonous_Plants
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            List<int> plants = Console.ReadLine().Split().Select(int.Parse).ToList();
            Stack<int> plantsIndexes = new Stack<int>();

            int days = 0;

            while (true)
            {
                for (int i = 0; i < plants.Count - 1; i++)
                {
                    if (plants[i] < plants[i + 1])
                    {
                        plantsIndexes.Push(i + 1);
                    }
                }

                int indexCount = plantsIndexes.Count();

                if (indexCount == 0)
                {
                    break;
                }
                else
                {
                    days++;
                }

                for (int i = 0; i < indexCount; i++)
                {
                    plants.RemoveAt(plantsIndexes.Pop());
                }
            }

            Console.WriteLine(days);
        }
    }
}
