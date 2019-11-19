using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace WordCount
{
    class WordCount
    {
        static void Main()
        {
            Dictionary<string, int> words = new Dictionary<string, int>();

            using (StreamReader reader = new StreamReader("../../../../files/words.txt"))
            {
                string line = reader.ReadLine();

                while (line != null)
                {
                    if (!words.ContainsKey(line))
                    {
                        words.Add(line, 0);
                    }

                    line = reader.ReadLine();
                }
            }

            using (StreamReader reader = new StreamReader("../../../../files/text.txt"))
            {
                string line = reader.ReadLine();

                while (line != null)
                {
                    Regex regex = new Regex("[A-Za-z']+");
                    line = line.ToLower();

                    foreach (Match currWord in regex.Matches(line))
                    {
                        if (words.ContainsKey(currWord.Value))
                        {
                            words[currWord.Value]++;
                        }
                    }

                    line = reader.ReadLine();
                }
            }

            using (StreamWriter reader = new StreamWriter("../../../../files/result.txt"))
            {
                foreach (var word in words.OrderByDescending(x => x.Value))
                {
                    reader.WriteLine($"{word.Key} - {word.Value}");
                }
            }
        }
    }
}
