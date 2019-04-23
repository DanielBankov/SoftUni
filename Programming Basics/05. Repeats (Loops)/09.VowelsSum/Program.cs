using System;

class Program
{
    static void Main(string[] args)
    {
        {
            string word = Console.ReadLine();
            int value = 0;

            for (int i = 0; i < word.Length; i++)
            {
                char symboy = word[i];

                if (symboy == 'a')
                {
                    value += 1;
                }
                else if (symboy == 'e')
                {
                    value += 2;
                }
                else if (symboy == 'i')
                {
                    value += 3;
                }
                else if (symboy == 'o')
                {
                    value += 4;
                }
                else if (symboy == 'u')
                {
                    value += 5;
                }
            }

            Console.WriteLine(value);
        }
    }
}