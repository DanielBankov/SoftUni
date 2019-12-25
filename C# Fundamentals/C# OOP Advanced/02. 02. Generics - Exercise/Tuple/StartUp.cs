using System;

namespace Threeuple
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] firstLine = Console.ReadLine().Split();

            string fullName = firstLine[0] + " " + firstLine[1];
            string area = firstLine[2];

            string[] secondLine = Console.ReadLine().Split();

            string name = secondLine[0];
            int age = int.Parse(secondLine[1]);

            string[] thridLine = Console.ReadLine().Split();

            int integer = int.Parse(thridLine[0]);
            double doubler = double.Parse(thridLine[1]);

            Tuple<string, string> firtstTuple = new Tuple<string, string>(fullName, area);
            Tuple<string, int> secondTuple = new Tuple<string, int>(name, age);
            Tuple<int, double> thirdTuple = new Tuple<int, double>(integer, doubler);

            Console.WriteLine(firtstTuple);
            Console.WriteLine(secondTuple);
            Console.WriteLine(thirdTuple);
        }
    }
}
