namespace FoodShortage
{
    public class Citizen : IIdentifiable, IBirthable, IBuy
    {
        private string name;
        private int age;
        private string id;
        private string birthdate;
        private int food;

        public Citizen(string name, int age, string id, string birthdate)
        {
            Name = name;
            Age = age;
            Id = id;
            Birthdate = birthdate;
        }

        public string Name { get; set; }
        public int Age { get; }
        public string Birthdate { get; }
        public string Id { get; }
        public int Food { get; set; }

        public void BuyFood()
        {
            Food += 10;
        }
    }
}
