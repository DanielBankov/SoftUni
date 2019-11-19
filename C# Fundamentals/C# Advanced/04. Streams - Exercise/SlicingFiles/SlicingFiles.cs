using System;
using System.Collections.Generic;
using System.IO;

namespace SlicingFiles
{
    class SlicingFiles
    {
        static List<string> files;

        static void Main(string[] args)
        {
            string sourceFile = "../../../../files/sliceMe.mp4";
            string destination = "../../../../files/";
            string writeFiles = "../../../../files/assemled.mp4";

            files = new List<string>();
            int parts = 4;

            Slice(sourceFile, destination, parts);
            Assemble(files, writeFiles);

        }

        private static void Assemble(List<string> files, string writeFiles)
        {
            using (FileStream writeFile = new FileStream(writeFiles, FileMode.Create))
            {
                foreach (var path in files)
                {
                    using (FileStream readFile = new FileStream(path, FileMode.Open))
                    {
                        byte[] buffer = new byte[readFile.Length];
                        readFile.Read(buffer, 0, buffer.Length);

                        writeFile.Write(buffer, 0, buffer.Length);
                    }
                }
            }
        }

        private static void Slice(string sourceFile, string destination, int parts)
        {
            using (FileStream readfile = new FileStream(sourceFile, FileMode.Open))
            {
                long size = readfile.Length / parts;
                byte[] buffer = new byte[size];

                for (int i = 0; i < parts; i++)
                {
                    string destPath = destination + $"Path{i}.mp4";
                    int readedBytes = 0;
                    files.Add(destPath);

                    using(FileStream writeFile = new FileStream(destPath, FileMode.Create))
                    {
                         while (true)
                        {
                            int bytesCount = readfile.Read(buffer, 0, buffer.Length);
                            readedBytes += bytesCount;

                            if (readedBytes >= size)
                            {
                                break;
                            }

                            if(readedBytes == bytesCount)
                            {
                                break;
                            }
 
                        }

                        writeFile.Write(buffer, 0, buffer.Length);
                    }
                }
            }
        }
    }
}
