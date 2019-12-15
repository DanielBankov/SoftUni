using System;
using VehiclesExtension.Contracts;

namespace VehiclesExtension
{
    public abstract class Vehicle : IVehicle
    {
        private double fuelQuantity;
        private double litersPerKM;
        private double tankCapacity;

        public Vehicle(double fuelQuantity, double litersPerKM, double tankCapacity)
        {
            TankCapacity = tankCapacity;
            FuelQuantity = fuelQuantity;
            LitersPerKM = litersPerKM;
        }

        public bool IsVehicleEmpty { get; set; }

        public double TankCapacity
        {
            get { return tankCapacity; }
            set { tankCapacity = value; }
        }

        public double FuelQuantity
        {
            get { return fuelQuantity; }
            set
            {
                if (value > TankCapacity)
                {
                    value = 0;
                }

                fuelQuantity = value;
            }
        }

        public double LitersPerKM
        {
            get { return litersPerKM; }
            set { litersPerKM = value; }
        }

        public virtual void Driving(double distance)
        {
            double currentFuelConsumption = this.FuelQuantity;

            if (!IsVehicleEmpty)
            {
                currentFuelConsumption += 1.4;
            }

            double neededFuel = distance * this.LitersPerKM;

            if (neededFuel > FuelQuantity)
            {
                throw new ArgumentException($"{this.GetType().Name} needs refueling");
            }

            this.FuelQuantity -= neededFuel;

            Console.WriteLine($"{this.GetType().Name} travelled {distance} km");
        }

        public void Refueling(double refuel)
        {
            if (refuel <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }

            if (FuelQuantity + refuel > TankCapacity)
            {
                throw new ArgumentException($"Cannot fit {refuel} fuel in the tank");
            }

            if (this is Truck)
            {
                refuel *= 0.95;
            }

            this.FuelQuantity += refuel;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
        }
    }
}
