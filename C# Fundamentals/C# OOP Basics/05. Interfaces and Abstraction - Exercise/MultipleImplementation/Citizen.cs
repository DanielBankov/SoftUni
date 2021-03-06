﻿namespace PersonInfo
{
    public class Citizen : IPerson, IIdentifiable, IBirthable
    {
        private string name;
        private int age;
        private string birthdate;
        private string id;

        public Citizen(string name, int age, string id, string birthdate)
        {
            this.Name = name;
            this.Age = age;
            this.Birthdate = birthdate;
            this.Id = id;
        }
        public string Name
        {
            get;
            private set;
        }

        public int Age
        {
            get;
            private set;
        }

        public string Birthdate
        {
            get;
            private set;
        }

        public string Id
        {
            get;
            private set;
        }
    }
}
