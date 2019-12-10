namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main()
        {
            Person firstPerson = new Person();
            Person secondPerson = new Person();
            Person thirdPerson = new Person();
            
            firstPerson.Name = "Pesho";
            firstPerson.Age = 20;
            
            secondPerson.Name = "Gosho";
            secondPerson.Age = 18;

            thirdPerson.Name = "Stamat";
            thirdPerson.Age = 43;
        }
    }
}
