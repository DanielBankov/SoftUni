using System;
using System.Linq;
using System.Collections.Generic;

namespace CarSalesman
{
    public class StartUp
    {
        public static void Main()
        {
            int enginecount = int.Parse(Console.ReadLine());

            List<Engine> engines = new List<Engine>();
            List<Car> cars = new List<Car>();

            for (int i = 0; i < enginecount; i++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string model = input[0];
                int power = int.Parse(input[1]);
                string displacement = "n/a";
                string efficiency = "n/a";

                if (input.Length == 3)
                {
                    if (int.TryParse(input[2], out int result))
                    {
                        displacement = result.ToString();
                    }
                    else
                    {
                        efficiency = input[2];
                    }
                }
                else if (input.Length == 4)
                {
                    displacement = input[2];
                    efficiency = input[3];
                }

                Engine engine = new Engine(model, power, displacement, efficiency);
                engines.Add(engine);
            }

            int carCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < carCount; i++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string model = input[0];
                Engine engine = engines.Where(x => x.Model == input[1]).FirstOrDefault(); // 
                string weight = "n/a";
                string color = "n/a";

                if(input.Length == 3)
                {
                    if(int.TryParse(input[2], out int result))
                    {
                        weight = result.ToString();
                    }
                    else
                    {
                        color = input[2];
                    }
                }
                else if(input.Length == 4)
                {
                    weight = input[2];
                    color = input[3];
                }

                Car car = new Car(model, engine, weight, color);
                cars.Add(car);
            }

            cars.ForEach(Console.WriteLine);
        }
    }
}
