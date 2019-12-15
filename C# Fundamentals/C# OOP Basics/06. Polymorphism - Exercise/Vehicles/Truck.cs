using System;

namespace Vehicles
{
    public class Truck : Vehicle
    {
        private const double airConditionersConsumption = 1.6;

        public Truck(double fuelQuantity, double litersPerKM) 
            : base(fuelQuantity, litersPerKM)
        {
        }

        public override void Driving(double driveKM)
        {
            if ((this.LitersPerKM + airConditionersConsumption) * driveKM > FuelQuantity)
            {
                Console.WriteLine("Truck needs refueling");
            }
            else
            {
                Console.WriteLine($"Truck travelled {driveKM} km");
                this.FuelQuantity -= (this.LitersPerKM + airConditionersConsumption) * driveKM;
            }
        }

        public override void Refueling(double refuel)
        {
            FuelQuantity += refuel * 0.95;
        }

        public override string ToString()
        {
            return $"Truck: {this.FuelQuantity:f2}";
        }
    }
}
