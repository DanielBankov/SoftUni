using System;
using System.Collections.Generic;
using WildFarm.Animals;
using WildFarm.Animals.Birds;
using WildFarm.Animals.Mammals;
using WildFarm.Animals.Mammals.Feline;
using WildFarm.Foods;

namespace WildFarm.Core
{
    public class Engine
    {
        private IAnimal animal;
        private List<IAnimal> animals;

        private Food food;

        public Engine()
        {
            animals = new List<IAnimal>();
        }

        public void Run()
        {
            string[] animalInfo = Console.ReadLine().Split();

            while (animalInfo[0] != "End")
            {
                string[] foodInfo = Console.ReadLine().Split();

                //TODO create animal and food Add method 
                //TODO remove foodEaten form methods

                string type = animalInfo[0];
                string name = animalInfo[1];
                double weight = double.Parse(animalInfo[2]);

                if (type.ToLower() == "cat" || type.ToLower() == "tiger")
                {
                    string livingRegion = animalInfo[3];
                    string breed = animalInfo[4];

                    if (type.ToLower() == "cat")
                    {
                        animal = new Cat(name, weight, livingRegion, breed);
                    }
                    else
                    {
                        animal = new Tiger(name, weight, livingRegion, breed);
                    }
                }

                if (type.ToLower() == "owl" || type.ToLower() == "hen")
                {
                    double wingSize = double.Parse(animalInfo[3]);

                    if (type.ToLower() == "owl")
                    {
                        animal = new Owl(name, weight, wingSize);
                    }
                    else
                    {
                        animal = new Hen(name, weight, wingSize);
                    }
                }

                if (type.ToLower() == "mouse" || type.ToLower() == "dog")
                {
                    string livingRegion = animalInfo[3];

                    if (type.ToLower() == "mouse")
                    {
                        animal = new Mouse(name, weight, livingRegion);
                    }
                    else
                    {
                        animal = new Dog(name, weight, livingRegion);
                    }
                }

                string foodType = foodInfo[0];
                int foodQuantity = int.Parse(foodInfo[1]);

                if (foodType.ToLower() == "vegetable")
                {
                    food = new Vegetable(foodQuantity);
                }
                else if (foodType.ToLower() == "fruit")
                {
                    food = new Fruit(foodQuantity);
                }
                else if (foodType.ToLower() == "meat")
                {
                    food = new Meat(foodQuantity);
                }
                else if (foodType.ToLower() == "seeds")
                {
                    food = new Seeds(foodQuantity);
                }

                animal.ProduceSound();
                animal.Eat(food);
                animals.Add(animal);

                animalInfo = Console.ReadLine().Split();
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal.ToString());
            }
        }
    }
}
