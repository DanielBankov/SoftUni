using System;

namespace DateModifier
{
    public class DateModifier
    {
        public static int DaysDiff(string firstDate, string secondDate)
        {
            DateTime first = DateTime.Parse(firstDate);
            DateTime second = DateTime.Parse(secondDate);

            return Math.Abs((first - second).Days);
        }
    }
}
