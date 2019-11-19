using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;

namespace _06._Zipping_Sliced_Files
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Parts count = ");
            int parts = int.Parse(Console.ReadLine());

            string sourceFile = "../../../../files/sliceMe.mp4";
            string destination = "../../../../files/";

            Slice(sourceFile, destination, parts);


            List<string> files = new List<string>();

            for (int i = 0; i < parts; i++)
            {
                files.Add($"{destination}/Part-{i}.gz");
            }

            string writeFiles = "../../../../files/assemled.mp4";

            Assemble(files, writeFiles);
        }

        private static void Assemble(List<string> files, string destinationDirectory)
        {
            using (FileStream destination = new FileStream($"{destinationDirectory}/assembled.mp4", FileMode.Create))
            {
                foreach (var file in files)
                {
                    using (FileStream partStream = new FileStream(file, FileMode.Open))
                    {
                        using (GZipStream decompressingStream = new GZipStream(partStream, CompressionMode.Decompress, false))
                        {
                            byte[] buffer = new byte[4096];
                            int readBytes;
                            while ((readBytes = decompressingStream.Read(buffer, 0, buffer.Length)) != 0)
                            {
                                destination.Write(buffer, 0, readBytes);
                            }
                        }
                    }
                }
            }
        }

        static void Slice(string sourceFile, string destinationDirectory, int parts)
        {
            using (FileStream source = new FileStream(sourceFile, FileMode.Open))
            {
                long partSize = (long)Math.Ceiling((double)source.Length / parts);
                for (int i = 0; i < parts; i++)
                {
                    using (FileStream destination = new FileStream($"{destinationDirectory}/Part-{i}.gz", FileMode.Create))
                    {
                        using (GZipStream compressionStream = new GZipStream(destination, CompressionMode.Compress, false))
                        {
                            byte[] buffer = new byte[4096];
                            int readBytes;
                            long position = 0;
                            while (position < partSize && (readBytes = source.Read(buffer, 0, buffer.Length)) > 0)
                            {
                                compressionStream.Write(buffer, 0, readBytes);
                                position += readBytes;
                            }
                        }
                    }
                }
            }
        }
    }
}