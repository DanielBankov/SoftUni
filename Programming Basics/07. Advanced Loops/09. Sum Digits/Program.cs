using System;

class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        var fact = 0;

        do
        {
            int currentNumber = n % 10;
            fact += currentNumber;
            n /= 10;
        }
        while (n > 0);

        Console.WriteLine(fact);
    }
}
