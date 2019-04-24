using System;

namespace _03._Restaurant_Discount
{
    class Program
    {
        static void Main(string[] args)
        {
            int groupSize = int.Parse(Console.ReadLine());
            string package = Console.ReadLine();

            double hallPrice = 0;
            double discount = 0;
            double packigePrice = 0;
            double discountPrice = 0;
            string hall;

            if (groupSize <= 50)
            {
                hallPrice = 2500;

                switch (package)
                {
                    case "Normal":
                        discount = 0.05;
                        packigePrice = 500;
                        break;
                    case "Gold":
                        discount = 0.1;
                        packigePrice = 750;
                        break;
                    case "Platinum":
                        discount = 0.15;
                        packigePrice = 1000;
                        break;
                }

                hall = "Small Hall";
            }
            else if (groupSize > 50 && groupSize <= 100)
            {
                hallPrice = 5000;

                switch (package)
                {
                    case "Normal":
                        discount = 0.05;
                        packigePrice = 500;
                        break;
                    case "Gold":
                        discount = 0.1;
                        packigePrice = 750;
                        break;
                    case "Platinum":
                        discount = 0.15;
                        packigePrice = 1000;
                        break;
                }

                hall = "Terrace";
            }
            else if (groupSize > 100 && groupSize <= 120)
            {
                hallPrice = 7500;

                switch (package)
                {
                    case "Normal":
                        discount = 0.05;
                        packigePrice = 500;
                        break;
                    case "Gold":
                        discount = 0.1;
                        packigePrice = 750;
                        break;
                    case "Platinum":
                        discount = 0.15;
                        packigePrice = 1000;
                        break;
                }

                hall = "Great Hall";
            }
            else
            {
                Console.WriteLine("We do not have an appropriate hall.");
                return;
            }

            double totalPrice = (hallPrice + packigePrice);
            discountPrice = totalPrice - (totalPrice * discount);
            double finalePrice = 0;
            finalePrice = discountPrice / groupSize;

            Console.WriteLine($"We can offer you the {hall}");
            Console.WriteLine($"The price per person is {finalePrice:f2}$");
        }
    }
}
