using System;

namespace Telephony
{
    public class StartUp
    {

        static void Main()
        {
            Smartphone smartphone = new Smartphone();

            string[] numbers = Console.ReadLine().Split();
            string[] browsers = Console.ReadLine().Split();

            for (int i = 0; i < numbers.Length; i++)
            {
                smartphone.Calling(numbers[i]);
            }

            for (int i = 0; i < browsers.Length; i++)
            {
                smartphone.Browsing(browsers[i]);
            }
        }
    }
}
