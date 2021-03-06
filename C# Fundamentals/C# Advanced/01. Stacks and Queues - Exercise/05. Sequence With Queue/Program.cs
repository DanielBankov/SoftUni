﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Sequence_With_Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            long number = long.Parse(Console.ReadLine());

            Queue<long> queue = new Queue<long>();
            queue.Enqueue(number);

            List<long> sequence = new List<long>();
            sequence.Add(number);

            while (sequence.Count < 50)
            {
                long currentNumber = queue.Dequeue();
                long firstNumber = currentNumber + 1;
                long secondNumber = 2 * currentNumber + 1;
                long thirdNumber = currentNumber + 2;

                sequence.Add(firstNumber);
                sequence.Add(secondNumber);
                sequence.Add(thirdNumber);

                queue.Enqueue(firstNumber);
                queue.Enqueue(secondNumber);
                queue.Enqueue(thirdNumber);
            }

            Console.WriteLine(string.Join(" ", sequence.Take(50)));
        }
    }
}
