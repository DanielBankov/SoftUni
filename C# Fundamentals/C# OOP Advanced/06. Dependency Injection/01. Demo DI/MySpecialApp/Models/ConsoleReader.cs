using MySpecialApp.Contracts;
using System;

namespace MySpecialApp.Models
{
    public class ConsoleReader : IReader
    {
        public string Read()
        {
            return Console.ReadLine();
        }
    }
}
