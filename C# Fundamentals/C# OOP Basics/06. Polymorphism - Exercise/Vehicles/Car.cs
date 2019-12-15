using System;

namespace Vehicles
{
    public class Car : Vehicle
    {
        private const double airConditionersConsumption = 0.9;

        public Car(double fuelQuantity, double litersPerKM) 
            : base(fuelQuantity, litersPerKM)
        {
        }

        public override void Driving(double driveKM)
        {
            if ((this.LitersPerKM + airConditionersConsumption) * driveKM > FuelQuantity)
            {
                Console.WriteLine("Car needs refueling");
            }
            else
            {
                Console.WriteLine($"Car travelled {driveKM} km");
                this.FuelQuantity -= (this.LitersPerKM + airConditionersConsumption) * driveKM;
            }
        }

        public override void Refueling(double refuel)
        {
            this.FuelQuantity += refuel;
        }

        public override string ToString()
        {
            return $"Car: {this.FuelQuantity:f2}";
        }
    }
}
