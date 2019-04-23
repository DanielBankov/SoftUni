using BillsPaymentSystem.App.Core;
using BillsPaymentSystem.App.Core.Contracts;
using BillsPaymentSystem.Data;
using System;

namespace BillsPaymentSystem.App
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            //SeedDataBase();

            ICommandInterpreter commandInterpreter = new CommandInterpreter();
            
            IEngine engine = new Engine(commandInterpreter);
            engine.Run(); 
        }

        private static void SeedDataBase()
        {
            using (BillsPaymentSystemContext context = new BillsPaymentSystemContext())
            {
                DbInitializser.Seed(context);
            }
        }
    }
}
