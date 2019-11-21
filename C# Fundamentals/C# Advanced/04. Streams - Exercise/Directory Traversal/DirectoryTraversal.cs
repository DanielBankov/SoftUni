using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _07.DirectoryTraversal
{
    class Program
    {
        static void Main()
        {
            var peopleInput = Console.ReadLine().Split().ToArray();

            var input = Console.ReadLine().Split(' ');

            while (input[0] != "end")
            {
                var firstPerson = input[0];
                var secondPerson = input[3];
                var state = input[2];

                var firstPersonIndex = Array.IndexOf(peopleInput, firstPerson);
                var secondPersonIndex = Array.IndexOf(peopleInput, secondPerson);

                if (state == "after" && firstPersonIndex < secondPersonIndex)
                {
                    Swap(peopleInput, firstPersonIndex, secondPersonIndex);
                }
                else if (state == "before" && firstPersonIndex > secondPersonIndex)
                {
                    Swap(peopleInput, firstPersonIndex, secondPersonIndex);
                }

                input = Console.ReadLine().Split(' ');
            }

            Console.WriteLine(string.Join(' ', peopleInput));
        }

        private static void Swap(string[] peopleInput, int firstPersonIndex, int secondPersonIndex)
        {
            var temp = peopleInput[firstPersonIndex];
            peopleInput[firstPersonIndex] = peopleInput[secondPersonIndex];
            peopleInput[secondPersonIndex] = temp;
        }
    }
}