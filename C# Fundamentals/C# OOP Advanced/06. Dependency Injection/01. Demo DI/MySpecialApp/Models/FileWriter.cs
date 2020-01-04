using MySpecialApp.Contracts;
using System.IO;

namespace MySpecialApp.Models
{
    public class FileWriter : IWriter
    {
        private const string path = "../../../text.txt";

        public void Write(string text)
        {
            File.AppendAllText(path, text);
        }
    }
}
