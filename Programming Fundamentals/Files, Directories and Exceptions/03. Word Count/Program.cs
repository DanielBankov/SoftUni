using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace _03._Word_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputWords = File.ReadAllText("..\\..\\..\\words.txt").ToLower();
            var words = inputWords.Split(" ").ToArray();

            var inputText = File.ReadAllText("..\\..\\..\\text.txt").ToLower();
            var text = inputText.Split(new char[] { ',', '-', '.', '\'', ' ', '?', '!'}).ToArray();

            Dictionary<string, int> outputDict = new Dictionary<string, int>();

            for (int w = 0; w < words.Length; w++)
            {
                for (int t = 0; t < text.Length; t++)
                {
                    if(words[w] == text[t])
                    {
                        if (!outputDict.ContainsKey(words[w]))
                        {
                            outputDict.Add(words[w], 1);
                            continue;
                        }

                        outputDict[words[w]]++;
                    }
                }
            }

            var sb = new StringBuilder();

            foreach (var item in outputDict)
            {
                sb.AppendLine($"{item.Key} - {item.Value}");
            }

            File.WriteAllText("..\\..\\..\\Output.txt", sb.ToString());
        }
    }
}
