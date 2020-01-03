namespace CustomListIterator
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class BoxList<T> : IBoxList<T>, IEnumerable<T>
        where T : IComparable
    {
        //TODO validation Exceptions 

        private const int InitialCapacity = 4;
        private T[] list;

        public BoxList()
        {
            this.list = new T[InitialCapacity];
        }

        public int Count { get; private set; }

        public void Add(T element)
        {
            if (this.list.Length == Count)
            {
                Resize();
            }

            list[Count++] = element;
        }

        public bool Contains(T element)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.list[i].Equals(element))
                {
                    return true;
                }
            }

            return false;
        }

        public int CountGreaterThan(T element)
        {
            int count = 0;

            for (int i = 0; i < this.Count; i++)
            {
                if (list[i].CompareTo(element) > 0)
                {
                    count++;
                }
            }

            return count;
        }

        public T Max()
        {
            T maxValue = this.list[0];

            for (int i = 0; i < this.Count; i++)
            {
                if (this.list[i].CompareTo(maxValue) > 0)
                {
                    maxValue = this.list[i];
                }
            }

            return maxValue;
        }

        public T Min()
        {
            T minValue = this.list[0];

            for (int i = 0; i < this.Count; i++)
            {
                if (this.list[i].CompareTo(minValue) < 0)
                {
                    minValue = this.list[i];
                }
            }

            return minValue;
        }

        public T Remove(int index)
        {
            T removedElement = this.list[index];

            this.list[index] = default(T);
            this.Count--;

            for (int i = index; i < this.Count; i++)
            {
                this.list[i] = this.list[i + 1];
            }

            if (this.list.Length != this.Count)
            {
                this.list[this.Count] = default(T);
            }

            return removedElement;
        }

        public void Sort()
        {
            for (int i = 0; i < this.Count; i++)
            {
                for (int j = i + 1; j < this.Count; j++)
                {
                    if (this.list[i].CompareTo(this.list[j]) > 0)
                    {
                        this.Swap(i, j);
                    }
                }
            }
        }

        public void Swap(int firstIndexSwap, int secondIndexSwap)
        {
            T currIndexValue = list[firstIndexSwap];
            list[firstIndexSwap] = list[secondIndexSwap];
            list[secondIndexSwap] = currIndexValue;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.Count; i++)
            {
                yield return this.list[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private void Resize()
        {
            T[] tempArray = new T[this.Count * 2];

            for (int i = 0; i < Count; i++)
            {
                tempArray[i] = list[i];
            }

            list = tempArray;
        }
    }
}
