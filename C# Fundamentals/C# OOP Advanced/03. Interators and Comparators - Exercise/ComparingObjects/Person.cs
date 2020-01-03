using System;

namespace ComparingObjects
{
    public class Person : IComparable<Person>
    {
        private string name;
        private int age;
        private string town;

        public Person(string name, int age, string town)
        {
            this.Name = name;
            this.Age = age;
            this.Town = town;
        }

        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Town
        {
            get { return town; }
            set { town = value; }
        }

        public int CompareTo(Person other)
        {
            int result = this.Name.CompareTo(other.Name);

            if (this.Age.CompareTo(other.Age) == 0)
            {
                return result;
            }

            if(this.Town.CompareTo(other.Town) == 0)
            {
                return result;
            }

            return result;
        }
    }
}
