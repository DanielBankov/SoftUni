using System;

namespace VehiclesExtension
{
    public class Bus : Vehicle
    {
        private const double airConditionerConsumption = 1.4;

        public Bus(double fuelQuantity, double litersPerKM, double tankCapacity) 
            : base(fuelQuantity, litersPerKM, tankCapacity)
        {
        }

        public override void Driving(double distance)
        {
            double currentFuelConsumption = this.LitersPerKM;

            if (!IsVehicleEmpty)
            {
                currentFuelConsumption += airConditionerConsumption;
            }

            double neededFuel = distance * currentFuelConsumption;

            if (neededFuel > FuelQuantity)
            {
                throw new ArgumentException($"{this.GetType().Name} needs refueling");
            }

            this.FuelQuantity -= neededFuel;

            Console.WriteLine($"{this.GetType().Name} travelled {distance} km");
        }
    }
}
