using System.Collections.Generic;

namespace StrategyPattern
{
    public class PeopleByAge : IComparer<Person>
    {
        public int Compare(Person first, Person second)
        {
            int result = first.Age.CompareTo(second.Age);
            return result;
        }
    }
}
