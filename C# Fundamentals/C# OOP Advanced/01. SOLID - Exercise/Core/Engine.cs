namespace SOLID_Exercise.Core
{
    using Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Engine : IEngine
    {
        private ICommandInterpreter commandInterpreter;

        public Engine()
        {
            this.commandInterpreter = new CommandInterpreter();
        }

        public void Run()
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] args = Console.ReadLine().Split();
                this.commandInterpreter.AddAppender(args);
            }

            string inputMessages = Console.ReadLine();

            while (inputMessages != "END")
            {
                string[] args = inputMessages.Split("|").ToArray();
                this.commandInterpreter.AddMessage(args);

                inputMessages = Console.ReadLine();
            }

            commandInterpreter.PrintInfo();
        }
    }
}
