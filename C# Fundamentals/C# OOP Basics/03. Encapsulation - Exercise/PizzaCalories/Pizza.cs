using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzaCalories
{
    class Pizza
    {
        private string name;
        private Dough dough;
        private List<Topping> toppings;

        public Pizza(string name, Dough dough)
        {
            this.Name = name;
            this.Dough = dough;
            this.toppings = new List<Topping>();
        }

        public string Name
        {
            get { return name; }

            set
            {
                if(value.Length < 1 || value.Length > 15)
                {
                    Exception ex = new Exception($"Pizza name should be between 1 and 15 symbols.");
                    Console.WriteLine(ex.Message);
                    Environment.Exit(0);
                }

                name = value; } 
        }

        public Dough Dough
        {
            get { return dough; }
            set { dough = value; }
        }

        public List<Topping> Toppings
        {
            get { return toppings; }

            set
            {
                this.toppings = value;
            }
        }

        public void Add(Topping topping)
        {
            if (this.toppings.Count >= 10)
            {
                Exception ex = new Exception($"Number of toppings should be in range [0..10].");
                Console.WriteLine(ex.Message);
                Environment.Exit(0);
            }

            this.Toppings.Add(topping); 
        }

        private double GetCalories()
        {
            double doughCalories = this.Dough.DoughCalories;
            double toppingCalories = this.Toppings.Sum(c => c.ToppingCalories);
            return doughCalories + toppingCalories;
        }

        public override string ToString()
        {
            return $"{this.name} - {this.GetCalories():f2} Calories.";
        }
    }
}
