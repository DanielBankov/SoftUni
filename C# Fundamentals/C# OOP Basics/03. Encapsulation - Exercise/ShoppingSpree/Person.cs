using System;
using System.Linq;
using System.Collections.Generic;

namespace ShoppingSpree
{
    class Person
    {
        private string name;
        private decimal money;
        private List<Product> proucts;

        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
            this.proucts = new List<Product>();
        }

        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    Exception ex = new Exception("Name cannot be empty");
                    Console.WriteLine(ex.Message);
                    Environment.Exit(0);
                }

                name = value;
            }
        }

        public decimal Money
        {
            get { return money; }

            set
            {
                if (value < 0)
                {
                    Exception ex = new Exception("Money cannot be negative");
                    Console.WriteLine(ex.Message);
                    Environment.Exit(0);
                }

                money = value;
            }
        }

        public List<Product> Proucts
        {
            get { return proucts; }
            set { proucts = value; }
        }

        public void Add(Product product)
        {
            decimal cost = product.Cost;
            string productName = product.Name;

            if(cost > this.money)
            {
                Console.WriteLine($"{this.name} can't afford {productName}");
            }
            else
            {
                this.proucts.Add(product);
                this.money -= cost;
                Console.WriteLine($"{this.name} bought {productName}");
            }
        }

        public override string ToString()
        {
            if(this.proucts.Count == 0)
            {
                return $"{this.name} - Nothing bought";
            }
            else
            {
                return $"{this.name} - {string.Join(", ", proucts.Select(x => x.Name))}";
            }
        }
    }
}
