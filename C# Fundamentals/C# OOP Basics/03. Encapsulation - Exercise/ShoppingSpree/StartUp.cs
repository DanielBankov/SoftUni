using System;
using System.Linq;
using System.Collections.Generic;

namespace ShoppingSpree
{
    class StartUp
    {
        static void Main()
        {
            string[] personInput = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);
            string[] productInput = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);

            List<Person> persons = new List<Person>();
            List<Product> products = new List<Product>();

            for (int i = 0; i < personInput.Length; i++)
            {
                string[] personInfo = personInput[i].Split("=", StringSplitOptions.RemoveEmptyEntries);
                string name = personInfo[0];
                decimal money = decimal.Parse(personInfo[1]);

                Person person = new Person(name, money);
                persons.Add(person);
            }

            for (int i = 0; i < productInput.Length; i++)
            {
                string[] personInfo = productInput[i].Split("=", StringSplitOptions.RemoveEmptyEntries);
                string name = personInfo[0];
                decimal money = decimal.Parse(personInfo[1]);

                Product product = new Product(name, money);
                products.Add(product);
            }

            string[] input = Console.ReadLine().Split(' ');

            while (input[0] != "END")
            {
                string buyer = input[0];
                string product = input[1];

                Product currProcuct = products.First(x => x.Name == product);
                persons.First(x => x.Name == buyer).Add(currProcuct);

                input = Console.ReadLine().Split(' ');
            }

            foreach (var person in persons)
            {
                Console.WriteLine(person.ToString());
            }
        }
    }
}
