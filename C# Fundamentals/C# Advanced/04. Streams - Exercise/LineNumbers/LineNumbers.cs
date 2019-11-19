using System;
using System.IO;

namespace LineNumbers
{
    class LineNumbers
    {
        static void Main()
        {
            using (StreamReader reader = new StreamReader("../../../../files/text.txt"))
            {
                using (StreamWriter writer = new StreamWriter("../../../../files/output.txt"))
                {
                    string line = reader.ReadLine();
                    int count = 0;

                    while (line != null)
                    {
                        writer.WriteLine($"Line {++count}:{line}");
                        line = reader.ReadLine();
                    }
                }
            }
        }
    }
}
