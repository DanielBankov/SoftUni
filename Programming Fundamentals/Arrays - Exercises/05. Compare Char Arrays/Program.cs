﻿using System;
using System.Linq;

namespace _05._Compare_Char_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] arr1 = Console.ReadLine().Split(' ').Select(char.Parse).ToArray();
            char[] arr2 = Console.ReadLine().Split(' ').Select(char.Parse).ToArray();
            char[] arrA = arr1;
            char[] arrB = arr2;
            int index = 0;

            while (true)
            {
                if (arr1[index] < arr2[index]) break;
                if (arr1[index] > arr2[index])
                {
                    arrA = arr2;
                    arrB = arr1;
                    break;
                }
                else
                {
                    index++;
                    if (index == arr1.Length) break;
                    else if (index == arr2.Length)
                    {
                        arrA = arr2;
                        arrB = arr1;
                        break;
                    }
                }
            }

            Console.WriteLine(string.Join("", arrA));
            Console.WriteLine(string.Join("", arrB));
        }
    }
}
