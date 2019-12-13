using System;
using System.Linq;

namespace Telephony
{
    public class Smartphone : ICallable, IBrowsable
    {
        public void Browsing(string browser)
        {
            if (browser.Any(x => char.IsDigit(x)))
            {
                Console.WriteLine("Invalid URL!");
            }
            else
            {
                Console.WriteLine($"Browsing: {browser}!");
            }
        }

        public void Calling(string number)
        {
            if (number.All(x => char.IsDigit(x)))
            {
                Console.WriteLine($"Calling... {number}");
            }
            else
            {
                Console.WriteLine("Invalid number!");
            }
        }
    }
}
