namespace FoodShortage
{
    public class Rebel : IBuy
    {
        private string name;
        private int age;
        private string group;
        private int food;

        public Rebel(string name, int age, string group)
        {
            Name = name;
            Age = age;
            Food = food;
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public int Food { get; set; }

        public void BuyFood()
        {
            Food += 5;
        }
    }
}
