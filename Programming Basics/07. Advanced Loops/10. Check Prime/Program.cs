using System;

namespace _10.Check_Prime
{
    class Program
    {
        static void Main(string[] args)
        {
           int n = int.Parse(Console.ReadLine());
           bool isPrime = true;

           if (n < 2) 
           {
               isPrime = false;
           }

           else
           {
               for (int i = 2; i <= Math.Sqrt(n); i++)
               {
                   if (n % i == 0)
                   {
                       isPrime = false;
                       break;
                   }
               }
           }

           if (isPrime)
           {
               Console.WriteLine("Prime");
           }
           else
           {
               Console.WriteLine("Not Prime");
           }
         
            
            int m = 0;

            while (true)
            {
                Console.Write("Enter even number: ");

                m = int.Parse(Console.ReadLine());

                if (m % 2 == 0)
                    break;

                Console.WriteLine("The number is not even.");
            }

            Console.WriteLine("Even number entered: {0}", m);
        }
    }
}
