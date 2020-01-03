namespace GenericSwapMethodIntegers
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Box<int> box = new Box<int>();

            for (int i = 0; i < n; i++)
            {
                int input = int.Parse(Console.ReadLine());

                box.Add(input);
            }

            int[] swapIndexes = Console.ReadLine().Split().Select(int.Parse).ToArray();

            box.Swap(swapIndexes);

            Console.WriteLine(box);
        }
    }
}
