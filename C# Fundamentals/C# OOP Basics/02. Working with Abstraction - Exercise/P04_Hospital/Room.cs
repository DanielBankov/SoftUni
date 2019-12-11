using System.Collections.Generic;

namespace P04_Hospital
{
    public class Room
    {
        public Room()
        {
            Pacients = new List<string>();
        }

        public List<string> Pacients { get; set; }
    }
}
