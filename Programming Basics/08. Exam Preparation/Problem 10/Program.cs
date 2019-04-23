using System;

namespace Problem_10
{
    class Program
    {
        static void Main()
        {
            int m = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());
            int l = int.Parse(Console.ReadLine());

            double specialNum = int.Parse(Console.ReadLine());
            double controlNum = int.Parse(Console.ReadLine());

            for (int i = m; i >= 1; i--)
            {
                for (int j = n; j >= 1; j--)
                {
                    for (int k = l; k >= 1; k--)
                    {
                        int num = (i * 100) + (j * 10) + k;
                        if (num % 3 == 0)
                            specialNum += 5;
                        else if (num % 10 == 5)
                            specialNum -= 2;
                        else if (num % 2 == 0)
                            specialNum *= 2;
                        if (specialNum >= controlNum)
                            break;
                    }
                    if (specialNum >= controlNum)
                        break;
                }
                if (specialNum >= controlNum)
                    break;
            }
            if (specialNum >= controlNum)
                Console.WriteLine($"Yes! Control number was reached! Current special number is {specialNum}.");
            else
                Console.WriteLine($"No! {specialNum} is the last reached special number.");
        }
    }
}