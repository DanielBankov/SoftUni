namespace GenericArrayCreator
{
    public class ArrayCreator
    {
        public static T[] Create<T>(int length, T item)
        {
            T[] arrayT = new T[length];

            return arrayT;
        }
    }
}
