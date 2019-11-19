using System;
using System.IO;
using System.Linq;

namespace ReverceText
{
    class ReverceText
    {
        static void Main()
        {
            string path = "../../../";
            string inputFileName = "ReverceText.cs";
            string outputFileName = "RevercedText.txt";

            path = Path.Combine(path, inputFileName);

            using (StreamReader reader = new StreamReader(path))
            {
                using (StreamWriter writer = new StreamWriter(outputFileName))
                {
                    string line = reader.ReadLine();

                    while (line != null)
                    {
                        writer.WriteLine(string.Join("", line.Reverse()));

                        line = reader.ReadLine();
                    }
                }
                
            }
        }
    }
}
