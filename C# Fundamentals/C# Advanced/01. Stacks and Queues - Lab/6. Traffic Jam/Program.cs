using System;
using System.Collections.Generic;

namespace _6._Traffic_Jam
{
    class Program
    {
        static void Main(string[] args)
        {
            int passCars = int.Parse(Console.ReadLine());
            Queue<string> queue = new Queue<string>();
            string input = null;
            int count = 0;

            while ((input = Console.ReadLine()) != "end")
            {
                if (input != "green")
                {
                    queue.Enqueue(input);
                }
                else
                {
                    for (int i = 0; i < passCars; i++)
                    {
                        if (queue.Count < 1)
                        {
                            break;
                        }

                        Console.WriteLine($"{queue.Dequeue()} passed!");
                        count++;
                    }
                }
            }

            Console.WriteLine($"{count} cars passed the crossroads.");
        }
    }
}
