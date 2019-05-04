using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _06._Reversed_List
{
    public class ReversedList<T> : IEnumerable<T>
    {
        private T[] array;
        public int Count { get; set; }
        public int Capacity => this.array.Length;

        public ReversedList()
        {
            this.array = new T[2];
        }

        public T this[int index]
        {
            get
            {
                ValidateArrayRange(index);
                return this.array[index];
            }

            set
            {
                ValidateArrayRange(index);
                this.array[index] = value;
            }
        }

        public void Add(T element)
        {
            if (this.array.Length == this.Count)
            {
                Resize();
            }

            this.array[Count++] = element;
        }

        private void Reverse()
        {
            T[] copy = new T[this.array.Length];
            int count = 0;

            for (int i = this.Count - 1; i >= 0; i--)
            {
                copy[count++] = this.array[i];
            }

            this.array = copy;
        }

        private void ReverseBack()
        {
            T[] copy = new T[this.array.Length];
            int count = 0;

            for (int i = 0; i < this.Count; i++)
            {
                copy[count++] = this.array[i];
            }

            this.array = copy;
        }

        private void Resize()
        {
            T[] copy = new T[this.array.Length * 2];

            for (int i = 0; i < this.array.Length; i++)
            {
                copy[i] = this.array[i];
            }

            this.array = copy;
        }

        public void RemoveAt(int index)
        {
            ValidateArrayRange(index);
            Reverse();

            this.array[index] = default(T);

            for (int i = index; i < this.Count; i++)
            {
                this.array[i] = this.array[i + 1];
            }

            ReverseBack();
            Count--;
        }

        private void ValidateArrayRange(int index)
        {
            if (index < 0 || index > array.Length)
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.Count - 1; i >= 0; i--)
            {
                yield return this.array[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
