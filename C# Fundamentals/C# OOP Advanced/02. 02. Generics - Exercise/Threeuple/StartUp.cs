namespace Threeuple
{
    using System;

    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] firstLine = Console.ReadLine().Split();

            string fullName = firstLine[0] + " " + firstLine[1];
            string area = firstLine[2];
            string city = firstLine[3];

            string[] secondLine = Console.ReadLine().Split();

            string name = secondLine[0];
            int age = int.Parse(secondLine[1]);
            bool drunkOrNot = secondLine[2] == "drunk" ? true : false;

            string[] thridLine = Console.ReadLine().Split();

            string nickname = thridLine[0];
            double accountBalance = double.Parse(thridLine[1]);
            string bankName = thridLine[2];

            Tuple<string, string, string> firtstTuple = new Tuple<string, string, string>(fullName, area, city);
            Tuple<string, int, bool> secondTuple = new Tuple<string, int, bool>(name, age, drunkOrNot);
            Tuple<string, double, string> thirdTuple = new Tuple<string, double, string>(nickname, accountBalance, bankName);

            Console.WriteLine(firtstTuple);
            Console.WriteLine(secondTuple);
            Console.WriteLine(thirdTuple);
        }
    }
}
