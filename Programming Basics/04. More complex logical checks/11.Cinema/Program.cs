using System;

namespace _11._Cinema
{
    class Program
    {
        static void Main(string[] args)
        {
            string projection = Console.ReadLine();
            var r = int.Parse(Console.ReadLine());
            var s = int.Parse(Console.ReadLine());
            var fullOfZala = r * s;

            switch (projection)
            {
                case "Premiere": Console.WriteLine("{0:f2}", fullOfZala * 12, " leva");
                    break;
                case "Normal": Console.WriteLine("{0:f2}", fullOfZala * 7.50, " leva");
                    break;
                case "Discount": Console.WriteLine("{0:f2}", fullOfZala * 5, " leva");
                    break;
                default: Console.WriteLine("error");
                    return;
            }
        }
    }
}
