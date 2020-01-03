using System;

namespace ListyIterator
{
    public class ListyIterator<T>
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
    }
}
