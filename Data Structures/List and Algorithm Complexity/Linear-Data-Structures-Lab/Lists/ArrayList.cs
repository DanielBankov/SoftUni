using System;

public class ArrayList<T>
{
    private const int InitialCapacity = 2;

    private T[] array;

    public ArrayList()
    {
        this.array = new T[InitialCapacity];
    }

    public int Count { get; private set; }

    public T this[int index]
    {
        get
        {
            if (index < 0 || index >= Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            return this.array[index];
        }

        set
        {
            if (index < 0 || index >= Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            this.array[index] = value;
        }
    }

    public void Add(T item)
    {
        if (this.array.Length == Count)
        {
            Resize();
        }

        this.array[Count++] = item;
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

    public T RemoveAt(int index)
    {
        if (index < 0 || index >= this.Count)
        {
            throw new ArgumentOutOfRangeException();
        }

        T element = this.array[index];
        this.array[index] = default(T);
        Shift(index);
        this.Count--;

        if(this.Count <= this.array.Length / 4) 
        {
            Shrink();
        }

        return element;
    }

    private void Shrink()
    {
        T[] copy = new T[this.array.Length / 2];

        for (int i = 0; i < this.Count; i++)
        {
            copy[i] = this.array[i];
        }

        this.array = copy;
    }

    private void Shift(int index)
    {
        for (int i = index; i < this.Count; i++)
        {
            this.array[i] = this.array[i + 1];
        }
    }
}
