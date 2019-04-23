using System;

namespace Problem_04
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int reviewed = 0;
            int notReviewed = 0;
            int gp = 7;

            for (int i = 1; i <= n; i++)
            {
                int days = int.Parse(Console.ReadLine());

                if (i % 3 == 0)
                {
                   if(notReviewed > reviewed)
                        gp++;
                }

                if (days <= gp)
                {
                    reviewed += days;
                }
                else
                {
                    reviewed += gp;
                    notReviewed += days - gp;
                }
            }

            Console.WriteLine($"Treated patients: {reviewed}.\nUntreated patients: {notReviewed}.");
        }
    }
}
