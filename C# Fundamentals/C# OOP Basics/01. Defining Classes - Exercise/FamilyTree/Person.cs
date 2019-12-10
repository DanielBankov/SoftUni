using System;
using System.Collections.Generic;

namespace FamilyTree
{
    public class Person
    {
        private string name;
        private string  birthday;
        private List<Person> parants;
        private List<Person> chidren;

        public Person(string name, string birthday)
        {
            this.Name = name;
            this.BirthDay = birthday;
            this.Childern = new List<Person>();
            this.Parants = new List<Person>();
        }

        public List<Person> Childern
        {
            get { return chidren; }
            set { chidren = value; }
        }


        public List<Person> Parants
        {
            get { return parants; }
            set { parants = value; }
        }


        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public  string BirthDay
        {
            get { return birthday; }
            set { birthday = value; }
        }
    }
}
