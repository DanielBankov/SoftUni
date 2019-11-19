using System;
using System.IO;

namespace OddLines
{
    class OddLines
    {
        static void Main()
        {
            using (StreamReader streamReader = new StreamReader("../../../../files/text.txt"))
            {
                var line = streamReader.ReadLine();
                int count = 0;

                while (line != null)
                {
                    if(++count % 2 == 0)
                        Console.WriteLine(line);

                    line = streamReader.ReadLine();
                }

            }
        }
    }
}
