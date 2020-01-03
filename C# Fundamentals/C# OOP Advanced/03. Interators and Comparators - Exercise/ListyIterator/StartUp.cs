using System;
using System.Linq;

namespace ListyIterator
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] createCommand = Console.ReadLine().Split().Skip(1).ToArray();
            ListyIterator<string> listyIterator = new ListyIterator<string>(createCommand);

            string command = Console.ReadLine();

            while (command != "END")
            {
                try
                {
                    switch (command)
                    {
                        case "HasNext":
                            Console.WriteLine(listyIterator.HasNext());
                            break;
                        case "Move":
                            Console.WriteLine(listyIterator.Move());
                            break;
                        case "Print":
                            Console.WriteLine(listyIterator.Print());
                            break;
                    }

                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);
                }

                command = Console.ReadLine();
            }
        }
    }
}
