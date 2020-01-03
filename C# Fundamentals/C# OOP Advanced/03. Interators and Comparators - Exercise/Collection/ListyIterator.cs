using System;
using System.Collections;
using System.Collections.Generic;

namespace Collection
{
    public class ListyIterator<T> : IEnumerable<T>
    {
        private T[] array;
        private int counter;

        public ListyIterator(T[] array)
        {
            this.array = array;
        }

        public int Counter
        {
            get { return counter; }
            private set { counter = value; }
        }

        public bool HasNext()
        {
            return this.counter + 1 < this.array.Length; 
        }

        public bool Move()
        {
            if (this.counter < this.array.Length - 1)
            {
                this.counter++;
                return true;
            }

            return false;
        }

        public T Print()
        {
            if (this.array.Length == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }
            
            return this.array[counter];
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.array.Length; i++)
            {
                yield return this.array[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        //public T Print()
        //{
        //    if (IsNullOrEmpty(this.list.ToArray()))
        //    {
        //        throw new InvalidOperationException("Invalid Operation!");
        //    }

        //    return this.list[Counter];
        //}

        //private bool IsNullOrEmpty(T[] array)
        //{
        //    return array == null || array.Length == 0;
        //}
    }
}
