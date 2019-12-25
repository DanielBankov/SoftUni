using System;
using System.Collections.Generic;

namespace BoxOfT
{
    public class Box<T>
    {
        private Stack<T> box;

        public Box()
        {
            this.box = new Stack<T>();
        }

        public int Count => this.box.Count;

        public void Add(T element)
        {
            this.box.Push(element);
        }

        public T Remove()
        {
            if (box.Count <= 0)
            {
                throw new InvalidOperationException("Box is empty.");
            }

            return this.box.Pop();
        }
    }
}
