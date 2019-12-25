namespace CustomListSorter
{
    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            string[] inputArgs = Console.ReadLine().Split();
            CommandInterpretair interpretair = new CommandInterpretair();

            while (inputArgs[0] != "END")
            {
                interpretair.Command(inputArgs);

                inputArgs = Console.ReadLine().Split();
            }

        }
    }
}
