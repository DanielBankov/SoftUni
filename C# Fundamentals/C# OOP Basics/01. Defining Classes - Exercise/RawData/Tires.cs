namespace RawData
{
    public class Tires
    {
        private int age;
        private double presure;

        public Tires(int age, double presure)
        {
            this.Age = age;
            this.Presure = presure;
        }

        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public double Presure
        {
            get { return presure; }
            set { presure = value; }
        }
    }
}
