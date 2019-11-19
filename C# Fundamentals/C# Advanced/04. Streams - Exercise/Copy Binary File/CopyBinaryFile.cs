using System;
using System.IO;

namespace Copy_Binary_File
{
    class CopyBinaryFile
    {
        static void Main()
        {
            using (FileStream readFile = new FileStream("../../../../files/copyMe.png", FileMode.Open))
            {
                byte[] buffer = new byte[readFile.Length];
                readFile.Read(buffer, 0, buffer.Length);

                using (FileStream writeFile = new FileStream("../../../../files/copyMe-copied.png", FileMode.Create))
                {
                    writeFile.Write(buffer, 0, buffer.Length);
                }
            }
        }
    }
}
