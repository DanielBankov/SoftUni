using System;

namespace PizzaCalories
{
    class Topping
    {
        private string type;
        private double weight;

        public Topping(string type, double weight)
        {
            this.Type = type;
            this.Weight = weight;
        }

        public double Weight
        {
            get { return weight; }

            set
            {
                if(value < 1 || value > 50)
                {
                    //string type = char.ToUpper(this.type[0]) + this.type.Substring(1);

                    Exception ex = new Exception($"{this.type} weight should be in the range [1..50].");
                    Console.WriteLine(ex.Message);
                    Environment.Exit(0);
                }

                this.weight = value;
            }
        }

        public string Type
        {
            get { return type; }

            set
            {
                if(value.ToLower() != "meat" && value.ToLower() != "veggies" && value.ToLower() != "cheese" && value.ToLower() != "sauce")
                {
                    Exception ex = new Exception($"Cannot place {value} on top of your pizza.");
                    Console.WriteLine(ex.Message);
                    Environment.Exit(0);
                }

                this.type = value;
            }
        }

        public double ToppingCalories { get => this.CalculateTopingCalories(); }

        private double CalculateTopingCalories()
        {
            double modifire = GetType();
            return modifire * 2 * this.weight;
        }

        private new double GetType()
        {
            switch (this.type.ToLower())
            {
                case "meat":
                    return 1.2;
                case "veggies":
                    return 0.8;
                case "cheese":
                    return 1.1;
                case "sauce":
                    return 0.9;
            }

            return 0;
        }
    }
}
