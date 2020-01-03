namespace GenericCountMethodDouble
{
    using System;
    using System.Collections.Generic;

    public class Box<T> 
        where T : IComparable
    {
        public Box()
        {
            Items = new List<T>();
        }

        public IList<T> Items { get; }

        public void Add(T item)
        {
            this.Items.Add(item);
        }

        public int Comparison(double value)
        {
            int count = 0;

            foreach (var item in Items)
            {
                if (item.CompareTo(value) > 0)
                {
                    count++;
                }
            }

            return count;
        }
    }
}
