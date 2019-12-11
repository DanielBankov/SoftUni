using System;

namespace Cars
{
    public class Tesla : IElectricCar
    {
        private string model;
        private string color;
        private int battery;

        public Tesla(string model, string color, int battery)
        {
            Model = model;
            Color = color;
            Battery = battery;
        }

        public int Battery
        {
            get => battery;
            private set => battery = value;
        }

        public string Model
        {
            get => model;
            private set => model = value;
        }

        public string Color
        {
            get => color;
            private set => color = value;
        }

        public void Start()
        {
            Console.WriteLine("Engine start");
        }

        public void Stop()
        {
            Console.WriteLine("Breaaak!");
        }

        public override string ToString()
        {
            return $"{color} Tesla {model} with {battery} batteries";
        }
    }
}
