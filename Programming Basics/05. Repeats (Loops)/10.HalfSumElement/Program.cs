using System;

class Program
{
    static void Main(string[] args)
    {
        {
            int number = int.Parse(Console.ReadLine());
            int allNumbers = 0;
            int valueNumbers = 0;

            for (int i = 0; i < number; i++)
            {
                int m = int.Parse(Console.ReadLine());
                allNumbers += m;

                if (valueNumbers < m)
                {
                    valueNumbers = m;
                }
            }

            allNumbers -= valueNumbers;

            if (allNumbers == valueNumbers)
            {
                Console.WriteLine($"Yes\nSum = {allNumbers}");
            }
            else
            {
                Console.WriteLine($"No\nDiff = {Math.Abs(allNumbers - valueNumbers)}");
            }
        }
    }
}