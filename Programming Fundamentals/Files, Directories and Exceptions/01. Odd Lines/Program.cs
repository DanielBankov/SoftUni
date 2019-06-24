using System.IO;
using System.Text;

namespace _01._Odd_Lines
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllLines("..\\..\\..\\Input.txt");
            var sb = new StringBuilder();

            for (int i = 0; i < input.Length; i++)
            {
                if(i % 2 != 0)
                {
                    sb.AppendLine(input[i]);
                }
            }

            File.WriteAllText("..\\..\\..\\Output.txt", sb.ToString());
        }
    }
}
