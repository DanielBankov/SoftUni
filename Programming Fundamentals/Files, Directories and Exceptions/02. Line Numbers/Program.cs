using System;
using System.IO;
using System.Text;

namespace _02._Line_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllLines("..\\..\\..\\Input.txt");
            var sb = new StringBuilder();

            for (int i = 0; i < input.Length; i++)
            {
                var line = $"{i + 1}. ";
                sb.AppendLine(string.Concat(line, input[i]));
            }

            File.WriteAllText("..\\..\\..\\Output.txt", sb.ToString());
        }
    }
}
