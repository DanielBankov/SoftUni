using BillsPaymentSystem.App.Core.Contracts;
using BillsPaymentSystem.Data;
using System;

namespace BillsPaymentSystem.App.Core
{
    public class Engine : IEngine
    {
        private readonly ICommandInterpreter commandInterpreter;

        public Engine(ICommandInterpreter command)
        {
            this.commandInterpreter = command;
        }

        public void Run()
        {
            int userId = int.Parse(Console.ReadLine());

            using (BillsPaymentSystemContext context = new BillsPaymentSystemContext())
            {
                string result = commandInterpreter.Read(userId, context);
            }

            //TODO: Add catch exceptions
        }
    }
}
