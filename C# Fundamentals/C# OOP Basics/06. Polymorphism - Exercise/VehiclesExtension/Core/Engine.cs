using System;
using VehiclesExtension.Contracts;

namespace VehiclesExtension.Core
{
    public class Engine
    {
        public void Run()
        {
            string[] carInfo = Console.ReadLine().Split();
            string[] truckInfo = Console.ReadLine().Split();
            string[] busInfo = Console.ReadLine().Split();

            double carFuelQuantity = double.Parse(carInfo[1]);
            double carFuelPerKM = double.Parse(carInfo[2]);
            double carCapacity = double.Parse(carInfo[3]);

            double truckFuelQuantity = double.Parse(truckInfo[1]);
            double truckFuelPerKM = double.Parse(truckInfo[2]);
            double truckCapacity = double.Parse(truckInfo[3]);

            double busFuelQuantity = double.Parse(busInfo[1]);
            double busFuelPerKM = double.Parse(busInfo[2]);
            double busCapacity = double.Parse(busInfo[3]);

            IVehicle car = new Car(carFuelQuantity, carFuelPerKM, carCapacity);
            IVehicle truck = new Truck(truckFuelQuantity, truckFuelPerKM, truckCapacity);
            IVehicle bus = new Bus(busFuelQuantity, busFuelPerKM, busCapacity);

            int num = int.Parse(Console.ReadLine());

            for (int i = 0; i < num; i++)
            {
                try
                {
                    string[] command = Console.ReadLine().Split();

                    if (command[0] == "Drive")
                    {
                        if (command[1] == "Car")
                        {
                            car.Driving(double.Parse(command[2]));
                        }
                        else if (command[1] == "Truck")
                        {
                            truck.Driving(double.Parse(command[2]));
                        }
                        else if (command[1] == "Bus")
                        {
                            bus.IsVehicleEmpty = false;
                            bus.Driving(double.Parse(command[2]));
                        }
                    }
                    else if (command[0] == "Refuel")
                    {
                        if (command[1] == "Car")
                        {
                            car.Refueling(double.Parse(command[2]));
                        }
                        else if (command[1] == "Truck")
                        {
                            truck.Refueling(double.Parse(command[2]));
                        }
                        else if (command[1] == "Bus")
                        {
                            bus.Refueling(double.Parse(command[2]));
                        }
                    }
                    else if (command[0] == "DriveEmpty")
                    {
                        bus.IsVehicleEmpty = true;
                        bus.Driving(double.Parse(command[2]));
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.WriteLine(car.ToString());
            Console.WriteLine(truck.ToString());
            Console.WriteLine(bus.ToString());
        }
    }
}
