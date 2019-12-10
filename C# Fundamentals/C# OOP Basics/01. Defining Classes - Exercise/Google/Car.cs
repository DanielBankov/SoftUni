namespace Google
{
    public class Car
    {
        public Car(string model, string speed)
        {
            this.Model = model;
            this.Speed = speed;
        }

        public string Model { get; set; }
        public string Speed { get; set; }

        public override string ToString()
        {
            if(this.Model == null || this.Speed == null)
            {
                return "";
            }

            return $"{this.Model} {this.Speed}\n";
        }
    }
}
