using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int sbor = 0;
            int umnoj = 0;
            int inter = 0;
            for (int i = 1; i <= 30; i++)
            {
                for (int j = 1; j <= 30; j++)
                {
                    for (int k = 1; k <= 30; k++)
                    {
                        sbor = i + j + k;
                        umnoj = i * j * k;

                        if(i < j && j < k && sbor == num)
                        {
                            Console.WriteLine($"{i} + {j} + {k} = {num}");
                            inter++;
                        }

                        else if (i > j && j > k && umnoj == num)
                        {
                            Console.WriteLine($"{i} * {j} * {k} = {num}");
                            inter++;
                        }
                        
                    }
                }
            }
            if (inter == 0)
            {
                Console.WriteLine("No!");
            }
            
        }
    }
}
