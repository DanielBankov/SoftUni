using System;
using System.Linq;
using System.Collections.Generic;

namespace SpeedRacing
{
    public class StartUp
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] inputCars = Console.ReadLine().Split();
                string carModel = inputCars[0];
                double carFuelAmount = double.Parse(inputCars[1]);
                double carFuelPerKM = double.Parse(inputCars[2]);

                cars.Add(new Car(carModel, carFuelAmount, carFuelPerKM));
            }

            string[] driveCommand = Console.ReadLine().Split();

            while (driveCommand[0] != "End")
            {
                string driveCar = driveCommand[1];
                int driveKM = int.Parse(driveCommand[2]);

                // extended 
                //var newList = cars.Where(x => x.Model == driveCar).ToList();
                //newList.ForEach(x => x.CarDistance(driveKM));

                cars.Where(x => x.Model == driveCar).ToList().ForEach(x => x.CarDistance(driveKM));
                driveCommand = Console.ReadLine().Split();
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.Distance}");
            }
        }
    }
}
