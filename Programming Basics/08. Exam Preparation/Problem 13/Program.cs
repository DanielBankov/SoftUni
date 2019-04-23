using System;

namespace Problem_13
{
    class Program
    {
        static void Main(string[] args)
        {
            char fromA = char.Parse(Console.ReadLine());
            char toZ = char.Parse(Console.ReadLine());
            char skipLetter = char.Parse(Console.ReadLine());
            int suma = 0;

            for (char i = fromA; i <= toZ; i++)
            {
                for (char j = fromA; j <= toZ; j++)
                {
                    for (char k = fromA; k <= toZ; k++)
                    {
                        if (i != skipLetter && j != skipLetter && k != skipLetter)
                        {
                            suma++;
                            Console.Write($"{i}{j}{k} ");
                        }
                    }
                }
            }

            Console.Write(suma);
        }
    }
}
