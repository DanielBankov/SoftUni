﻿using System;

namespace ShoppingSpree
{
    class Product
    {
        private string name;
        private decimal cost;

        public Product(string name, decimal cost)
        {
            this.Name = name;
            this.Cost = cost;
        }

        public string Name
        {
            get { return name; }

            set
            {
                if(string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    Exception ex = new Exception("Name cannot be empty");
                    Console.WriteLine(ex.Message);
                    Environment.Exit(0);
                }

                name = value;
            }
        }

        public decimal Cost
        {
            get { return cost; }

            set
            {
                if(value < 0)
                {
                    Exception ex = new Exception("Money cannot be negative");
                    Console.WriteLine(ex.Message);
                    Environment.Exit(0);
                }

                cost = value;
            }
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
