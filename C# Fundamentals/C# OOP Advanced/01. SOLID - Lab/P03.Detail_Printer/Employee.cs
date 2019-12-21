﻿namespace P03.Detail_Printer
{
    public class Employee : IEmployee
    {
        public Employee(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }

        public override string ToString()
        {
            return $"Name: {this.Name}";
        }
    }
}
