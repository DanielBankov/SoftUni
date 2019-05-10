using System;

namespace _02._Count_Substring_Occurrences
{
    class Program
    {
        static void Main(string[] args)
        {
            var text = Console.ReadLine().ToLower();
            var word = Console.ReadLine().ToLower();
            var count = -1;
            var indexer = int.MinValue;

            for (int i = 0; i < text.Length; i++)
            {
                var currWordIndex = text.IndexOf(word, i); 

                if(indexer != currWordIndex)
                {
                    indexer = currWordIndex;
                    count++;
                }
            }
            
            Console.WriteLine(count);
        }
    }
}
