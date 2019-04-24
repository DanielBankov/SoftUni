using System;

namespace _08._Calories_Counter
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int cheese = 500;
            int tomatoSauce = 150;
            int salami = 600;
            int pepper = 50;
            int ingredients = 0;

            for (int i = 1; i <= n; i++)
            {
                string names = Console.ReadLine().ToLower();

                if (names == "cheese")
                {
                    ingredients += cheese;
                }
                else if (names == "tomato sauce")
                {
                    ingredients += tomatoSauce;
                }
                else if (names == "salami")
                {
                    ingredients += salami;
                }
                else if (names == "pepper")
                {
                    ingredients += pepper;
                }
            }

            Console.WriteLine($"Total calories: {ingredients}");
        }
    }
}
