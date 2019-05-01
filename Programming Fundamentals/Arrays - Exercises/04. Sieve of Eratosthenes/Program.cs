using System;

namespace _04._Sieve_of_Eratosthenes
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            bool[] primes = new bool[n + 1];

            for (int i = 0; i <= n; i++)
            {
                primes[i] = true;
                primes[0] = primes[1] = false;
            }

            for (int i = 2; i < n; i++)
            {
                if (primes[i])
                {
                    for (int p = 2 * i; p <= n; p += i)
                    {
                        primes[p] = false;
                    }
                }
            }

            for (int i = 0; i <= n; i++)
            {
                if (primes[i])
                {
                    Console.Write("{0} ", i);
                }
            }
        }
    }
}
