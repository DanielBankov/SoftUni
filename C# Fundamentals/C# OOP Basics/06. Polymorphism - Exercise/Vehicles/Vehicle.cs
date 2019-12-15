namespace Vehicles
{
    public abstract class Vehicle
    {
        private double fuelQuantity;
        private double litersPerKM;

        public Vehicle(double fuelQuantity, double litersPerKM)
        {
            FuelQuantity = fuelQuantity;
            LitersPerKM = litersPerKM;
        }

        public double FuelQuantity
        {
            get { return fuelQuantity; }
            set { fuelQuantity = value; }
        }

        public double LitersPerKM
        {
            get { return litersPerKM; }
            set { litersPerKM = value; }
        }

        public abstract void Driving(double driveKM);
        public abstract void Refueling(double refuel);
    }
}
