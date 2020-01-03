using System;
using System.Collections;
using System.Collections.Generic;

namespace Stack
{
    public class Stack<T> : IEnumerable<T>
    {
        private T[] array;
        private int capacity;
        private int arrayCount;

        public Stack()
        {
            this.capacity = 4;
            this.array = new T[this.capacity];
        }

        public T[] Array
        {
            get { return array; }
            set { array = value; }
        }

        public int ArrayCount { get => arrayCount; set => arrayCount = value; }

        public void Push(T element)
        {
            if(this.arrayCount == this.capacity)
            {
                Resize(this.array);
            }

            this.array[this.arrayCount] = element;
            this.arrayCount++;
        }

        public T Pop()
        {
            if(this.arrayCount == 0)
            {
                throw new InvalidOperationException("No elements");
            }

            T popedElement = this.array[arrayCount - 1];
            this.array[arrayCount - 1] = default(T);
            this.arrayCount--;

            return popedElement;
        }

        private void Resize(T[] array)
        {
            T[] temporaryArray = new T[this.capacity * 2];

            for (int i = 0; i < this.arrayCount; i++)
            {
                temporaryArray[i] = this.array[i];
            }

            this.array = temporaryArray;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.arrayCount - 1; i >= 0; i--)
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
