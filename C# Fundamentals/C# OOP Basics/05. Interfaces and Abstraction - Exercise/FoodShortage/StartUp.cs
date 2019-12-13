using System;
using System.Linq;
using System.Collections.Generic;

namespace FoodShortage
{
    public class StartUp
    {
        static void Main()
        {
            // redaktirai =)
            List<IBuy> products = new List<IBuy>();

            int num = int.Parse(Console.ReadLine());

            for (int i = 0; i < num; i++)
            {
                string[] input = Console.ReadLine().Split();

                if (input.Length == 4)
                {
                    string name = input[0];
                    int age = int.Parse(input[1]);
                    string id = input[2];
                    string birthdate = input[3];

                    products.Add(new Citizen(name, age, id, birthdate));
                }
                else if (input.Length == 3)
                {
                    string name = input[0];
                    int age = int.Parse(input[1]);
                    string group = input[2];

                    products.Add(new Rebel(name, age, group));
                }
            }

            string nameInput = Console.ReadLine();

            while (nameInput != "End")
            {
                IBuy currBuyer = products.FirstOrDefault(x => x.Name == nameInput);

                if(currBuyer != null)
                {
                    currBuyer.BuyFood();
                }

                nameInput = Console.ReadLine();
            }

            Console.WriteLine(products.Sum(x => x.Food));
        }
    }
}
