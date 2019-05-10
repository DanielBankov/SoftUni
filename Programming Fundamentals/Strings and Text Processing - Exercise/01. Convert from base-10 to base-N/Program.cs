using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace _01._Convert_from_base_10_to_base_N
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split().Select(BigInteger.Parse).ToList();

            List<BigInteger> result = new List<BigInteger>();
            BigInteger BaseN = input[0];
            BigInteger Base10 = input[1];

            while (Base10 != 0)
            {
                result.Add(Base10 % BaseN);
                Base10 = Base10 / BaseN;
            }

            result.Reverse();
            Console.WriteLine(string.Join("", result));
        }
    }
}
