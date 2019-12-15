namespace VehiclesExtension
{
    public class Car : Vehicle
    {
        private const double airConditionersConsumption = 0.9;

        public Car(double fuelQuantity, double litersPerKM, double tankCapacity) 
            : base(fuelQuantity, litersPerKM, tankCapacity)
        {
            this.LitersPerKM += airConditionersConsumption;
        }
    }
}
