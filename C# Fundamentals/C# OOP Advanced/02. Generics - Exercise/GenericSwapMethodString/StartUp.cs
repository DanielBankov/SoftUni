namespace GenericSwapMethodString
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Box<string> box = new Box<string>();

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                box.Add(input);
            }

            int[] swapIndexes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            box.Swap(swapIndexes);
            Console.WriteLine(box);
        }
    }
}
