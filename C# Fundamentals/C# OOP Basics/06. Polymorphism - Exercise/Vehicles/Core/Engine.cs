using System;

namespace Vehicles.Core
{
    public class Engine
    {
        public void Run()
        {
            string[] carInfo = Console.ReadLine().Split();
            string[] truckInfo = Console.ReadLine().Split();

            double carFuelQuantity = double.Parse(carInfo[1]);
            double carFuelPerKM = double.Parse(carInfo[2]);

            double truckFuelQuantity = double.Parse(truckInfo[1]);
            double truckFuelPerKM = double.Parse(truckInfo[2]);

            Vehicle car = new Car(carFuelQuantity, carFuelPerKM);
            Vehicle truck = new Truck(truckFuelQuantity, truckFuelPerKM);

            int num = int.Parse(Console.ReadLine());

            for (int i = 0; i < num; i++)
            {
                string[] command = Console.ReadLine().Split();

                if(command[0] == "Drive")
                {
                    if(command[1] == "Car")
                    {
                        car.Driving(double.Parse(command[2]));
                    }
                    else if(command[1] == "Truck")
                    {
                        truck.Driving(double.Parse(command[2]));
                    }
                }
                else if (command[0] == "Refuel")
                {
                    if(command[1] == "Car")
                    {
                        car.Refueling(double.Parse(command[2]));
                    }
                    else if (command[1] == "Truck")
                    {
                        truck.Refueling(double.Parse(command[2]));
                    }
                }
            }

            Console.WriteLine(car.ToString());
            Console.WriteLine(truck.ToString());
        }
    }
}
