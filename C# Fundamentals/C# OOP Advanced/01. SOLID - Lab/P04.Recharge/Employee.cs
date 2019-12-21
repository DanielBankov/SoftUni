﻿using System;

namespace P04.Recharge
{
    public class Employee : Worker, ISleeper
    {
        public Employee(string id) 
            : base(id)
        {
        }

        public void Sleep()
        {
            Console.WriteLine("Sleeping..");
        }

        public override void Work(int hours)
        {
            this.WorkingHours += hours;
        }
    }
}
