namespace BorderControl
{
    public class Citizen : IIdentifiable
    {
        private string name;
        private int age;
        private string id;

        public Citizen(string name, int age, string id)
        {
            Name = name;
            Age = age;
            Id = id;
        }

        public string Name { get; }
        public int Age { get; }
        public string Id { get; }
    }
}
