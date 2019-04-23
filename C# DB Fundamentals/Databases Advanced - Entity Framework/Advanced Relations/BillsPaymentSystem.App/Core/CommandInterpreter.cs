using BillsPaymentSystem.App.Core.Commands.Contrats;
using BillsPaymentSystem.App.Core.Contracts;
using BillsPaymentSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace BillsPaymentSystem.App.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        private const string Suffix = "UserInfoInputCommand";

        public string Read(int userId , BillsPaymentSystemContext context)
        {
            //UserInfo 1
            var type = Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(x => x.Name == Suffix);

            if(type == null)
            {
                throw new ArgumentException($"User with id {userId} not found!");
            }

            var typeInstance = Activator.CreateInstance(type, context);

            var result = ((ICommand)typeInstance).Execute(userId);

            return result;
        }
    }
}
