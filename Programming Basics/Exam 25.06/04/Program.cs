using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04
{
    class Program
    {
        static void Main(string[] args)
        {
            int ProectPeases = int.Parse(Console.ReadLine());
            double moneyfor1point = double.Parse(Console.ReadLine());

            int peaceEVENorODD = 0;
            int finalpoints = 0;

            for (int i = 1; i <= ProectPeases; i++)
            {
                int points = int.Parse(Console.ReadLine());
                peaceEVENorODD++;

                if(peaceEVENorODD % 2 == 0)
                {
                   finalpoints += points * 2;
                }
                else
                {
                    finalpoints += points;
                }
            }

            double surprice = moneyfor1point * finalpoints;

            Console.WriteLine($"The project prize was {surprice:f2} lv.");
            
        }
    }
}
