namespace VehiclesExtension
{
    public class Truck : Vehicle
    {
        private const double airConditionersConsumption = 1.6;

        public Truck(double fuelQuantity, double litersPerKM, double tankCapacity) 
            : base(fuelQuantity, litersPerKM, tankCapacity)
        {
            this.LitersPerKM += airConditionersConsumption;
        }
    }
}
