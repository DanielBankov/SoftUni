using System.Collections.Generic;

namespace P04_Hospital
{
    public class Doctor
    {
        public Doctor(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            Pacients = new List<string>();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<string> Pacients { get; set; }
    }
}
