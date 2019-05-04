using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _02._Sort_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> inputWords = Console.ReadLine().Split().ToList();
            StringBuilder sb = new StringBuilder();

            var words = InsertionSortWord(inputWords);

            foreach (var word in words)
            {
                sb.Append(word + " ");
            }

            Console.WriteLine(sb.ToString().TrimEnd());
        }

        static List<string> InsertionSortWord(List<string> inputArray)
        {
            for (int i = 0; i < inputArray.Count - 1; i++)
            {
                for (int j = i + 1; j > 0; j--)
                {
                    string firstWord = inputArray[j - 1];
                    string secondWord = inputArray[j];

                    var equalWordCount = 0;

                    while (firstWord[equalWordCount] == secondWord[equalWordCount])
                    {
                        equalWordCount++;

                        if(firstWord.Length == equalWordCount || secondWord.Length == equalWordCount)
                        {
                            equalWordCount--;
                            break;
                        }
                    }

                    if (firstWord[equalWordCount] > secondWord[equalWordCount])
                    {
                        string temp = inputArray[j - 1];
                        inputArray[j - 1] = inputArray[j];
                        inputArray[j] = temp;
                    }
                }
            }

            return inputArray;
        }
    }
}
