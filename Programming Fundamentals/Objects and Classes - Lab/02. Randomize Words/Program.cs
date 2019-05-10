using System;

namespace _02._Randomize_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            var words = Console.ReadLine().Split();
            var rnd = new Random();

            for (int i = 0; i < words.Length; i++)
            {
                int firstWord = rnd.Next(0, words.Length);
                int secondWord = rnd.Next(0, words.Length);

                string changer = words[firstWord];
                words[firstWord] = words[secondWord];
                words[secondWord] = changer;
            }

            Console.WriteLine(string.Join(Environment.NewLine, words));
        }
    }
}
