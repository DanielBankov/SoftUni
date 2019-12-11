using System.Collections.Generic;

namespace P04_Hospital
{
    public class Department
    {
        public Department(string name)
        {
            Name = name;
            Rooms = new List<Room>();
        }

        public string  Name { get; set; }
        public List<Room> Rooms { get; set; }
    }
}
