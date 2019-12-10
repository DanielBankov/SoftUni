namespace DateModifier
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            string firstDate = Console.ReadLine();
            string secondDate = Console.ReadLine();

            Console.WriteLine(DateModifier.DaysDiff(firstDate, secondDate));
        }
    }
}
