using MySpecialApp.Contracts;
using System;

namespace MySpecialApp.Models
{
    public class ConsoleWriter : IWriter
    {
        public void Write(string text)
        {
            Console.Write(text);
        }
    }
}
