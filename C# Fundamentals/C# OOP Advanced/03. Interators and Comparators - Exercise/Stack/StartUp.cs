using System;
using System.Linq;

namespace Stack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int[] inputNumbers = Console.ReadLine()
                .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Skip(1)
                .Select(int.Parse)
                .ToArray();

            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < inputNumbers.Length; i++)
            {
                stack.Push(inputNumbers[i]);
            }

            string[] inputCommand = Console.ReadLine().Split();

            while (inputCommand[0] != "END")
            {
                switch (inputCommand[0])
                {
                    case "Push":
                        foreach (var elem in inputCommand.Skip(1))
                        {
                            stack.Push(int.Parse(elem));
                        }
                        break;
                    case "Pop":
                        try
                        {
                            stack.Pop();
                        }
                        catch (InvalidOperationException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                }

                inputCommand = Console.ReadLine().Split();
            }

            if(stack.ArrayCount != 0)
            {
                Console.WriteLine(string.Join(Environment.NewLine, stack));
                Console.WriteLine(string.Join(Environment.NewLine, stack));
            }

        }
    }
}
