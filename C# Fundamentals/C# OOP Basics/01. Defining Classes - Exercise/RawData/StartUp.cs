using System;
using System.Linq;
using System.Collections.Generic;

namespace RawData
{
    public class StartUp
    {
        public static void Main()
        {
            List<Car> cars = new List<Car>();
            int num = int.Parse(Console.ReadLine());

            for (int i = 0; i < num; i++)
            {
                string[] inputArgs = Console.ReadLine().Split();
                string model = inputArgs[0];
                int engineSpeed = int.Parse(inputArgs[1]);
                int enginePower = int.Parse(inputArgs[2]); 
                int cargoWeight = int.Parse(inputArgs[3]);
                string cargoType = inputArgs[4];

                List<Tires> tires = new List<Tires>();

                for (int j = 0; j < 4; j += 2)
                {
                    double tirePressure = double.Parse(inputArgs[5 + j]);
                    int tireAge = int.Parse(inputArgs[6 + j]);

                    Tires tire = new Tires(tireAge, tirePressure);
                    tires.Add(tire);
                }

                Engine engine = new Engine(enginePower, engineSpeed);
                Cargo cargo = new Cargo(cargoWeight, cargoType);

                Car car = new Car(model, engine, cargo, tires);
                cars.Add(car);
            }

            string command = Console.ReadLine();

            List<Car> resultCars = new List<Car>();

            if (command == "fragile")
            {   
                resultCars = cars.Where(x => x.Cargo.Type == "fragile" && x.Tires.Any(s => s.Presure < 1)).ToList();
            }
            else
            {
                resultCars = cars.Where(x => x.Cargo.Type == "flamable" && x.Engine.Power > 250).ToList();
            }

            foreach (var car in resultCars)
            {
                Console.WriteLine(car.Model);
            }
        }
    }
}
