using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Basic_Queue_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            var integers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var enqueueNumber = integers[0];
            var dequeueNumber = integers[1];
            var containingNumber = integers[2];

            var queue = new Queue<int>();

            for (int i = 0; i < enqueueNumber; i++)
            {
                queue.Enqueue(numbers[i]);
            }

            for (int i = 0; i < dequeueNumber; i++)
            {
                queue.Dequeue();
            }

            int smallNumber = int.MaxValue;
            int queueCount = queue.Count;

            if(queueCount == 0)
            {
                Console.WriteLine(0);
                return;
            }

            if (queue.Contains(containingNumber))
            {
                Console.WriteLine(true);
                return;
            }

            for (int i = 0; i < queueCount; i++)
            {
                var currNumber = queue.Dequeue();
                if (smallNumber > currNumber)
                {
                    smallNumber = currNumber;
                }
            }

            Console.WriteLine(smallNumber);
        }
    }
}
