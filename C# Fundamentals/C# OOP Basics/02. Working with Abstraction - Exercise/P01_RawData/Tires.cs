namespace P01_RawData
{
    public class Tires
    {
        public double Preasure { get; set; }
        public int Age { get; set; }

        public Tires(double preasure, int age)
        {
            this.Preasure = preasure;
            this.Age = age;
        }
    }
}
