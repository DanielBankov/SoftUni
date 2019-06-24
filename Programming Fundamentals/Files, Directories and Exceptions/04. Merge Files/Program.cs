using System;
using System.IO;

namespace _04._Merge_Files
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] fileOne = File.ReadAllLines("..\\..\\..\\FileOne.txt");
            string[] fileTwo = File.ReadAllLines("..\\..\\..\\FileTwo.txt");

            using (StreamWriter writer = File.CreateText("..\\..\\..\\Output.txt"))
            {
                int lineNum = 0;

                while (lineNum < fileOne.Length || lineNum < fileTwo.Length)
                {
                    writer.WriteLine(fileOne[lineNum]);
                    writer.WriteLine(fileTwo[lineNum]);
                    lineNum++;
                }
            }
        }
    }
}
