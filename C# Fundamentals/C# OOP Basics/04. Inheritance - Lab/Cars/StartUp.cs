using System;

namespace Cars
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            ICar seat = new Seat("Leon", "Grey");
            IElectricCar tesla = new Tesla("Model S", "Red", 2);

            Console.WriteLine(seat.ToString());
            seat.Start();
            seat.Stop();

            Console.WriteLine(tesla.ToString());
            tesla.Start();
            tesla.Stop();
        }
    }
}
