using System;

namespace SpeedRacing
{
    public class Car
    {
        private string  model;
        private double fuelAmount;
        private double fuelForOneKM;
        private double distance = 0;

        public Car(string model, double fuel, double fuelPerKM)
        {
            this.Model = model;
            this.FuelAmount = fuel;
            this.FuelForOneKM = fuelPerKM;
            this.Distance = distance;
        }

        public double Distance
        {
            get { return distance; }
            set { distance = value; }
        }

        public string  Model
        {
            get { return model; }
            set { model = value; }
        }

        public double FuelAmount
        {
            get { return fuelAmount; }
            set { fuelAmount = value; }
        }

        public double FuelForOneKM
        {
            get { return fuelForOneKM; }
            set { fuelForOneKM = value; }
        }

        public void CarDistance(int driveKM)
        {
            double move = driveKM * this.FuelForOneKM;
            
            if(move <= FuelAmount)
            {
                FuelAmount -= move;
                distance += driveKM;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }
    }
}
