using System;
using System.Linq;

namespace _01._Chess_Tournament
{
    class Program
    {
        //The results for a recent Chess tournament between five close rivals is described below:

        //Dale finished before Alex.
        //Emery finished after Blake.
        //Alex finished before Chris.
        //Emery finished after Dale.
        //Blake finished before Alex.
        //Dale finished after Blake.
        //Chris finished before Emery.

        //Describes end when the 'end' is received. Who finished where?

        static void Main(string[] args)
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

        //Answer: Blake won...then Dale, Alex, Chris and Emery.
        //By placing the person who finished higher to the left we have:

        //1. Dale finished before Alex     Dale    > Alex
        //2. Emery finished after Blake    Blake   > Emery
        //3. Alex finished before Chris    Alex    > Chris
        //4. Emery finished after Dale     Dale    > Emery
        //5. Blake finished before Alex    Blake   > Alex
        //6. Dale finished after Blake     Blake   > Dale
        //7. Chris finished before Emery   Chris   > Emery

        //From 1 and 3:
        //   Dale > Alex > Chris
        //Adding 7:
        //   Dale > Alex > Chris > Emery
        //Adding 6:
        //   Blake > Dale > Alex > Chris > Emery
    }
}

