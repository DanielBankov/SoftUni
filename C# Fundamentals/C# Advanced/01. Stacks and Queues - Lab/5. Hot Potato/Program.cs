using System;
using System.Collections.Generic;

namespace _5._Hot_Potato
{
    class Program
    {
        static void Main(string[] args)
        {
            string childrens = Console.ReadLine();
            int number = int.Parse(Console.ReadLine());

            Queue<string> queue = new Queue<string>(childrens.Split(' '));

            while (queue.Count != 1)
            {
                for (int i = 0; i < number - 1; i++)
                {
                    string reminder = queue.Dequeue();
                    queue.Enqueue(reminder);

                }

                Console.WriteLine($"Removed {queue.Dequeue()}");
            }

            Console.WriteLine($"Last is {queue.Dequeue()}");
        }
    }
}
