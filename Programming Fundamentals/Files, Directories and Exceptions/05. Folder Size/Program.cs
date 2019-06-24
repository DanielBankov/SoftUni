using System;
using System.IO;

namespace _05._Folder_Size
{
    class Program
    {
        static void Main(string[] args)
        {
            var dir = "..\\..\\..\\TestFolder";

            string[] files = Directory.GetFiles(dir);
            long totalBytes = 0;

            foreach (var file in files)
            {
                totalBytes += new FileInfo(file).Length;
            }

            var result =  (totalBytes * 1.0) / (1024 * 1024);
            Console.WriteLine(result);
        }
    }
}
