using System;

namespace PizzaCalories
{
    class Dough
    {
        private string flour;
        private string bakingTechnique;
        private double weight;

        public Dough(string flour, string baking, double weight)
        {
            this.Flour = flour;
            this.BackingTechique = baking;
            this.Weight = weight;
        }

        public double Weight
        {
            get { return weight; }

            set
            {
                if (value < 1 || value > 200)
                {
                    Exception ex = new Exception("Dough weight should be in the range [1..200].");
                    Console.WriteLine(ex.Message);
                    Environment.Exit(0);
                }

                weight = value;
            }
        }

        public string Flour
        {
            get { return flour; }

            set
            {
                if(value.ToLower() != "white" && value.ToLower() != "wholegrain")
                {
                    Exception ex = new Exception("Invalid type of dough.");
                    Console.WriteLine(ex.Message);
                    Environment.Exit(0);
                }

                flour = value.ToLower();
            }
        }

        public string BackingTechique
        {
            get { return bakingTechnique; }

            set
            {
                if (value.ToLower() != "crispy" && value.ToLower() != "chewy" && value.ToLower() != "homemade")
                {
                    Exception ex = new Exception("Invalid type of dough.");
                    Console.WriteLine(ex.Message);
                    Environment.Exit(0);
                }

                bakingTechnique = value.ToLower();
            }
        }

        public double DoughCalories { get => this.CalculateDoughCalories(); }

        private double CalculateDoughCalories()
        {
            double flourModifier = this.Flour == "white" ? 1.5 : 1.0;
            double bakingModifier = this.BackingTechique == "crispy" ? 0.9 : this.bakingTechnique == "chewy" ? 1.1 : 1.0;

            return this.weight * 2 * flourModifier * bakingModifier;
        }
    }
}
