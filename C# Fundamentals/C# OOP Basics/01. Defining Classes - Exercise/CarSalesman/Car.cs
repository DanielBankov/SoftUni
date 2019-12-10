namespace CarSalesman
{
    public class Car
    {
        private string model;
        private Engine engine;
        private string weight;
        private string color;

        public Car(string model, Engine engine, string weight, string color)
        {
            this.Model = model;
            this.Engine = engine;
            this.Weight = weight;
            this.Color = color;
        }

        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        public Engine Engine
        {
            get { return engine; }
            set { engine = value; }
        }

        public string Weight
        {
            get { return weight; }
            set { weight = value; }
        }

        public string Color
        {
            get { return color; }
            set { color = value; }
        }

        public override string ToString()
        {
            return $"{model}:\n" +
                $"  {engine.Model}:\n" +
                $"    Power: {engine.Power}\n" +
                $"    Displacement: {engine.Displacement}\n" +
                $"    Efficiency: {engine.Efficiency}\n" +
                $"  Weight: {weight}\n" +
                $"  Color: {color}";
        }
    }
}
