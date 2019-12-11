using System;

namespace PizzaCalories
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string[] inputPizza = Console.ReadLine().Split();
            string[] inputDough = Console.ReadLine().Split();

            string pizzaName = inputPizza[1];
            string flourType = inputDough[1];
            string bakingTehnique = inputDough[2];
            double doughWeigh = double.Parse(inputDough[3]);

            Dough dough = new Dough(flourType, bakingTehnique, doughWeigh);
            Pizza pizza = new Pizza(pizzaName, dough);

            string[] inputTopping = Console.ReadLine().Split();

            while (inputTopping[0] != "END")
            {
                string toppingType = inputTopping[1];
                double toppingWeigh = double.Parse(inputTopping[2]);

                Topping topping = new Topping(toppingType, toppingWeigh);
                pizza.Add(topping);

                inputTopping = Console.ReadLine().Split();
            }

            Console.WriteLine(pizza);
        }

    }
}
