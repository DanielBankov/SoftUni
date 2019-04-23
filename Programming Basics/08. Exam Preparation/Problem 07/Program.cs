using System;

namespace Problem_07
{
    class Program
    {
        static void Main(string[] args)
        {
            int startNumber = int.Parse(Console.ReadLine());
            int finalNumber = int.Parse(Console.ReadLine()); 
            int magicNumber = int.Parse(Console.ReadLine());

            int interacii = 0;

            for (int i = startNumber; i >= finalNumber; i--)
            {
                for (int j = startNumber; j >= finalNumber; j--)
                {

                    interacii++;

                    if(i + j == magicNumber)
                    {
                        Console.WriteLine($"Combination N:{interacii} ({i} + {j} = {magicNumber})");
                        return;
                    }
                }
            }

            Console.WriteLine($"{interacii} combinations - neither equals {magicNumber}");
        }
    }
}
