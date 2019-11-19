using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Parking_Lot
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] command = Console.ReadLine().Split(", ").ToArray();
            HashSet<string> carParking = new HashSet<string>();

            while (command[0] != "END")
            {
                if (command[0] == "IN")
                {
                    carParking.Add(command[1]);
                }

                if (command[0] == "OUT")
                {
                    carParking.Remove(command[1]);
                }
                command = Console.ReadLine().Split(", ").ToArray();
            }

            if (carParking.Count == 0)
            {
                Console.WriteLine("Parking Lot is Empty");
                return;
            }

            foreach (var car in carParking)
            {
                Console.WriteLine(car);
            }
        }
    }
}
