namespace GenericSwapMethodIntegers
{
    using System.Collections.Generic;
    using System.Text;

    public class Box<T>
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

        public void Swap(int[] swapIndexes)
        {
            int firstIndexSwap = swapIndexes[0];
            int secondIndexSwap = swapIndexes[1];

            T currIndexValue = Items[firstIndexSwap];
            Items[firstIndexSwap] = Items[secondIndexSwap];
            Items[secondIndexSwap] = currIndexValue;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var item in Items)
            {
                sb.AppendLine($"{item.GetType().FullName}: {item}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
