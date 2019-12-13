namespace BirthdayCelebrations
{
    public class Pet : IBirthable, IName
    {
        private string name;
        private string birthdate;

        public Pet(string name, string birthdate)
        {
            Name = name;
            Birthdate = birthdate;
        }

        public string Name  {get;}
        public string Birthdate { get; }
    }
}
